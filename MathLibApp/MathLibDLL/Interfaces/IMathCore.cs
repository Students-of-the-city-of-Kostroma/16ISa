using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibDLL.Models;

namespace MathLibDLL.Interfaces
{
    /// <summary>
    /// Математическое ядро библиотеки - отвечает за основные операции
    /// </summary>
    public interface IMathCore
    {
        /// <summary>
        /// Список пользовательских функций которые могут быть использованы в математическом выражении
        /// </summary>
        List<IFunction> UserFunctions { get; }

        /// <summary>
        /// Пользовательские константы, используемые при вычислении выражений
        /// </summary>
        List<Constant> UserConstants { get; }

        /// <summary>
        /// Вычислить значение выражения
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns>Полученное значение</returns>
        double Calculate(IExpression expression);

        /// <summary>
        /// Проверить правильность выражения
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns>Есть ошибка \ нет</returns>
        bool CheckExpression(IExpression expression);

        /// <summary>
        /// Добавить новую пользовательскую функцию
        /// </summary>
        /// <param name="function">Функция</param>
        void AddNewFunction(IFunction function);

        /// <summary>
        /// Добавить новую пользовательскую константу
        /// </summary>
        /// <param name="constant">Константа</param>
        void AddNewConstant(Constant constant);

        /// <summary>
        /// Добавить новую пользовательскую константу
        /// </summary>
        /// <param name="name">Имя константы</param>
        /// <param name="value">Значение константы</param>
        void AddNewConstant(string name, double value);
    }
}
