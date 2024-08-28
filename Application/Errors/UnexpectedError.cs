using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class UnexpectedError() :
    ErrorBase(StatusCodes.Status500InternalServerError, "Unexpected error occured");