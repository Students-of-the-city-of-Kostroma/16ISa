using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibDLL;
using MathLibDLL.Interfaces;


namespace MathLibApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string str = null;
                str = Console.ReadLine();
                if (str.Length > 50)
                {
                    Console.WriteLine("Ошибка введено более 50 символов");
                }
                else
                {
                    var math = new MathCore();
                    IExpression expression = new MxparserExpression(str);

                    if (math.CheckExpression(expression))
                    {
                        Console.WriteLine("Error");
                        return;
                    }

                    var result = math.Calculate(expression);
                    Console.WriteLine(result);
                }

            }
        }

    }
}
