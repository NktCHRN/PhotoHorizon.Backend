﻿namespace PhotoHorizon.Domain.Abstractions;

public interface ISoftDeletable
{
    bool IsDeleted { get; set; }
}
