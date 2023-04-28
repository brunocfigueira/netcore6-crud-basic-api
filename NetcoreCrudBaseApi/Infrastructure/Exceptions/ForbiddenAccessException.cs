using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApi.Infrastructure.Exceptions
{
    public class ForbiddenAccessException : Exception
    {
        private ForbiddenAccessException(string message) : base(message) { }
        private ForbiddenAccessException(string message, Exception exception) : base(message, exception) { }

        public static ForbiddenAccessException EmitMessage(string message) => new(message);
        public static ForbiddenAccessException EmitMessageWithStack(string message, Exception exception) => new(message, exception);
    }       
}
