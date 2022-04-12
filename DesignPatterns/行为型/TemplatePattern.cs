namespace DesignPatterns.行为型;

/*
 * 模板模式（Template Pattern）
 * 模板方法模式定义了一个算法的步骤，并允许子类为一个或多个步骤提供其实现方式。
 * 让子类别在不改变算法架构的情况下，重新定义算法中的某些步骤。
 * 模板方法模式是比较简单的一种设计模式，作为模板的方法要定义在父类中，在方法的定义中使用到抽象方法，而只看父类的抽象方法是根本不知道怎样处理的，
 * 实际做具体处理的是子类，在子类中实现具体功能，因此不同的子类执行将会得出不同的实现结果，但是处理流程还是按照父类定制的方式。
 * 这就是模板方法的要义所在，制定算法骨架，让子类具体实现。
 * 模板方法设计模式是一种行为型模式。
 */

/// <summary>
///     模板模式（Template Pattern）
/// </summary>
internal class TemplatePattern
{
    public static void Test()
    {
        Template t = new Method1();
        t.Run("如何把大象装进冰箱？");

        Console.WriteLine();

        t = new Method2();
        t.Run("1987年4月，邓小平同志提出了新的“三步走”构想。据此，党的十三大正式确定了中国现代化建设“三步走”的发展战略");
    }

    public abstract class Template
    {
        public abstract void Step1();
        public abstract void Step2();
        public abstract void Step3();

        public void Run(string message)
        {
            Console.WriteLine(message);

            Step1();
            Step2();
            Step3();
        }
    }

    public class Method1 : Template
    {
        public override void Step1()
        {
            Console.WriteLine("打开冰箱门");
        }

        public override void Step2()
        {
            Console.WriteLine("把大象放进去");
        }

        public override void Step3()
        {
            Console.WriteLine("关上冰箱门");
        }
    }

    public class Method2 : Template
    {
        public override void Step1()
        {
            Console.WriteLine("第一步，从1981年到1990年国民生产总值翻一番，实现温饱；");
        }

        public override void Step2()
        {
            Console.WriteLine("第二步，从1991年到20世纪末再翻一番，达到小康；");
        }

        public override void Step3()
        {
            Console.WriteLine("第三步，到21世纪中叶再翻两番，达到中等发达国家水平。");
        }
    }
}