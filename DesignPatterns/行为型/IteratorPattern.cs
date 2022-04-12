namespace DesignPatterns.行为型;

/*
 * 迭代器模式（Iterator Pattern）
 * 迭代器模式是一种对象行为模式，提供一种方法顺序访问一个聚合对象中的各种元素，而又不暴露该对象的内部表示。
 * 支持在聚集中移动游标，使得访问聚合中的元素变得简单，简化了聚集的接口，封装了聚合的对象。
 * 迭代器模式还可以应用于对树结构的访问，程序不需要从头逐行代码查找相应位置，可控制到从子集开始查找。
 * 它支持以不同的方式遍历一个集合，为遍历不同的集合结构提供一个统一的接口，迭代器简化了集合的接口，在同一个集合上可以有多个遍历。
 *
 * 效果及实现要点
    1．迭代抽象：访问一个聚合对象的内容而无需暴露它的内部表示。
    2．迭代多态：为遍历不同的集合结构提供一个统一的接口，从而支持同样的算法在不同的集合结构上进行操作。
    3．迭代器的健壮性考虑：遍历的同时更改迭代器所在的集合结构，会导致问题。

    适用性
    1．访问一个聚合对象的内容而无需暴露它的内部表示。
    2．支持对聚合对象的多种遍历。
    3．为遍历不同的聚合结构提供一个统一的接口(即, 支持多态迭代)。

    总结
    Iterator模式就是分离了集合对象的遍历行为，抽象出一个迭代器类来负责，这样既可以做到不暴露集合的内部结构，又可让外部代码透明的访问集合内部的数据。
 */

/// <summary>
///     迭代器模式（Iterator Pattern）
/// </summary>
internal class IteratorPattern
{
    public static void Test()
    {
        var iter = new NameRepository().GetIterator();
        do
        {
            Console.WriteLine("Name : " + iter.Next());
        } while (iter.HasNext());
    }

    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    public interface IContainer
    {
        IIterator GetIterator();
    }

    public class NameIterator : IIterator
    {
        private readonly string[] names;

        public NameIterator(string[] names)
        {
            this.names = names;
        }

        private int index;

        public bool HasNext()
        {
            return index < names.Length;
        }

        public object Next()
        {
            return HasNext() ? names[index++] : null;
        }
    }

    public class NameRepository : IContainer
    {
        public string[] names = {"Robert", "John", "Julie", "Lora"};

        public IIterator GetIterator()
        {
            return new NameIterator(names);
        }
    }
}