using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibDLL.Models
{
    public class Argument
    {
        public string Name { set; get; }

        public double Value { set; get; }

        public Argument(string name, double value)
        {
            Name = name;
            Value = value;
        }
    }
}
