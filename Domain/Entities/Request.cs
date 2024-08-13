using Domain.Enums;
using FluentResults;

namespace Domain.Entities;

public class Request
{
    private readonly Guid _id;
    private readonly Student _student;
    private readonly List<Image> _images;
    private readonly string _eventName;
    private readonly string _description;
    private readonly DateTime _createdAt;
    private RequestStatus _status;
    private Achievement? _achievement = null;
    private Comment? _comment = null;
    private Request(Student student, string eventName, string description, List<Image> images)
    {
        _id = Guid.NewGuid();
        _student = student;
        _images = images;
        _eventName = eventName;
        _description = description;
        _createdAt = DateTime.Now;
        _status = RequestStatus.InProgress;
    }
    public static Request Create(Student student, string eventName, string description,  List<Image> images)
    {
        return new Request(student, eventName, description, images);
    }
    public Result Reject(Admin admin, string message)
    {
        if (_status != RequestStatus.InProgress)
            return Result.Fail("Request already approved");
        _comment = Comment.Create(admin, message);
        _status = RequestStatus.Rejected;
        return Result.Ok();
    }

    public Result Approve(Admin admin, float score)
    {
        if (_status != RequestStatus.InProgress)
            return Result.Fail("Request already rejected");
        _achievement = new Achievement(admin, score);
        _status = RequestStatus.Approved;
        return Result.Ok();
    }

    public void Revoke()
    {
        _achievement = null;
        _comment = null;
        _status = RequestStatus.InProgress;     
    }
}