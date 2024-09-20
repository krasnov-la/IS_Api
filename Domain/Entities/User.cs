using Domain.Enums;
using FluentResults;

namespace Domain.Entities;

public class User
{
    private string _avatarImgLink;
    private string _nickname;
    private string _emailAddress;
    private string? _firstName;
    private string? _lastName;
    private string? _middleName;
    private string? _course;
    private string? _bannedBy;
    private Role _role = Role.Unverified;

    public string AvatarImgLink => _avatarImgLink;
    public string Nickname => _nickname;
    public string EmailAddress => _emailAddress;
    public string? FirstName => _firstName;
    public string? LastName => _lastName;
    public string? MiddleName => _middleName;
    public string? Course => _course;
    public string? BannedBy => _bannedBy;
    public Role Role => _role;

    private User(string emailAddress, string avatarImgLink)
    {
        var split = emailAddress.Split("@");
        _emailAddress = emailAddress;
        _avatarImgLink = avatarImgLink;
        _nickname = split[0];
        if (split.Contains("dvfu.ru"))
            _role = Role.Student;
    }

    public static User Create(
        string emailAddress,
        string avatarImgLink
    )
    {
        return new User(
            emailAddress,
            avatarImgLink
        );
    }

    public void UpdateImage(string newImage)
    {
        _avatarImgLink = newImage;
    }
    
    public void Update(
            string? nickname,
            string? firstName,
            string? lastName,
            string? middleName,
            string? course)
        {
            if (nickname is not null)
                _nickname = nickname;
            if (firstName is not null)    
                _firstName = firstName;
            if (lastName is not null)
                _lastName = lastName;
            if (middleName is not null)
                _middleName = middleName;
            if (course is not null)
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

    public Result MakeAdmin()
    {
        if (_role == Role.Banned) return Result.Fail("User banned");
        _role = Role.Admin;
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