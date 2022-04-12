namespace DesignPatterns.创建型;

/*
 * 建造者模式（Builder Pattern）
 * 建造者模式是将一个复杂对象的构建与它的表示分离，使得同样的构建过程可以创建不同的表示。
 * 建造者模式使得建造代码与表示代码的分离，可以使客户端不必知道产品内部组成的细节，从而降低了客户端与具体产品之间的耦合度。
 * 使用多个简单的对象一步一步构建成一个复杂的对象。
 * 属于创建型模式，它提供了一种创建对象的最佳方式。
 *
 * 实现要点
    1、建造者模式主要用于“分步骤构建一个复杂的对象”，在这其中“分步骤”是一个稳定的算法，而复杂对象的各个部分则经常变化。
    2、产品不需要抽象类，特别是由于创建对象的算法复杂而导致使用此模式的情况下或者此模式应用于产品的生成过程，其最终结果可能差异很大，不大可能提炼出一个抽象产品类。
    3、创建者中的创建子部件的接口方法不是抽象方法而是空方法，不进行任何操作，具体的创建者只需要覆盖需要的方法就可以，但是这也不是绝对的，特别是类似文本转换这种情况下，缺省的方法将输入原封不动的输出是合理的缺省操作。
    4、前面我们说过的抽象工厂模式（Abtract Factory）解决“系列对象”的需求变化，Builder模式解决“对象部分”的需求变化，建造者模式常和组合模式（Composite Pattern）结合使用。

    效果
    1、建造者模式的使用使得产品的内部表象可以独立的变化。使用建造者模式可以使客户端不必知道产品内部组成的细节。
    2、每一个Builder都相对独立，而与其它的Builder无关。
    3、可使对构造过程更加精细控制。
    4、将构建代码和表示代码分开。
    5、建造者模式的缺点在于难于应付“分步骤构建算法”的需求变动。

    适用性 以下情况应当使用建造者模式：
    1、需要生成的产品对象有复杂的内部结构。
    2、需要生成的产品对象的属性相互依赖，建造者模式可以强迫生成顺序。
    3、在对象创建过程中会使用到系统中的一些其它对象，这些对象在产品对象的创建过程中不易得到。

    应用场景
    1、RTF文档交换格式阅读器。
    2、.NET环境下的字符串处理StringBuilder，这是一种简化了的建造者模式。

    总结
    建造者模式的实质是解耦组装过程和创建具体部件，使得我们不用去关心每个部件是如何组装的。
 */

/// <summary>
///     建造者模式（Builder Pattern）
/// </summary>
internal class BuilderPattern
{
    public static void Test()
    {
        Coder coderA = new CoderA();
        Coder coderB = new CoderB();

        var manager = new Manager(coderA);

        var programA = manager.CreateProgram();
        Console.WriteLine($"程序：{programA}");

        Console.WriteLine();

        manager = new Manager(coderB);
        var programB = manager.CreateProgram();
        Console.WriteLine($"程序：{programB}");
    }

    /// <summary>
    ///     建造者
    /// </summary>
    public abstract class Coder
    {
        public virtual string Code { get; set; }
        public abstract void WriteCode();
        public abstract string Release();
    }

    public class CoderA : Coder
    {
        public override void WriteCode()
        {
            Console.WriteLine("CoderA WriteCode");
            Code = "这是CoderA写的";
        }

        public override string Release()
        {
            Console.WriteLine("CoderA Release");
            return Code;
        }
    }

    public class CoderB : Coder
    {
        public override void WriteCode()
        {
            Console.WriteLine("CoderB WriteCode");
            Code = "这是CoderB写的";
        }

        public override string Release()
        {
            Console.WriteLine("CoderB Release");
            return Code;
        }
    }

    /// <summary>
    ///     指导者
    /// </summary>
    public class Manager
    {
        private readonly Coder _coder;

        public Manager(Coder coder)
        {
            _coder = coder;
        }

        public string CreateProgram()
        {
            Console.WriteLine("Manager CreateProgram");

            _coder.WriteCode();
            return _coder.Release();
        }
    }
}