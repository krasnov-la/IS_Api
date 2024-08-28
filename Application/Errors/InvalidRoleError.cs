using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class InvalidRoleError(Role role) :
    ErrorBase(StatusCodes.Status400BadRequest, $"Role {role} cannot be used in this context");