namespace DesignPatterns.行为型;

/*
 * 解释器模式（Interpreter Pattern）
 * 解释器模式是一种行为型模式，定义了一个解释器，来解释给定语言和文法的句子。
 * 其实质是把语言中的每个符号定义成一个（对象）类，从而把每个程序转换成一个具体的对象树。
 * 解释器模式的作用很强大，它使得改变和扩展文法变得容易，很多编译器，包括文本编辑器、网页浏览器及VRML都应用解释器模式。
 * 因文句会分析成树结构，解释器需要递归访问它，则效率会受影响。程序开发时会有所体会，编译整个工程源码耗费时间都比较长。
 */

/// <summary>
///     解释器模式（Interpreter Pattern）
/// </summary>
internal class InterpreterPattern
{
    public static void Test()
    {
        var isMarriedWoman = GetMarriedWomanExpression();
        Console.WriteLine("Julie is a married women? " + isMarriedWoman.Interpret("Married Julie"));
    }

    /// <summary>
    ///     规则：Julie 是一个已婚的女性
    /// </summary>
    /// <returns></returns>
    public static IExpression GetMarriedWomanExpression()
    {
        IExpression julie = new TerminalExpression("Julie");
        IExpression married = new TerminalExpression("Married");
        return new AndExpression(julie, married);
    }

    public interface IExpression
    {
        bool Interpret(string context);
    }

    public class TerminalExpression : IExpression
    {
        private readonly string data;

        public TerminalExpression(string data)
        {
            this.data = data;
        }

        public bool Interpret(string context)
        {
            return context.Contains(data);
        }
    }

    public class AndExpression : IExpression
    {
        private readonly IExpression expr1;
        private readonly IExpression expr2;

        public AndExpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool Interpret(string context)
        {
            return expr1.Interpret(context) && expr2.Interpret(context);
        }
    }
}