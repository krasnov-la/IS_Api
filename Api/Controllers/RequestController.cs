using System.Security.Claims;
using Application.Commands.Requests;
using Application.DTO;
using Application.Interfaces.Services;
using Contracts.Achievements;
using Contracts.Comments;
using Contracts.VerificationRequests;
using Domain.Entities;
using Domain.Enums;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("requests")]
public class RequestController(IRequestService requestService) : ApiController
{
    private readonly IRequestService _requestService = requestService;
    [HttpPost]
    [Authorize("Student")]
    [Produces(typeof(VerificationRequestFullResponse))]
    public async Task<IActionResult> NewRequest([FromBody] NewVerificationRequestRequest request)
    {
        Result<RequestDto> result = await _requestService.Create(
            new CreateRequestCommand(
                HttpContext.User,
                request.EventName, 
                request.Description,
                request.ImageIds));
        
        return ResultToResponse(result, ToFullResponse);
    }

    [HttpGet("{id}")]
    [Authorize("Verificated")]
    [Produces(typeof(VerificationRequestFullResponse))]
    public async Task<IActionResult> GetRequestById(Guid id)
    {
        Result<RequestDto> result = await _requestService.GetById(User, id);
        return ResultToResponse(result, ToFullResponse);
    }

    [HttpGet("unscored/{count}/{offset}")]
    [Authorize("Admin")]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetUnscored(int count, int offset)
    {
        Result<List<RequestDto>> result = await _requestService.GetUnscored(
            new GetUnscoredCommand(count, offset));
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("user/{email}/{count}/{offset}")]
    [Authorize("Admin")]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetByUser(string email, int count, int offset)
    {
        Result<List<RequestDto>> result = await _requestService.GetByEmail(
            new GetRequestsByEmailCommand(email, count, offset));
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("user/{email}/{status}/{count}/{offset}")]
    [Authorize("Admin")]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetByUser(string email, RequestStatus status, int count, int offset)
    {
        Result<List<RequestDto>> result = await _requestService.GetByEmail(
            new GetRequestsByEmailCommand(email, count, offset, status));
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("approved/user/{email}/{count}/{offset}")]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetApprovedByUser(string email, int count, int offset)
    {
        Result<List<RequestDto>> result = await _requestService.GetByEmail(
            new GetRequestsByEmailCommand(email, count, offset, RequestStatus.Approved));
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("self/{count}/{offset}")]
    [Authorize("Student")]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetSelf(int count, int offset)
    {
        Result<List<RequestDto>> result = await _requestService.GetSelf(
            new GetSelfRequestsCommand(HttpContext.User, count, offset));
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("self/{requestStatus}/{count}/{offset}")]
    [Authorize("Student")]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetSelfWithStatus(RequestStatus requestStatus, int count, int offset)
    {
        Result<List<RequestDto>> result = await _requestService.GetSelf(
            new GetSelfRequestsCommand(HttpContext.User, count, offset, requestStatus));
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpDelete("{id}")]
    [Authorize("Admin")]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        Result result = await _requestService.DeleteById(id);
        return ResultToResponse(result);
    }
    [HttpPost("{requestId}/reject")]
    [Authorize("Admin")]
    public async Task<IActionResult> Reject([FromRoute] Guid requestId, [FromBody] RejectionRequest request)
    {
        Result result = await _requestService.Reject(
            new RejectRequestCommand(
            HttpContext.User,
            requestId, 
            request.Message));

        return ResultToResponse(result);
    }
    [HttpPost("{requestId}/approve")]
    [Authorize("Admin")]
    public async Task<IActionResult> Approve([FromRoute] Guid requestId, [FromBody] ApprovalRequest request)
    {
        Result result = await _requestService.Approve(
            new ApproveRequestCommand(
                HttpContext.User,
                requestId,
                request.Score
        ));

        return ResultToResponse(result);
    }
    [HttpPost("{requestId}/revoke")]
    [Authorize("Admin")]
    public async Task<IActionResult> Revoke([FromRoute] Guid requestId)
    {
        Result result = await _requestService.Revoke(requestId);
        return ResultToResponse(result);
    }

    [NonAction]
    private static VerificationRequestResponse ToShortResponse(RequestDto dto)
    {
        return new VerificationRequestResponse(
            Id : dto.Id,
            OwnerLogin : dto.OwnerLogin,
            EventName : dto.EventName,
            Description: dto.Description,
            CreationDatetime : dto.CreationDatetime,
            Status : dto.Status,
            Achievement: dto.Achievement is not null ? ToAchievementShortResponse(dto.Achievement) : null,
            Comment: dto.Comment is not null ? ToCommentShortResponse(dto.Comment) : null
            );
    }

    [NonAction]
    private static VerificationRequestFullResponse ToFullResponse(RequestDto dto)
    {
        return new VerificationRequestFullResponse(
            Id: dto.Id,
            OwnerLogin: dto.OwnerLogin,
            EventName : dto.EventName,
            Description: dto.Description,
            CreationDatetime : dto.CreationDatetime,
            Status : dto.Status,
            Achievement: dto.Achievement is not null ? ToAchievementFullResponse(dto.Achievement) : null,
            Comment: dto.Comment is not null ? ToCommentFullResponse(dto.Comment) : null,
            ImageIds: dto.ImageIds);
    }
    [NonAction]
    private static CommentShortResponse ToCommentShortResponse(CommentDto dto)
    {
        return new(
            dto.CommentText
        );
    }
    [NonAction]
    private static CommentFullResponse ToCommentFullResponse(CommentDto dto)
    {
        return new CommentFullResponse(
            Id: dto.Id,
            CommentText: dto.CommentText,
            CommentedByAdmin: dto.CommentedByAdmin
        );
    }
    [NonAction]
    private static AchievementShortResponse ToAchievementShortResponse(AchievementDto dto)
    {
        return new(
            dto.Score
        );
    }
    [NonAction]
    private static AchievementDetailedResponse ToAchievementFullResponse(AchievementDto dto)
    {
        return new AchievementDetailedResponse(
            Id: dto.Id,
            Score: dto.Score,
            VerificatedByAdmin: dto.VerificatedByAdmin
        );
    }
}