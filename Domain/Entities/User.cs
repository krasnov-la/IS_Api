using Domain.Enums;
using FluentResults;

namespace Domain.Entities;

public class User
{
    private string? _avatarImgLink;
    private string? _nickname;
    private string _emailAddress;
    private string? _firstName;
    private string? _lastName;
    private string? _middleName;
    private string? _course;
    private string? _bannedBy;

    public Role _role = Role.Unverified;

    public string? AvatarImgLink => _avatarImgLink;
    public string? Nickname => _nickname;
    public string EmailAddress => _emailAddress;
    public string? FirstName => _firstName;
    public string? LastName => _lastName;
    public string? MiddleName => _middleName;
    public string? Course => _course;
    public string? BannedBy => _bannedBy;
    public Role Role => _role;

    private User(string emailAddress, string avatarImgLink)
    {
        _emailAddress = emailAddress;
        _avatarImgLink = avatarImgLink;
    }

    public static User Create(
        string avatarImgLink,
        string emailAddress
    )
    {
        return new User(
            avatarImgLink,
            emailAddress
        );
    }

    public void Update(
            string? nickname,
            string? firstName,
            string? lastName,
            string? middleName,
            string? course)
        {
            _nickname = nickname;
            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;
            _course = course;
        }

    public Result Verify(Role role)
    {
        if (_role != Role.Unverified) return Result.Fail("User already verified");
        if (_nickname is null || _firstName is null || _lastName is null || _middleName is null ||
            (role == Role.Student && _course is null))
            return Result.Fail("Data insufficient");
        if (_role == Role.Banned) return Result.Fail("User banned");
        _role = role;
        return Result.Ok();
    }

    public void Ban(Admin admin)
    {
        _bannedBy = admin.EmailAddress;
        _role = Role.Banned;
    }

    public void Unban(Admin admin)
    {
        _bannedBy = admin.EmailAddress;
        _role = Role.Unverified;
    }
}