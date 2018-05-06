using System.Collections.Generic;
using MathLibDLL.Interfaces;
using MathLibDLL.Models;
using org.mariuszgromada.math.mxparser;
using Argument = org.mariuszgromada.math.mxparser.Argument;
using Constant = MathLibDLL.Models.Constant;

namespace MathLibDLL
{
    public class MathCore:IMathCore
    {
        public MathCore()
        {
            UserFunctions=new List<IFunction>();
            UserConstants=new List<Constant>();
        }
        public List<IFunction> UserFunctions { get; }
        public List<Constant> UserConstants { get; }
        public double Calculate(IExpression expression)
        {
            var Elements = new List<PrimitiveElement>();
            Elements.AddRange(expression.Arguments
                .ConvertAll(a => new Argument($"{a.Name} = {a.Value}")));
            Elements.AddRange(UserFunctions.ConvertAll(f=>new Argument(f.GetExpression)));
            Elements.AddRange(UserConstants.ConvertAll(c=>new Argument(c.Name,c.Value)));
            Expression exp = new Expression(expression.Expression,Elements.ToArray());
            return exp.calculate();
        }

        public bool CheckExpression(IExpression expression)
        {
            var Elements = new List<PrimitiveElement>();
            Elements.AddRange(expression.Arguments
                .ConvertAll(a => new Argument($"{a.Name} = {a.Value}")));
            Elements.AddRange(UserFunctions.ConvertAll(f => new Argument(f.GetExpression)));
            Elements.AddRange(UserConstants.ConvertAll(c => new Argument(c.Name, c.Value)));
            Expression test = new Expression(expression.Expression, Elements.ToArray());
            return !test.checkSyntax();
        }

        public void AddNewFunction(IFunction function)
        {
            UserFunctions.Add(function);
        }

        public void AddNewConstant(Constant constant)
        {
            UserConstants.Add(constant);
        }

        public void AddNewConstant(string name, double value)
        {
            Constant constant=new Constant(name,value);
            UserConstants.Add(constant);
        }
    }
}