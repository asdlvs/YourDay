using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourDay.Site
{
    public class ConfirmPasswordException : Exception
    {
        public string Message
        {
            get;
            set;
        }
        public ConfirmPasswordException(string message)
        {
            this.Message = message;
        }
    }
}