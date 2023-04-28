using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApi.Infrastructure.Auth;

public record struct AuthResponse(DateTime generatedAt, string token)
{
    public static AuthResponse emitToken(string token) => new(DateTime.Now, token);
}
