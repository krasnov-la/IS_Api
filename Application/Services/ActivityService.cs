using System.Security.Claims;
using Application.Commands.Activities;
using Application.DTO;
using Application.Errors.Common;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using FluentResults;

namespace Application.Services;

public class ActivityService(IActivityRepository activityRepo, IImageRepository imageRepository) : ServiceBase, IActivityService
{
    private readonly IActivityRepository _activityRepo = activityRepo;
    private readonly IImageRepository _imageRepository = imageRepository;
    public async Task<Result<ActivityDto>> Create(NewActivityCommand command)
    {
        if (!_imageRepository.ValidateImage(new Guid(command.Preview)))
            return Result.Fail(new ImageInvalidError(new Guid(command.Preview)));
        var activity = Activity.Create(
            command.Name,
            new Admin(ExtractEmail(command.User)),
            command.StartimgDate,
            command.EndingDate,
            new Image(new Guid(command.Preview)),
            command.Link);

        Result savingResult = await _activityRepo.Create(activity);

        if (savingResult.IsFailed) return savingResult;
        return Result.Ok(ToDto(activity));
    }

    public async Task<Result> Delete(Guid id)
    {
        return await _activityRepo.DeleteById(id);
    }

    public async Task<Result<List<ActivityDto>>> GetActivities(GetActivitiesCommand command)
    {
        Result<IEnumerable<Activity>> result = await _activityRepo.Get(command.Count, command.Offset);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return Result.Ok(result.Value.Select(ToDto).ToList());
    }

    public async Task<Result<ActivityDto>> GetById(Guid id)
    {
        Result<Activity?> result = await _activityRepo.GetById(id);
        if (result.IsFailed) return Result.Fail(result.Errors);
        if (result.Value is null) return Result.Fail(
            new EntityNotFoundError("Activity"));
        return Result.Ok(ToDto(result.Value));
    }

    public async Task<Result<ActivityDto>> Update(UpdateActivityCommand command)
    {
        if (command.Preview is not null && !_imageRepository.ValidateImage(new Guid(command.Preview)))
            return Result.Fail(new ImageInvalidError(new Guid(command.Preview)));
        Result<Activity?> result = await _activityRepo.GetById(command.Id);
        if (result.IsFailed) return Result.Fail(result.Errors);
        if (result.Value is null) return Result.Fail(
            new EntityNotFoundError("Activity"));

        var activity = result.Value;

        activity.Update(
            new Admin(ExtractEmail(command.User)),
            command.Name,
            command.StartimgDate,
            command.EndingDate,
            command.Preview is null ? null : new Image(new Guid(command.Preview)),
            command.Link
        );

        Result updateResult = await _activityRepo.Update(activity);
        
        if (updateResult.IsFailed) return updateResult;
        return Result.Ok(ToDto(activity));
    }

    private static ActivityDto ToDto(Activity activity)
    {
        return new ActivityDto(
            activity.Id,
            activity.Name,
            activity.Start,
            activity.Finish,
            activity.Preview.Guid.ToString(),
            activity.Link,
            activity.Admin.EmailAddress
        );
    }
}
