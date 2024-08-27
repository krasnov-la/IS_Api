using System.Security.Claims;
using Application.Commands.Requests;
using Application.DTO;
using Application.Errors;
using Application.Errors.Common;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Enums;
using FluentResults;

namespace Application.Services;

public class RequestService(IRequestRepository requestRepository, IImageRepository imageRepository) : ServiceBase, IRequestService
{
    private readonly IRequestRepository _requestRepository = requestRepository;
    private readonly IImageRepository _imageRepository = imageRepository;
    public async Task<Result> Approve(ApproveRequestCommand command)
    {
        if (command.Score <= 0) return Result.Fail(new NegativeScoreError());
        
        Result<Request> result = await _requestRepository.GetById(command.RequestId);
        if (result.IsFailed) return Result.Fail(result.Errors);
        var request = result.Value;

        Result approval_res = request.Approve(
            new Admin(ExtractEmail(command.User)),
            command.Score);

        if (approval_res.IsFailed) return Result.Fail(new StatusChangeError());

        return await _requestRepository.Update(request);
    }
    //Authorize non admin
    public async Task<Result<RequestDto>> Create(CreateRequestCommand command)
    {
        var failed = command.ImageIds.Where(i => !_imageRepository.ValidateImage(i));
        if (failed.Any()) return Result.Fail(failed.Select(f => new ImageInvalidError(f)));

        var request = Request.Create(
            new Student(ExtractEmail(command.User)),
            command.EventName,
            command.Description,
            command.ImageIds.Select(id => new Image(id)).ToList()
        );

        Result result = await _requestRepository.Create(request);

        if (result.IsFailed) return Result.Fail(result.Errors);
        return Result.Ok(ToRequestDto(request));
    }

    public async Task<Result> DeleteById(Guid id)
    {
        return await _requestRepository.DeleteById(id);
    }

    public async Task<Result<List<RequestDto>>> GetByEmail(GetRequestsByEmailCommand command)
    {
        Result<List<Request>> result = await _requestRepository.GetByEmail(
            command.Email,
            command.Status,
            command.Count,
            command.Offset);

        if (result.IsFailed) return Result.Fail(result.Errors);
        return Result.Ok(result.Value.Select(ToRequestDto).ToList());
    }

    public async Task<Result<RequestDto>> GetById(Guid id)
    {
        Result<Request> result = await _requestRepository.GetById(id);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return Result.Ok(ToRequestDto(result.Value));
    }

    public Task<Result<List<RequestDto>>> GetSelf(GetSelfRequestsCommand command)
    {
        return GetByEmail(
            new GetRequestsByEmailCommand(
                ExtractEmail(command.User),
                command.Count,
                command.Offset,
                command.RequestStatus
            )
        );
    }

    public async Task<Result<List<RequestDto>>> GetUnscored(GetUnscoredCommand getUnscoredCommand)
    {
        Result<List<Request>> result = await _requestRepository.GetUnscored(getUnscoredCommand.Count, getUnscoredCommand.Offset);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return Result.Ok(result.Value.Select(ToRequestDto).ToList());
    }

    public async Task<Result> Reject(RejectRequestCommand command)
    {
        //TODO? Validate message
        Result<Request> result = await _requestRepository.GetById(command.RequestId);
        if (result.IsFailed) return Result.Fail(result.Errors);
        var request = result.Value;

        Result rejection_result = request.Reject(
            new Admin(ExtractEmail(command.User)),
            command.Message);

        if (rejection_result.IsFailed) return Result.Fail(new StatusChangeError());

        return await _requestRepository.Update(request);
    }

    public async Task<Result> Revoke(Guid requestId)
    {
        Result<Request> result = await _requestRepository.GetById(requestId);
        if (result.IsFailed) return Result.Fail(result.Errors);
        var request = result.Value;

        request.Revoke();

        return await _requestRepository.Update(request);
    }

    private static RequestDto ToRequestDto(Request request)
    {
        return new RequestDto(
            request.Id,
            request.Student.EmailAddress,
            request.EventName,
            request.Description,
            request.CreatedAt,
            request.Status.ToString(),
            request.Achievement is null ? null : ToAchievementDto(request.Achievement),
            request.Comment is null ? null : ToCommentDto(request.Comment),
            request.Images.Select(i => i.Guid.ToString())
        );
    }

    private static CommentDto ToCommentDto(Comment comment)
    {
        return new CommentDto(
            comment.Id,
            comment.Message,
            comment.Admin.EmailAddress
        );
    }

    private static AchievementDto ToAchievementDto(Achievement achievement)
    {
        return new AchievementDto(
            achievement.Id,
            achievement.Score,
            achievement.Admin.EmailAddress
        );
    }
}
