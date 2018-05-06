using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibDLL.Models
{
    public class Constant
    {
        public Constant(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public string Name;
        public double Value;
    }
}
