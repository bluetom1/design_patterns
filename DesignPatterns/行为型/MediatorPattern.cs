namespace DesignPatterns.行为型;

/*
 * 中介者模式（Mediator Pattern）
 * 中介者模式是一种行为型模式，用一个中介对象来封装一系列对象的交互，从而把一批原来可能是交互关系复杂的对象转换成一组松散耦合的中间对象，以有利于维护和修改。
 * 中介者模式分离了两个同事类，简化了对象协议，中央控制对象交互，从而使个体对象变得更容易且更简单，它不需要传递数据给其他个体对象，仅需要传给中介者即可。
 * 个体对象不需要具有处理内部交流的逻辑，则更加突出它的面向对象特性。
 * 通过使用中介者模式，具体的同事类可以独立变化，通过引用中介者可以简化同事类的设计和实现。
 */

/// <summary>
///     中介者模式（Mediator Pattern）
/// </summary>
internal class MediatorPattern
{
    public static void Test()
    {
        //房主、租房者、中介机构
        var mediator = new ConcreteMediator();

        //房主和租房者只需中介机构即可
        var houseOwner = new HouseOwner("张三", mediator);
        var tenant = new Tenant("李四", mediator);

        //中介结构要知道房主和租房者
        mediator.HouseOwner = houseOwner;
        mediator.Tenant = tenant;

        //通过中介进行交互
        tenant.Contact("我想要租房，你那里有三室的房主出租吗？");
        houseOwner.Contact("是的！如果有需要今天就可以看房。");
    }

    /// <summary>
    ///     中介者抽象
    /// </summary>
    public abstract class Mediator
    {
        public abstract void Contact(string message, Person person);
    }

    /// <summary>
    ///     中介者实现
    /// </summary>
    public class ConcreteMediator : Mediator
    {
        public Tenant Tenant { get; set; }
        public HouseOwner HouseOwner { get; set; }

        public override void Contact(string message, Person person)
        {
            if (person == Tenant)
            {
                //租房者获得信息
                Tenant.GetMessage(message);
            }
            else
            {
                //房主获得信息
                HouseOwner.GetMessage(message);
            }
        }
    }

    public abstract class Person
    {
        protected string Name { get; set; }
        protected Mediator Mediator { get; set; }

        protected Person(string name, Mediator mediator)
        {
            Name = name;
            Mediator = mediator;
        }
    }

    public class HouseOwner : Person
    {
        public HouseOwner(string name, Mediator mediator) : base(name, mediator)
        {
        }

        public void Contact(string message)
        {
            Mediator.Contact(message, this);
        }

        public void GetMessage(string message)
        {
            Console.WriteLine("房主：" + Name + "，发布信息：" + message);
        }
    }

    public class Tenant : Person
    {
        public Tenant(string name, Mediator mediator) : base(name, mediator)
        {
        }

        public void Contact(string message)
        {
            Mediator.Contact(message, this);
        }

        public void GetMessage(string message)
        {
            Console.WriteLine("租房者：" + Name + "，发布信息：" + message);
        }
    }
}