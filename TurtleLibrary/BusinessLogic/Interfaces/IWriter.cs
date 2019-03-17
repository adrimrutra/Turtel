using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleLibrary.BusinessLogic
{
    public interface IWriter
    {
        void Write(List<IState> states);
    }
}
