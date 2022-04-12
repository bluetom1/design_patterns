namespace DesignPatterns.结构型;

/*
 * 外观模式（Facade Pattern）
 * 外观模式提供了一个简单且公用的接口去处理复杂的子系统，并且没有减少子系统的功能。
 * 降低子系统的复杂性，避免了客户与子系统直接链接，它也减少了子系统与子系统间的连接，每个子系统都有它的Facade模式，每个子系统采用Facade模式去访问其他子系统。
 * 这个外观类为子系统提供一个共同的对外接口，客户对象通过一个外观接口读写子系统中各接口的数据资源。
 * 外观模式的缺点是限制了客户的自由，减少了可变性。
 * 也是一种结构型模式。
 *
 * 效果及实现要点
    1．Façade模式对客户屏蔽了子系统组件，因而减少了客户处理的对象的数目并使得子系统使用起来更加方便。
    2．Façade模式实现了子系统与客户之间的松耦合关系，而子系统内部的功能组件往往是紧耦合的。松耦合关系使得子系统的组件变化不会影响到它的客户。
    3．如果应用需要，它并不限制它们使用子系统类。因此你可以在系统易用性与通用性之间选择。

    适用性
    1．为一个复杂子系统提供一个简单接口。
    2．提高子系统的独立性。
    3．在层次化结构中，可以使用Facade模式定义系统中每一层的入口。

    总结
    Façade模式注重的是简化接口，它更多的时候是从架构的层次去看整个系统，而并非单个类的层次。
 */

/// <summary>
///     外观模式（Facade Pattern）
/// </summary>
internal class FacadePattern
{
    public static void Test()
    {
        var facade = new Facade();
        facade.method();
    }

    public class Facade
    {
        //被委托的对象
        private readonly SubSystemA a;
        private readonly SubSystemB b;

        public Facade()
        {
            a = new SubSystemA();
            b = new SubSystemB();
        }

        //提供给外部访问的方法
        public void method()
        {
            a.dosomethingA();
            b.dosomethingB();
        }
    }

    public class SubSystemA
    {
        public void dosomethingA()
        {
            Console.WriteLine("子系统方法A");
        }
    }

    public class SubSystemB
    {
        public void dosomethingB()
        {
            Console.WriteLine("子系统方法B");
        }
    }
}