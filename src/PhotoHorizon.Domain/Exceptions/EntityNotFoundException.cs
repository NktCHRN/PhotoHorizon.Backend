﻿namespace PhotoHorizon.Domain.Exceptions;

public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message) : base(message) { }

    public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }
}
