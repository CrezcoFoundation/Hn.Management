using System;

namespace HN.Management.Manager.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base("Forbidden")
        {
        }

        public ForbiddenException(string message) : base(message)
        {
        }
    }
}
