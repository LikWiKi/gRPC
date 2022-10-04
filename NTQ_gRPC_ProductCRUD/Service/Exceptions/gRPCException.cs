using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Exceptions
{
    public class gRPCException : Exception
    {
        public gRPCException()
        {
        }

        public gRPCException(string message)
            : base(message)
        {
        }

        public gRPCException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
