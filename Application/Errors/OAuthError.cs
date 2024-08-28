using Microsoft.AspNetCore.Http;

namespace Application.Errors;

public class OAuthError() : ErrorBase(StatusCodes.Status417ExpectationFailed,
    "Could not get oAuth data, oAuth token invalid, or Yandex server not responding");