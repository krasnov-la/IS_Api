using Microsoft.AspNetCore.Http;

namespace Application.Errors.Common;

public class StatusChangeError() 
    : ErrorBase(StatusCodes.Status400BadRequest, "Request already has opposite status, use Revoke first");