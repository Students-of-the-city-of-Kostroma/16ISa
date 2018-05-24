using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathLibDLL.Interfaces;
using MathLibDLL.Models;
using System.Threading.Tasks;

namespace MathLibDLL
{
    [Obsolete("Obsolete class. Do not use it",false)]
    public class MxparserExpression : IExpression
    {
        public string Expression
        {
            set;
            get;
        }

        public List<Argument> Arguments { get; }

        public void AddArgument(Argument argument)
        {
            bool b = true;
            for (int i = 0; i < Arguments.Count; i++)
            {
                if (Arguments[i].Name == argument.Name)
                {
                    Arguments[i].Value = argument.Value;
                    b = false;
                }
            }
            if (b)
            {
                Arguments[Arguments.Count] = new Argument("", 0);
                Arguments[Arguments.Count - 1] = argument;
            }
        }
        //В методах AddArgument при нахождении совпадения по Name
        //мы заменяем в этом аргументе value, а не создаём новый с этим же именем.
        public void AddArgument(string name, double value)
        {
            bool b = true;
            for (int i = 0; i < Arguments.Count; i++)
            {
                if (Arguments[i].Name == name)
                {
                    Arguments[i].Value = value;
                    b = false;
                }
            }
            if (b)
            {
                Arguments[Arguments.Count] = new Argument(name, value);
            }
        }

        public void EditArgument(string name, double value)
        {
            for (int i = 0; i < Arguments.Count; i++)
            {
                if (Arguments[i].Name == name)
                {
                    Arguments[i].Value = value;
                    break;
                }
            }
        }

        public void RemoveArgument(string name)
        {
            for (int i = 0; i < Arguments.Count; i++)
            {
                if (Arguments[i].Name == name)
                {
                    while (Arguments[i + 1] != null)
                    {
                        Arguments[i] = Arguments[i + 1];
                        i++;
                    }
                    break;
                }
            }
        }

        public void RemoveArgument(Argument argument)
        {
            int i = 0;
            while (Arguments[i] != null)
            {
                if (Arguments[i] == argument)
                {
                    while (Arguments[i + 1] != null)
                    {
                        Arguments[i] = Arguments[i + 1];
                        i++;
                    }
                    break;
                }
                i++;
            }
        }

        public double GetArgumentValue(string name)
        {
            for (int i = 0; i < Arguments.Count; i++)
            {
                if (Arguments[i].Name == name)
                {
                    return Arguments[i].Value;
                }
            }
            return 0;
        }

        public MxparserExpression(string expression)
        {
            Expression = expression;
            Arguments = new List<Argument>();
        }
    }
}
