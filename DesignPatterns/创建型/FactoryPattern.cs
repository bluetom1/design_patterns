namespace DesignPatterns.创建型;

/*
 * 工厂方法模式（Factory Method）
 * 工厂方法模式的出现解决简单工厂中的难以拓展的问题，解决了其一旦添加新的产品，则需要修改简单工厂方法，进而造成简单工厂的实现逻辑过于复杂。
 * 工厂方法模式通过面向对象编程中的多态性来将对象的创建延迟到具体工厂中，把具体产品的创建推迟到子类中，
 * 此时工厂类不再负责所有产品的创建，而只是给出具体工厂必须实现的接口，工厂方法模式就可以允许系统不修改工厂类逻辑的情况下来添加新产品，
 * 也就克服了简单工厂模式中缺点。
 * 工厂方法模式也是属于创建型模式。
 *
 * 实现要点
    1．Factory Method模式的两种情况：一是Creator类是一个抽象类且它不提供它所声明的工厂方法的实现；二是Creator是一个具体的类且它提供一个工厂方法的缺省实现。
    2．工厂方法是可以带参数的。
    3．工厂的作用并不仅仅只是创建一个对象，它还可以做对象的初始化，参数的设置等。

    效果
    1．用工厂方法在一个类的内部创建对象通常比直接创建对象更灵活。
    2．Factory Method模式通过面向对象的手法，将所要创建的具体对象的创建工作延迟到了子类，从而提供了一种扩展的策略，较好的解决了这种紧耦合的关系。

    适用性 在以下情况下，适用于工厂方法模式：
    1. 当一个类不知道它所必须创建的对象的类的时候。
    2. 当一个类希望由它的子类来指定它所创建的对象的时候。
    3. 当类将创建对象的职责委托给多个帮助子类中的某一个，并且你希望将哪一个帮助子类是代理者这一信息局部化的时候。

    总结
    Factory Method模式是设计模式中应用最为广泛的模式，通过本文，相信读者已经对它有了一定的认识。然而我们要明确的是：在面向对象的编程中，对象的创建工作非常简单，对象的创建时机却很重要。Factory Method要解决的就是对象的创建时机问题，它提供了一种扩展的策略，很好地符合了开放封闭原则。
 */

/// <summary>
///     工厂方法模式（Factory Method）
/// </summary>
internal class FactoryPattern
{
    public static void Test()
    {
        LogFactory logFactory = new TxtLogFactory();
        var log = logFactory.Create();
        log.Write();
    }

    public abstract class LogFactory
    {
        public abstract Log Create();
    }

    public class TxtLogFactory : LogFactory
    {
        public override TxtLog Create()
        {
            return new TxtLog();
        }
    }

    public class DatabaseLogFactory : LogFactory
    {
        public override DatabaseLog Create()
        {
            return new DatabaseLog();
        }
    }

    public abstract class Log
    {
        public abstract void Write();
    }

    public class TxtLog : Log
    {
        public override void Write()
        {
            Console.WriteLine("TxtLog");
        }
    }

    public class DatabaseLog : Log
    {
        public override void Write()
        {
            Console.WriteLine("DatabaseLog");
        }
    }
}