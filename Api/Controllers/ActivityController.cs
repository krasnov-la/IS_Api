using Application.Commands.Activities;
using Application.DTO;
using Application.Interfaces.Services;
using Contracts.Activities;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("activities")]
public class ActivityController(IActivityService activityService) : ApiController
{
    private readonly IActivityService _activityService = activityService;
    [HttpPost]
    //[Authorize] admin only
    [Produces(typeof(ActivityFullResponse))]
    public async Task<IActionResult> NewActivity([FromBody] NewActivityRequest request)
    {
        Result<ActivityDto> result = await _activityService.Create(
            new NewActivityCommand(
                HttpContext.User,
                request.Name,
                request.StartingDate,
                request.EndingDate,
                request.Preview,
                request.Link
            ));
        return ResultToResponse(result, ToFullResponse);
    }
    [HttpPatch("{id}")]
    [Produces(typeof(ActivityFullResponse))]
    public async Task<IActionResult> UpdateActivity(Guid id, UpdateActivityRequest request)
    {
        Result<ActivityDto> result = await _activityService.Update(
            new UpdateActivityCommand(
                id,
                HttpContext.User,
                request.Name,
                request.StartingDate,
                request.EndingDate,
                request.Preview,
                request.Link
            )
        );
        return ResultToResponse(result, ToFullResponse);
    }
    [HttpGet("{id}")]
    //[Authorize] admin only
    [Produces(typeof(ActivityFullResponse))]
    public async Task<IActionResult> GetById(Guid id)
    {
        Result<ActivityDto> result = await _activityService.GetById(id);
        return ResultToResponse(result, ToFullResponse);
    }
    [HttpGet("count/offset")]
    [Produces(typeof(List<ActivityShortResponse>))]
    public async Task<IActionResult> GetAll(int count, int offset)
    {
        Result<List<ActivityDto>> result = await _activityService.GetActivities(
            new GetActivitiesCommand(count, offset)
        );
        return ResultToResponse(result, v => v.Select(ToShortResponse));
    }
    [HttpDelete("{id}")]
    //[Authorize] admin only
    public async Task<IActionResult> Delete(Guid id)
    {
        Result result = await _activityService.Delete(id);
        return ResultToResponse(result);
    }

    [NonAction]
    private static ActivityShortResponse ToShortResponse(ActivityDto dto)
    {
        return new ActivityShortResponse(
            Name: dto.Name,
            StartingDate: dto.StartingDate,
            EndingDate: dto.EndingDate,
            Preview: dto.Preview,
            Link: dto.Link
        );
    }

    [NonAction]
    private static ActivityFullResponse ToFullResponse(ActivityDto dto)
    {
        return new ActivityFullResponse(
            Id: dto.Id,
            Name: dto.Name,
            StartingDate: dto.StartingDate,
            EndingDate: dto.EndingDate,
            Preview: dto.Preview,
            Link: dto.Link,
            CreatedByAdmin: dto.CreatedByAdmin
        );
    }
}