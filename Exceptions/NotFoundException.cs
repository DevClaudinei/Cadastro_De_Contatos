using System;

namespace ContactRegister.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string errorMessage) : base(errorMessage) { }
}