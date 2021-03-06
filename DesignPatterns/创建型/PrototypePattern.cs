namespace DesignPatterns.创建型;

/*
 * 原型模式（Prototype Pattern）
 * 原型模式是用原型实例指定创建对象的种类，并且通过拷贝这些原型创建新的对象。
 * 原型模式是一种创建型设计模式。也就是用一个已经创建的实例作为原型，通过复制该原型对象来创建一个和原型相同或相似的新对象。
 * C# 提供了 ICloneable 接口，用 C# 实现原型模式很简单。
 *
 * 实现要点
    1．使用原型管理器，体现在一个系统中原型数目不固定时，可以动态的创建和销毁，如上面的举的调色板的例子。
    2．实现克隆操作，在.NET中可以使用Object类的MemberwiseClone()方法来实现对象的浅表拷贝或通过序列化的方式来实现深拷贝。
    3．Prototype模式同样用于隔离类对象的使用者和具体类型（易变类）之间的耦合关系，它同样要求这些“易变类”拥有稳定的接口。

    效果
    1．它对客户隐藏了具体的产品类，因此减少了客户知道的名字的数目。
    2．Prototype模式允许客户只通过注册原型实例就可以将一个具体产品类并入到系统中，客户可以在运行时刻建立和删除原型。
    3．减少了子类构造，Prototype模式是克隆一个原型而不是请求工厂方法创建一个，所以它不需要一个与具体产品类平行的Creater类层次。
    4．Portotype模式具有给一个应用软件动态加载新功能的能力。由于Prototype的独立性较高，可以很容易动态加载新功能而不影响老系统。
    5．产品类不需要非得有任何事先确定的等级结构，因为Prototype模式适用于任何的等级结构
    6．Prototype模式的最主要缺点就是每一个类必须配备一个克隆方法。而且这个克隆方法需要对类的功能进行通盘考虑，这对全新的类来说不是很难，但对已有的类进行改造时，不一定是件容易的事。

    适用性 在下列情况下，应当使用Prototype模式：
    1．当一个系统应该独立于它的产品创建，构成和表示时；
    2．当要实例化的类是在运行时刻指定时，例如，通过动态装载；
    3．为了避免创建一个与产品类层次平行的工厂类层次时；
    4．当一个类的实例只能有几个不同状态组合中的一种时。建立相应数目的原型并克隆它们可能比每次用合适的状态手工实例化该类更方便一些。

    总结
    Prototype模式同工厂模式，同样对客户隐藏了对象的创建工作，但是，与通过对一个类进行实例化来构造新对象不同的是，原型模式是通过拷贝一个现有对象生成新对象的，达到了“隔离类对象的使用者和具体类型（易变类）之间的耦合关系”的目的。
 */

/// <summary>
///     原型模式（Prototype Pattern）
/// </summary>
internal class PrototypePattern
{
    public static void Test()
    {
        var xiaowang = new Person { Name = "xiaowang", Age = 20 };
        var xiaowangClone = (Person)xiaowang.Clone();
        var xiaoming = Person.CreateInstancePrototype();

        Console.WriteLine(xiaowang.Name);
        Console.WriteLine(xiaowang.GetHashCode());
        Console.WriteLine(xiaowangClone.Name);
        Console.WriteLine(xiaowangClone.GetHashCode());
        Console.WriteLine(xiaoming.Name);
        Console.WriteLine(xiaoming.GetHashCode());
    }

    public class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        private static readonly Person person = new()
        {
            Name = "xiaoming",
            Age = 18
        };

        /// <summary>
        ///     浅拷贝
        /// </summary>
        /// <returns></returns>
        public static Person CreateInstancePrototype()
        {
            return (Person)person.MemberwiseClone();
        }

        public object Clone()
        {
            return new Person { Name = Name, Age = Age };
        }
    }
}