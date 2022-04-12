namespace DesignPatterns.行为型;

/*
 * 策略模式（Strategy Pattern）
 * 策略模式是一种对象行为模式，指对象有某个行为，但是在不同的场景中，该行为有不同的实现算法。
 * 比如每个人都要“交个人所得税”，但是 “在美国交个人所得税” 和 “在中国交个人所得税” 就有不同的算税方法。
 * 策略模式提供了替代派生的子类，并定义类的每个行为，剔除了代码中条件的判断语句，使得扩展和结合新的行为变得更容易，根本不需要变动应用程序。
 * 策略模式可以避免使用多重条件转移语句，系统变得更新灵活。应用策略模式会产生很多子类，这符合高内聚的责任分配模式。
 */

/// <summary>
///     策略模式（Strategy Pattern）
/// </summary>
internal class StrategyPattern
{
    public static void Test()
    {
        var context = new Context(new StrategyA());
        context.Do();

        context.SetStrategy(new StrategyB());
        context.Do();
    }

    public class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(Strategy strategy)
        {
            Console.WriteLine("重新设置策略......");
            _strategy = strategy;
        }

        public void Do()
        {
            Console.WriteLine("当前策略：" + _strategy.GetType().Name);
            _strategy.Handle();
        }
    }

    public abstract class Strategy
    {
        public abstract void Handle();
    }

    public class StrategyA : Strategy
    {
        public override void Handle()
        {
            Console.WriteLine("Handle in StrategyA");
        }
    }

    public class StrategyB : Strategy
    {
        public override void Handle()
        {
            Console.WriteLine("Handle in StrategyB");
        }
    }
}