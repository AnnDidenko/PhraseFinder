using System;

namespace Phrase_Finder.Application.Exceptions
{
    public class InvalidAuthenticateException : Exception
    {
        public InvalidAuthenticateException() : base()
        {

        }

        public InvalidAuthenticateException(string message) : base(message)
        {

        }
    }
}
