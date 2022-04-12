namespace DesignPatterns.结构型;

/*
 * 装饰者模式（Decorator Pattern）
 * 装饰者模式是指的是在不必改变原类文件和使用继承的情况下，动态地扩展一个对象的功能。
 * 它是通过创建一个包装对象，也就是装饰来包裹真实的对象。也是一种结构型模式。
 * 装饰对象和真实对象有相同的接口。这样客户端对象就能以和真实对象相同的方式和装饰对象交互。
 * 装饰对象包含一个真实对象的引用（reference）。
 * 装饰对象接受所有来自客户端的请求。它把这些请求转发给真实的对象。
 * 装饰对象可以在转发这些请求以前或以后增加一些附加功能。这样就确保了在运行时，不用修改给定对象的结构就可以在外部增加附加的功能。
 * 在面向对象的设计中，通常是通过继承来实现对给定类的功能扩展。设计原则就是多组合，少继承。
 *
 * 效果及实现要点
    1．Component类在Decorator模式中充当抽象接口的角色，不应该去实现具体的行为。而且Decorator类对于Component类应该透明，换言之Component类无需知道Decorator类，Decorator类是从外部来扩展Component类的功能。
    2．Decorator类在接口上表现为is-a Component的继承关系，即Decorator类继承了Component类所具有的接口。但在实现上又表现为has-a Component的组合关系，即Decorator类又使用了另外一个Component类。我们可以使用一个或者多个Decorator对象来“装饰”一个Component对象，且装饰后的对象仍然是一个Component对象。
    3．Decortor模式并非解决“多子类衍生的多继承”问题，Decorator模式的应用要点在于解决“主体类在多个方向上的扩展功能”——是为“装饰”的含义。
    4．对于Decorator模式在实际中的运用可以很灵活。如果只有一个ConcreteComponent类而没有抽象的Component类，那么Decorator类可以是ConcreteComponent的一个子类。如果只有一个ConcreteDecorator类，那么就没有必要建立一个单独的Decorator类，而可以把Decorator和ConcreteDecorator的责任合并成一个类。
    5．Decorator模式的优点是提供了比继承更加灵活的扩展，通过使用不同的具体装饰类以及这些装饰类的排列组合，可以创造出很多不同行为的组合。
    6．由于使用装饰模式，可以比使用继承关系需要较少数目的类。使用较少的类，当然使设计比较易于进行。但是，在另一方面，使用装饰模式会产生比使用继承关系更多的对象。更多的对象会使得查错变得困难，特别是这些对象看上去都很相像。

    适用性 在以下情况下应当使用装饰模式：
    1.需要扩展一个类的功能，或给一个类增加附加责任。
    2.需要动态地给一个对象增加功能，这些功能可以再动态地撤销。
    3.需要增加由一些基本功能的排列组合而产生的非常大量的功能，从而使继承关系变得不现实。

    总结
    Decorator模式采用对象组合而非继承的手法，实现了在运行时动态的扩展对象功能的能力，而且可以根据需要扩展多个功能，避免了单独使用继承带来的“灵活性差”和“多子类衍生问题”。同时它很好地符合面向对象设计原则中“优先使用对象组合而非继承”和“开放-封闭”原则。
 */

/// <summary>
///     装饰者模式（Decorator Pattern）
/// </summary>
internal class DecoratorPattern
{
    public static void Test()
    {
        Log log = new LogDatabase();
        log.Write();

        Console.WriteLine("================================================================");

        log = new LogDatabaseDecorator(log);
        log.Write();

        Console.ReadKey();
    }

    private abstract class Log
    {
        public abstract void Write();
    }

    private class LogDatabase : Log
    {
        public override void Write()
        {
            Console.WriteLine("执行主方法");
        }
    }

    private abstract class LogDecorator : Log
    {
        private readonly Log _log;

        protected LogDecorator(Log log)
        {
            _log = log;
        }

        public override void Write()
        {
            _log.Write();
        }
    }

    private class LogDatabaseDecorator : LogDecorator
    {
        public LogDatabaseDecorator(Log log) : base(log)
        {
        }

        public override void Write()
        {
            Console.WriteLine("装饰器-执行主方法前");
            base.Write();
            Console.WriteLine("装饰器-执行主方法后");
        }
    }
}