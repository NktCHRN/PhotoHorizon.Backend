namespace PhotoHorizon.Domain.Exceptions;

public class EntityValidationFailedException : Exception
{
    public EntityValidationFailedException(string message) : base(message) { }

    public EntityValidationFailedException(string message, Exception inner) : base(message, inner) { }
}
