using System;
using Application.DTO;
using Application.Interfaces;
using Contracts.Achievements;
using Contracts.Comments;
using Contracts.VerificationRequests;
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
    //[Authorize]
    [Produces(typeof(VerificationRequestFullResponse))]
    public async Task<IActionResult> NewRequest([FromBody] VerificationRequestRequest request)
    {
        Result<RequestDto> result = await _requestService.Create(
            HttpContext.User,
            request.EventName, 
            request.Description,
            request.ImageIds);
        
        return ResultToResponse(result, ToFullResponse);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [Produces(typeof(VerificationRequestFullResponse))]
    public async Task<IActionResult> GetRequestById(Guid id)
    {
        Result<RequestDto> result = await _requestService.GetById(id);
        return ResultToResponse(result, ToFullResponse);
    }

    [HttpGet("unscored/{count}")]
    //[Authorize] admin only
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetUnscored(int count)
    {
        Result<List<RequestDto>> result = await _requestService.GetUnscored(count);
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("user/{login}/{count}")]
    //[Authorize] admin only
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetByUser(string login, int count)
    {
        Result<List<RequestDto>> result = await _requestService.GetByLogin(login, count);
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("user/{login}/{status}/{count}")]
    //[Authorize] admin only
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetByUser(string login, RequestStatus status, int count)
    {
        Result<List<RequestDto>> result = await _requestService.GetByLogin(login, status, count);
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("self/{count}")]
    //[Authorize]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetSelf(int count)
    {
        Result<List<RequestDto>> result = await _requestService.GetSelf(HttpContext.User, count);
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpGet("self/{requestStatus}/{count}")]
    //[Authorize]
    [Produces(typeof(List<VerificationRequestResponse>))]
    public async Task<IActionResult> GetSelfWithStatus(RequestStatus requestStatus, int count)
    {
        Result<List<RequestDto>> result = await _requestService.GetSelf(HttpContext.User, requestStatus, count);
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }

    [HttpDelete("{id}")]
    //[Authorize] admin only
    public async Task<IActionResult> DeleteById(Guid id)
    {
        Result result = await _requestService.DeleteById(id);
        return ResultToResponse(result);
    }
    [HttpPost("{requestId}/reject")]
    public async Task<IActionResult> Reject([FromRoute] Guid requestId, [FromBody] RejectionRequest request)
    {
        Result result = await _requestService.Reject(
            HttpContext.User,
            requestId, 
            request.Message);

        return ResultToResponse(result);
    }
    [HttpPost("{requestId}/approve")]
    //[Authorize] admin only
    public async Task<IActionResult> Approve([FromRoute] Guid requestId, [FromBody] ApprovalRequest request)
    {
        Result result = await _requestService.Approve(
            HttpContext.User,
            requestId,
            request.Score
        );

        return ResultToResponse(result);
    }
    [HttpPost("{requestId}/revoke")]
    //[Authorize] admin only
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
            CreationDatetime : dto.CreationDatetime,
            Status : dto.Status);
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
    private static CommentFullResponse ToCommentFullResponse(CommentDto dto)
    {
        return new CommentFullResponse(
            Id: dto.Id,
            CommentingDateTime: dto.CommentingDateTime,
            CommentText: dto.CommentText,
            RequestId: dto.RequestId,
            CommentedByAdmin: dto.CommentedByAdmin
        );
    }

    [NonAction]
    private static AchievementDetailedResponse ToAchievementFullResponse(AchievementDto dto)
    {
        return new AchievementDetailedResponse(
            Id: dto.Id,
            Score: dto.Score,
            RequestId: dto.RequestId,
            VerificationDateTime: dto.VerificationDateTime,
            VerificatedByAdmin: dto.VerificatedByAdmin
        );
    }
}