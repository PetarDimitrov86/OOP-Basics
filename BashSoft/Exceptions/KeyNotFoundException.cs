using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Exceptions
{
    public class KeyNotFoundException : Exception
    {
        private const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        public KeyNotFoundException()
            :base(NotEnrolledInCourse)
        {
            
        }

        public KeyNotFoundException(string message)
            :base(message)       
        {
            
        }
    }
}
