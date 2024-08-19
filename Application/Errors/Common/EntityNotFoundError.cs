using Microsoft.AspNetCore.Http;

namespace Application.Errors.Common;

public class EntityNotFoundError(string entityType) : 
    ErrorBase(StatusCodes.Status404NotFound, $"Entity of type {entityType} with specified Id doesn't exist");