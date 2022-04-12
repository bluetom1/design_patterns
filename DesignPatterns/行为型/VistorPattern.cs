namespace DesignPatterns.行为型;

/*
 * 访问者模式（Vistor Pattern）
 * 访问者模式是一种行为型模式，表示一个作用于某对象结构中的各元素的操作。它使你可以在不改变各元素类的前提下定义作用于这些元素的新操作。
 * 访问者模式适用于数据结构相对稳定算法又易变化的系统。因为访问者模式使得算法操作增加变得容易。
 * 若系统数据结构对象易于变化，经常有新的数据对象增加进来，则不适合使用访问者模式。
 * 访问者模式将有关行为集中到一个访问者对象中，其改变不影响系统数据结构。
 * 其缺点就是增加新的数据结构很困难。元素类可以通过接受不同的访问者来实现对不同操作的扩展。
 * Visitor(访问者)模式使得增加新的操作变得容易，它可以收集有关联的方法，而分离没有关联的方法，特别适用于分离因为不同原因而变化的事物。
 */

/// <summary>
///     访问者模式（Vistor Pattern）
/// </summary>
internal class VistorPattern
{
    public static void Test()
    {
        ComputerPart computer = new Computer();
        computer.Accept(new ComputerPartDisplayVisitor());
    }

    public abstract class ComputerPart
    {
        public abstract void Accept(ComputerPartVisitor computerPartVisitor);
    }

    public abstract class ComputerPartVisitor
    {
        public abstract void Visit(Computer part);
        public abstract void Visit(Keyboard part);
        public abstract void Visit(Mouse part);
    }

    public class ComputerPartDisplayVisitor : ComputerPartVisitor
    {
        public override void Visit(Computer computer)
        {
            Console.WriteLine("Displaying Computer.");
        }

        public override void Visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying Keyboard.");
        }

        public override void Visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Mouse.");
        }
    }

    public class Computer : ComputerPart
    {
        private readonly ComputerPart[] parts;

        public Computer()
        {
            parts = new ComputerPart[] {new Keyboard(), new Mouse()};
        }

        public override void Accept(ComputerPartVisitor computerPartVisitor)
        {
            foreach (var computerPart in parts)
            {
                computerPart.Accept(computerPartVisitor);
            }

            computerPartVisitor.Visit(this);
        }
    }

    public class Keyboard : ComputerPart
    {
        public override void Accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

    public class Mouse : ComputerPart
    {
        public override void Accept(ComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }
}