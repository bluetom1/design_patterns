namespace DesignPatterns.结构型;

/*
 * 代理模式（Proxy Pattern）
 * 代理模式是一种结构型模式，为其他对象提供一种代理以控制对这个对象的访问。
 * 在某些情况下，一个对象不适合或者不能直接引用另一个对象，而代理对象可以在客户端和目标对象之间起到中介的作用。
 * 代理模式又叫委托模式，是为某个对象提供一个代理对象，并且由代理对象控制对原对象的访问。
 * 代理模式通俗来讲就是我们生活中常见的中介。
 *
 * 效果及实现要点
    Proxy模式根据种类不同，效果也不尽相同：
    1．远程（Remote）代理：为一个位于不同的地址空间的对象提供一个局域代表对象。这个不同的地址空间可以是在本机器中，也可是在另一台机器中。远程代理又叫做大使（Ambassador）。好处是系统可以将网络的细节隐藏起来，使得客户端不必考虑网络的存在。客户完全可以认为被代理的对象是局域的而不是远程的，而代理对象承担了大部份的网络通讯工作。由于客户可能没有意识到会启动一个耗费时间的远程调用，因此客户没有必要的思想准备。
    2．虚拟（Virtual）代理：根据需要创建一个资源消耗较大的对象，使得此对象只在需要时才会被真正创建。使用虚拟代理模式的好处就是代理对象可以在必要的时候才将被代理的对象加载；代理可以对加载的过程加以必要的优化。当一个模块的加载十分耗费资源的情况下，虚拟代理的好处就非常明显。
    3．Copy-on-Write代理：虚拟代理的一种。把复制（克隆）拖延到只有在客户端需要时，才真正采取行动。
    4．保护（Protect or Access）代理：控制对一个对象的访问，如果需要，可以给不同的用户提供不同级别的使用权限。保护代理的好处是它可以在运行时间对用户的有关权限进行检查，然后在核实后决定将调用传递给被代理的对象。
    5．Cache代理：为某一个目标操作的结果提供临时的存储空间，以便多个客户端可以共享这些结果。
    6．防火墙（Firewall）代理：保护目标，不让恶意用户接近。
    7．同步化（Synchronization）代理：使几个用户能够同时使用一个对象而没有冲突。
    8．智能引用（Smart Reference）代理：当一个对象被引用时，提供一些额外的操作，比如将对此对象调用的次数记录下来等。

    总结
    在软件系统中，增加一个中间层是我们解决问题的常见手法，这方面Proxy模式给了我们很好的实现。
 */

/// <summary>
///     代理模式（Proxy Pattern）
/// </summary>
internal class ProxyPattern
{
    public static void Test()
    {
        var proxy = new MathProxy();
        Console.WriteLine("3 + 2 = " + proxy.Add(3, 2));
        Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
        Console.WriteLine("5 * 2 = " + proxy.Mul(5, 2));
        Console.WriteLine("6 / 2 = " + proxy.Div(6, 2));
    }

    /// <summary>
    ///     接口
    /// </summary>
    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Mul(double x, double y);
        double Div(double x, double y);
    }

    /// <summary>
    ///     具体实现
    /// </summary>
    public class Math : IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }

    /// <summary>
    ///     代理类
    /// </summary>
    public class MathProxy : IMath
    {
        private readonly Math _math = new();

        public double Add(double x, double y)
        {
            return _math.Add(x, y);
        }

        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }

        public double Mul(double x, double y)
        {
            return _math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }
    }
}