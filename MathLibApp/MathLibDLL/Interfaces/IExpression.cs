using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibDLL.Models;

namespace MathLibDLL.Interfaces
{
    /// <summary>
    /// Математическое выражение используемое для вычислений
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// Строка математического выражения
        /// </summary>
        string Expression { set; get; }

        /// <summary>
        /// Аргументы используемые в выражении
        /// </summary>
        List<Argument> Arguments { get; }

        /// <summary>
        /// Добавить новый аргумент
        /// </summary>
        /// <param name="argument">Аргумент</param>
        void AddArgument(Argument argument);

        /// <summary>
        /// Добавить новый аргумент
        /// </summary>
        /// <param name="name">Имя аргумента</param>
        /// <param name="value">Значения аргумента</param>
        void AddArgument(string name, double value);

        /// <summary>
        /// Измениить значение аргумента
        /// </summary>
        /// <param name="name">Имя аргумента</param>
        /// <param name="value">Новое значение аргумента</param>
        void EditArgument(string name, double value);

        /// <summary>
        /// Удалить аргумент из списка
        /// </summary>
        /// <param name="name">Имя аргумента</param>
        void RemoveArgument(string name);

        /// <summary>
        /// Удалить аргумент из списка
        /// </summary>
        /// <param name="argument">Аргумент</param>
        void RemoveArgument(Argument argument);

        /// <summary>
        /// Получить значение аргумента по имени
        /// </summary>
        /// <param name="name">Имя аргумента</param>
        /// <returns>Значние</returns>
        double GetArgumentValue(string name);
    }
}
