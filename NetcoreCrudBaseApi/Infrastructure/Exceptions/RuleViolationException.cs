namespace NetcoreCrudBaseApi.Infrastructure.Exceptions;

public class RuleViolationException : Exception
{
    private RuleViolationException(string message) : base(message) { }
    private RuleViolationException(string message, Exception exception) : base(message, exception) { }

    public static RuleViolationException EmitMessage(string message) => new(message);
    public static RuleViolationException EmitMessageWithStack(string message, Exception exception) => new(message, exception);
}
