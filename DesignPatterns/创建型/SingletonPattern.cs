namespace DesignPatterns.创建型;

/*
 * 单例模式（Singleton Pattern）
 * 单例模式，属于创建类型的一种常用的软件设计模式。通过单例模式的方法创建的类在当前进程中只有一个实例。
 */

/// <summary>
///     单例模式（Singleton Pattern）
/// </summary>
internal class SingletonPattern
{
    public static void Test()
    {
        Console.WriteLine(Singleton.Instance.GetHashCode());
        Console.WriteLine(Singleton.Instance.GetHashCode());
        Console.WriteLine(Singleton.Instance.GetHashCode());

        Console.ReadKey();
    }

    public sealed class Singleton
    {
        private static Singleton instance;
        private static readonly object padlock = new();

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new Singleton();
                    return instance;
                }
            }
        }
    }
}