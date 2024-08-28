using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class NegativeScoreError() :
    ErrorBase(StatusCodes.Status400BadRequest, $"Score cannot be negative");