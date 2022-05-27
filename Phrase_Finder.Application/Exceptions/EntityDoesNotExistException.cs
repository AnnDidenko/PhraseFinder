using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Exceptions
{
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException() : base()
        {

        }

        public EntityDoesNotExistException(string message) : base(message)
        {

        }
    }
}
