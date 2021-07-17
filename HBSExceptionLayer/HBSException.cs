using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBSExceptionLayer
{
    public class HBSException : ApplicationException
    {
        public HBSException()
                  : base()
        { }

        public HBSException(string message)
            : base(message)
        { }

    }
}
