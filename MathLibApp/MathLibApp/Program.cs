using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibDLL.Interfaces;
using MathLibDLL.Models;
using MathLibDLL;

namespace MathLibApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = null;
            str = Console.ReadLine();
            if (str.Length > 50)
            {
                Console.WriteLine("Ошибка введено более 50 символов");
            }
            else
            {
                MathCore a = new MathCore();
                a.Calculate(str);


            }
        }
    }
}
