﻿namespace Entities.Exceptions.BadRequest;

public class BadRequestException : Exception
{
    public BadRequestException(string message)
        : base(message)
    { }
}