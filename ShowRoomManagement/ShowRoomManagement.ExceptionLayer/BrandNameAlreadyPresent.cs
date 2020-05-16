using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomManagement.ExceptionLayer
{
    public class BrandNameAlreadyPresent : Exception
    {
        public BrandNameAlreadyPresent(string message) : base(message)
        {

        }

    }
}
