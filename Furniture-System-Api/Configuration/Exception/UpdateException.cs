using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Application.Exception
{
    public class UpdateException : ApplicationException
    {
        private static string error = "Update Exception Occured";
        public UpdateException() : base(error) 
        { 
        }
    }
}
