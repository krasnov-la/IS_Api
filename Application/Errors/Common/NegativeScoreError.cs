using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Errors.Common;

public class NegativeScoreError() : 
    ErrorBase(StatusCodes.Status400BadRequest, $"Score cannot be negative");