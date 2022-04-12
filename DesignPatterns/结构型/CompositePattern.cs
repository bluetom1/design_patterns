namespace DesignPatterns.结构型;

/*
 * 组合模式（Composite Pattern）
 * 组合模式可以清楚地定义分层次的复杂对象，表示对象的全部或部分层次，使得增加新部件也更容易，
 * 它让客户忽略了层次的不同性，而它的结构又是动态的，提供了对象管理的灵活接口。
 * 组合模式对于树结构的控制有着神奇的功效，用户对单个对象和组合对象的使用具有一致性。
 * 组合模式解耦了客户程序与复杂元素内部结构，从而使客户程序可以像处理简单元素一样来处理复杂元素。
 * 也是一种结构型模式。
 *
 * 效果及实现要点
    1．Composite模式采用树形结构来实现普遍存在的对象容器，从而将“一对多”的关系转化“一对一”的关系，使得客户代码可以一致地处理对象和对象容器，无需关心处理的是单个的对象，还是组合的对象容器。
    2．将“客户代码与复杂的对象容器结构”解耦是Composite模式的核心思想，解耦之后，客户代码将与纯粹的抽象接口——而非对象容器的复内部实现结构——发生依赖关系，从而更能“应对变化”。
    3．Composite模式中，是将“Add和Remove等和对象容器相关的方法”定义在“表示抽象对象的Component类”中，还是将其定义在“表示对象容器的Composite类”中，是一个关乎“透明性”和“安全性”的两难问题，需要仔细权衡。这里有可能违背面向对象的“单一职责原则”，但是对于这种特殊结构，这又是必须付出的代价。ASP.NET控件的实现在这方面为我们提供了一个很好的示范。
    4．Composite模式在具体实现中，可以让父对象中的子对象反向追溯；如果父对象有频繁的遍历需求，可使用缓存技巧来改善效率。

    适用性 以下情况下适用Composite模式：
    1．你想表示对象的部分-整体层次结构
    2．你希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中的所有对象。

    总结
    组合模式解耦了客户程序与复杂元素内部结构，从而使客户程序可以向处理简单元素一样来处理复杂元素。
 */

/// <summary>
///     组合模式（Composite Pattern）
/// </summary>
internal class CompositePattern
{
    public static void Test()
    {
        FileObject txt1 = new txtFile("txt1");
        FileObject txt2 = new txtFile("txt2");
        FileObject doc1 = new docFile("doc1");
        FileObject doc2 = new docFile("doc2");
        FileObject folder1 = new Folder("folder1");
        FileObject folder2 = new Folder("folder2");
        txt1.Add(txt2);
        doc1.Add(doc2);
        txt1.Remove(doc1);
        folder1.Add(txt1);
        folder1.Add(doc2);
        folder2.Add(folder1);
        folder2.Add(doc1);
        folder1.Remove(txt1);

        //打印folder1目录下的文件
        Console.WriteLine("================================================================");
        foreach (var file in folder1.filelist)
        {
            Console.WriteLine(file.Name);
        }

        //打印folder2目录下的文件
        Console.WriteLine("================================================================");
        foreach (var file in folder2.filelist)
        {
            Console.WriteLine(file.Name);
        }
    }

    public abstract class FileObject
    {
        public string Name;
        public List<FileObject> filelist = new(); //组合

        protected FileObject(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     打印文件名
        /// </summary>
        public abstract void PrintName();

        public virtual void Add(FileObject fileobject)
        {
            Console.WriteLine("Add方法未重写");
        }

        public virtual void Remove(FileObject fileobject)
        {
            Console.WriteLine("Add方法未重写");
        }
    }

    public class Folder : FileObject
    {
        public Folder(string name) : base(name)
        {
        }

        public override void Add(FileObject fileobject)
        {
            filelist.Add(fileobject);
            Console.WriteLine(Name + "中添加了" + fileobject.Name);
        }

        public override void Remove(FileObject fileobject)
        {
            if (filelist.Remove(fileobject))
            {
                Console.WriteLine(Name + "中删除了" + fileobject.Name);
            }
            else
            {
                Console.WriteLine("删除失败！");
            }
        }

        public override void PrintName()
        {
            Console.WriteLine("文件名：" + Name);
        }
    }

    public class txtFile : FileObject
    {
        public txtFile(string name) : base(name)
        {
        }

        public override void PrintName()
        {
            Console.WriteLine("文件名：" + Name);
        }
    }

    public class docFile : FileObject
    {
        public docFile(string name) : base(name)
        {
        }

        public override void PrintName()
        {
            Console.WriteLine("文件名：" + Name);
        }
    }
}