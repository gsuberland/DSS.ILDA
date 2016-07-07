using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSS.ILDA
{
    public interface ITrueColour
    {
        byte Red { get; set; }
        byte Green { get; set; }
        byte Blue { get; set; }
    }
}
