using Application.Commands.Users;
using Application.DTO;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Domain.Enums;
using FluentResults;

namespace Application.Services;

public class UserService(IUserRepository userRepository) : ServiceBase, IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<Result> Ban(BanUserCommand command)
    {
        //TODO: Validate 
        Result<User> result = await _userRepository.GetByEmail(command.Email);
        if (result.IsFailed) return Result.Fail(result.Errors);
        var user = result.Value;

        user.Ban(new Admin(ExtractEmail(command.User)));

        return await _userRepository.Update(user);
    }

    public async Task<Result<UserDto>> GetByMail(string email)
    {
        Result<User> result = await _userRepository.GetByEmail(email);
        if (result.IsFailed) return Result.Fail(result.Errors);
        return Result.Ok(ToDto(result.Value));
    }

    public async Task<Result> Unban(BanUserCommand command)
    {
        //TODO: Validate 
        Result<User> result = await _userRepository.GetByEmail(command.Email);
        if (result.IsFailed) return Result.Fail(result.Errors);
        var user = result.Value;

        user.Unban(new Admin(ExtractEmail(command.User)));

        return await _userRepository.Update(user);
    }

    public async Task<Result<UserDto>> Update(UpdateUserCommand command)
    {
        //TODO: Validate all
        Result<User> result = await _userRepository.GetByEmail(ExtractEmail(command.User));
        if (result.IsFailed) return Result.Fail(result.Errors);
        var user = result.Value;

        user.Update(
            command.Nickname,
            command.FirstName,
            command.LastName,
            command.MiddleName,
            command.Course
        );

        return await _userRepository.Update(user);
    }

    public async Task<Result> Verify(UserVerificationCommand command)
    {
        //TODO: Validate role
        Result<User> result = await _userRepository.GetByEmail(command.Email);
        if (result.IsFailed) return Result.Fail(result.Errors);
        var user = result.Value;

        user.Verify(command.Role);

        return await _userRepository.Update(user);
    }

    private static UserDto ToDto(User user)
    {
        return new UserDto(
            user.AvatarImgLink,
            user.Nickname,
            user.EmailAddress,
            user.FirstName,
            user.LastName,
            user.MiddleName,
            user.Role.ToString(),
            user.Course,
            user.BannedBy
        );
    }
}