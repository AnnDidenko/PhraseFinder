using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() : base()
        {

        }

        public EntityAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
