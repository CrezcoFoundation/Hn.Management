using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HN.Management.Web.Exceptions.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
