using System;

namespace ContactRegister.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string errorMessage) : base(errorMessage) { }
}