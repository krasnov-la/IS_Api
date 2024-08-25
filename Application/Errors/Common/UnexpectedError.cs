using Microsoft.AspNetCore.Http;

namespace Application.Errors.Common;

public class UnexpectedError() : 
    ErrorBase(StatusCodes.Status500InternalServerError, "Unexpected error occured");