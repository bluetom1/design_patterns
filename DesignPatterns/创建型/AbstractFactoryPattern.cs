namespace DesignPatterns.创建型;

/*
 * 抽象工厂模式（Abstract Factory Pattern）
 * 抽象工厂模式是一个超级工厂创建其他工厂。该超级工厂又称为其他工厂的工厂。
 * 这种类型的设计模式属于创建型模式，它提供了一种创建对象的最佳方式。
 * 工厂方法模式是为了克服简单工厂模式的缺点而设计出来的，简单工厂模式的工厂类着产品类的增加需要增加额外的代码，
 * 而工厂方法模式每个具体工厂类只完成单个实例的创建,它具有很好的可扩展性。
 * 但是在现实生活中，一个工厂只创建单个产品比较少，工厂都多元化，一个工厂创建一系列的产品，
 * 如果我们要设计这样的系统时，工厂方法模式就不太适用，而使用抽象工厂模式却可以很好地解决。
 *
 * 实现要点
    l.抽象工厂将产品对象的创建延迟到它的具体工厂的子类。
    l.如果没有应对“多系列对象创建”的需求变化，则没有必要使用抽象工厂模式，这时候使用简单的静态工厂完全可以。
    l.系列对象指的是这些对象之间有相互依赖、或作用的关系，例如游戏开发场景中的“道路”与“房屋”的依赖，“道路”与“地道”的依赖。
    l.抽象工厂模式经常和工厂方法模式共同组合来应对“对象创建”的需求变化。
    l.通常在运行时刻创建一个具体工厂类的实例，这一具体工厂的创建具有特定实现的产品对象，为创建不同的产品对象，客户应使用不同的具体工厂。
    l.把工厂作为单件，一个应用中一般每个产品系列只需一个具体工厂的实例，因此，工厂通常最好实现为一个单件模式。
    l.创建产品，抽象工厂仅声明一个创建产品的接口，真正创建产品是由具体产品类创建的，最通常的一个办法是为每一个产品定义一个工厂方法，一个具体的工厂将为每个产品重定义该工厂方法以指定产品，虽然这样的实现很简单，但它确要求每个产品系列都要有一个新的具体工厂子类，即使这些产品系列的差别很小。

    优点
    l.分离了具体的类。抽象工厂模式帮助你控制一个应用创建的对象的类，因为一个工厂封装创建产品对象的责任和过程。它将客户和类的实现分离，客户通过他们的抽象接口操纵实例，产品的类名也在具体工厂的实现中被分离，它们不出现在客户代码中。
    l.它使得易于交换产品系列。一个具体工厂类在一个应用中仅出现一次——即在它初始化的时候。这使得改变一个应用的具体工厂变得很容易。它只需改变具体的工厂即可使用不同的产品配置，这是因为一个抽象工厂创建了一个完整的产品系列，所以整个产品系列会立刻改变。
    l.它有利于产品的一致性。当一个系列的产品对象被设计成一起工作时，一个应用一次只能使用同一个系列中的对象，这一点很重要，而抽象工厂很容易实现这一点。

    缺点
    l.难以支持新种类的产品。难以扩展抽象工厂以生产新种类的产品。这是因为抽象工厂几口确定了可以被创建的产品集合，支持新种类的产品就需要扩展该工厂接口，这将涉及抽象工厂类及其所有子类的改变。

    适用性 在以下情况下应当考虑使用抽象工厂模式：
    l.一个系统不应当依赖于产品类实例如何被创建、组合和表达的细节，这对于所有形态的工厂模式都是重要的。
    l.这个系统有多于一个的产品族，而系统只消费其中某一产品族。
    l.同属于同一个产品族的产品是在一起使用的，这一约束必须在系统的设计中体现出来。
    l.系统提供一个产品类的库，所有的产品以同样的接口出现，从而使客户端不依赖于实现。

    应用场景
    l.支持多种观感标准的用户界面工具箱（Kit）。
    l.游戏开发中的多风格系列场景，比如道路，房屋，管道等。

    总结
    抽象工厂模式提供了一个创建一系列相关或相互依赖对象的接口，运用抽象工厂模式的关键点在于应对“多系列对象创建”的需求变化。一句话，学会了抽象工厂模式，你将理解OOP的精华：面向接口编程。
 */

/// <summary>
///     抽象工厂模式（Abstract Factory Pattern）
/// </summary>
internal class AbstractFactoryPattern
{
    public static void Test()
    {
        Factory factory = new TxtLogFactory();
        var log = factory.CreateLog();
        var nlog = factory.CreateNLog();

        log.Write();
        nlog.Write();
    }

    public abstract class Factory
    {
        public abstract Log CreateLog();
        public abstract NLog CreateNLog();
    }

    public class TxtLogFactory : Factory
    {
        public override Log CreateLog()
        {
            return new TxtLog();
        }

        public override NLog CreateNLog()
        {
            return new TxtNLog();
        }
    }

    public class DatabaseLogFactory : Factory
    {
        public override Log CreateLog()
        {
            return new DatabaseLog();
        }

        public override NLog CreateNLog()
        {
            return new DatabaseNLog();
        }
    }

    public abstract class Log
    {
        public abstract void Write();
    }

    public abstract class NLog
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

    public class TxtNLog : NLog
    {
        public override void Write()
        {
            Console.WriteLine("TxtNLog");
        }
    }

    public class DatabaseNLog : NLog
    {
        public override void Write()
        {
            Console.WriteLine("DatabaseNLog");
        }
    }
}