using Microsoft.AspNetCore.Http;

namespace Application.Errors.Common;
public class PaginationError() : 
    ErrorBase(StatusCodes.Status400BadRequest, "Count and offset should be positive");