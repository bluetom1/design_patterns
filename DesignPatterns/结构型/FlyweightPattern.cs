using System.Collections;

namespace DesignPatterns.结构型;

/*
 * 享元模式（Flyweight Pattern）
 * 享元模式是一种结构型模式，是运用共享技术有效的支持大量细粒度的对象。
 * 它使用共享对象，用来尽可能减少内存使用量以及分享资讯给尽可能多的相似对象；它适合用于只是因重复而导致使用无法令人接受的大量内存的大量对象。
 * 通常对象中的部分状态是可以分享。
 * 常见做法是把它们放在外部数据结构，当需要使用时再将它们传递给享元。
 * Flyweight模式需要认真考虑如何能细化对象，以减少处理的对象数量，从而减少存留对象在内存或其他存储设备中的占用量。
 * String常量池、数据库连接池、缓冲池等等都是享元模式的应用。
 *
 * 效果及实现要点
1．面向对象很好的解决了抽象性的问题，但是作为一个运行在机器中的程序实体，我们需要考虑对象的代价问题。Flyweight设计模式主要解决面向对象的代价问题，一般不触及面向对象的抽象性问题。
2．Flyweight采用对象共享的做法来降低系统中对象的个数，从而降低细粒度对象给系统带来的内存压力。在具体实现方面，要注意对象状态的处理。
3．享元模式的优点在于它大幅度地降低内存中对象的数量。但是，它做到这一点所付出的代价也是很高的：享元模式使得系统更加复杂。为了使对象可以共享，需要将一些状态外部化，这使得程序的逻辑复杂化。另外它将享元对象的状态外部化，而读取外部状态使得运行时间稍微变长。

适用性 当以下所有的条件都满足时，可以考虑使用享元模式：
1、   一个系统有大量的对象。
2、   这些对象耗费大量的内存。
3、   这些对象的状态中的大部分都可以外部化。
4、   这些对象可以按照内蕴状态分成很多的组，当把外蕴对象从对象中剔除时，每一个组都可以仅用一个对象代替。
5、   软件系统不依赖于这些对象的身份，换言之，这些对象可以是不可分辨的。

满足以上的这些条件的系统可以使用享元对象。最后，使用享元模式需要维护一个记录了系统已有的所有享元的表，而这需要耗费资源。因此，应当在有足够多的享元实例可供共享时才值得使用享元模式。

总结
Flyweight模式解决的是由于大量的细粒度对象所造成的内存开销的问题，它在实际的开发中并不常用，但是作为底层的提升性能的一种手段却很有效。
 */

/// <summary>
///     享元模式（Flyweight Pattern）
/// </summary>
internal class FlyweightPattern
{
    public static void Test()
    {
        var charactorFactory = new CharactorFactory();

        var a = charactorFactory.GetCharactor("A");
        a.SetPointSize(10);
        a.Display();

        var b = charactorFactory.GetCharactor("B");
        b.SetPointSize(10);
        b.Display();
    }

    public abstract class Charactor
    {
        protected char symbol { get; set; }
        protected int index { get; set; }
        protected int pointSize { get; set; }

        public abstract void SetPointSize(int size);
        public abstract void Display();
    }

    public class CharactorFactory
    {
        private readonly Hashtable charactors = new();

        public CharactorFactory()
        {
            charactors.Add("A", new CharactorA());
            charactors.Add("B", new CharactorB());
        }

        public Charactor GetCharactor(string key)
        {
            if (charactors[key] is not Charactor charactor)
            {
                charactor = key switch
                {
                    "A" => new CharactorA(),
                    "B" => new CharactorB(),
                    _ => null
                };

                if (charactor is not null)
                {
                    charactors.Add(key, charactor);
                }
            }

            return charactor;
        }
    }

    public class CharactorA : Charactor
    {
        public CharactorA()
        {
            symbol = 'A';
            index = 'A';
        }

        public override void SetPointSize(int size)
        {
            pointSize = size;
        }

        public override void Display()
        {
            Console.WriteLine($"{symbol} {index} {pointSize}");
        }
    }

    public class CharactorB : Charactor
    {
        public CharactorB()
        {
            symbol = 'B';
            index = 'B';
        }

        public override void SetPointSize(int size)
        {
            pointSize = size;
        }

        public override void Display()
        {
            Console.WriteLine($"{symbol} {index} {pointSize}");
        }
    }
}