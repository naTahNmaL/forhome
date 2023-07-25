using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIM.BusinessService.Exceptions
{
    public class ProjectAlreadyExistException: Exception
    {
        public ProjectAlreadyExistException(string message) : base(message) 
        { 
        }
    }
}
