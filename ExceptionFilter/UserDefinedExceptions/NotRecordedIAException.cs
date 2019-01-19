using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionFilter.UserDefinedExceptions
{
    public class NotRecordedIAException : Exception
    {
        public NotRecordedIAException(string value) : base(value) { }
    }
}
