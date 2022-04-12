namespace DesignPatterns.行为型;

/*
 * 命令模式（Command Pattern）
 * 命令模式是一种对象行为模式，分离了接受请求的对象与实现处理请求工作的对象，在软件系统中，“行为请求者”与“行为实现者”通常呈现一种“紧耦合”。
 * 但在某些场合，比如要对行为进行“记录、撤销/重做、事务”等处理，这种无法抵御变化的紧耦合是不合适的。
 * 在这种情况下，将一组行为抽象为对象，实现二者之间的松耦合。这样，已经存在的类可以保持不变，使得增加新类的工作更简单。
 * 例如，很多软件的宏命令就提高了系统的自动化程度。
 * 命令模式还可以分离用户界面和业务对象，降低系统的耦合度。
 *
 * 效果及实现要点
    1．Command模式的根本目的在于将“行为请求者”与“行为实现者”解耦，在面向对象语言中，常见的实现手段是“将行为抽象为对象”。
    2．实现Command接口的具体命令对象ConcreteCommand有时候根据需要可能会保存一些额外的状态信息。
    3．通过使用Compmosite模式，可以将多个命令封装为一个“复合命令”MacroCommand。
    4．Command模式与C#中的Delegate有些类似。但两者定义行为接口的规范有所区别：Command以面向对象中的“接口-实现”来定义行为接口规范，更严格，更符合抽象原则；Delegate以函数签名来定义行为接口规范，更灵活，但抽象能力比较弱。
    5．使用命令模式会导致某些系统有过多的具体命令类。某些系统可能需要几十个，几百个甚至几千个具体命令类，这会使命令模式在这样的系统里变得不实际。

    适用性 在下面的情况下应当考虑使用命令模式：
    1．使用命令模式作为"CallBack"在面向对象系统中的替代。"CallBack"讲的便是先将一个函数登记上，然后在以后调用此函数。
    2．需要在不同的时间指定请求、将请求排队。一个命令对象和原先的请求发出者可以有不同的生命期。换言之，原先的请求发出者可能已经不在了，而命令对象本身仍然是活动的。这时命令的接收者可以是在本地，也可以在网络的另外一个地址。命令对象可以在串形化之后传送到另外一台机器上去。
    3．系统需要支持命令的撤消(undo)。命令对象可以把状态存储起来，等到客户端需要撤销命令所产生的效果时，可以调用undo()方法，把命令所产生的效果撤销掉。命令对象还可以提供redo()方法，以供客户端在需要时，再重新实施命令效果。
    4．如果一个系统要将系统中所有的数据更新到日志里，以便在系统崩溃时，可以根据日志里读回所有的数据更新命令，重新调用Execute()方法一条一条执行这些命令，从而恢复系统在崩溃前所做的数据更新。

    总结
    Command模式是非常简单而又优雅的一种设计模式，它的根本目的在于将“行为请求者”与“行为实现者”解耦。
 */

/// <summary>
///     命令模式（Command Pattern）
/// </summary>
internal class CommandPattern
{
    public static void Test()
    {
        var receiver = new Receiver();
        ICommand command = new ConcereteCommand(receiver);
        var invoker = new Invoker();

        invoker.SetCommand(command);
        invoker.ExecuteCommand();
    }

    /// <summary>
    ///     抽象命令类，用来声明执行操作的接口
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }

    /// <summary>
    ///     调度类，要求该命令执行这个请求
    /// </summary>
    public class Invoker
    {
        private ICommand _command;

        /// <summary>
        ///     设置命令
        /// </summary>
        /// <param name="command"></param>
        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        /// <summary>
        ///     执行命令
        /// </summary>
        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }

    /// <summary>
    ///     接收者类，知道如何实施与执行一个请求相关的操作，任何类都可能作为一个接收者。
    /// </summary>
    public class Receiver
    {
        /// <summary>
        ///     真正的命令实现
        /// </summary>
        public void Action()
        {
            Console.WriteLine("Execute request!");
        }
    }

    /// <summary>
    ///     具体命令类，实现具体命令。
    /// </summary>
    public class ConcereteCommand : ICommand
    {
        /// <summary>
        ///     具体命令类包含有一个接收者，将这个接收者对象绑定于一个动作
        /// </summary>
        private readonly Receiver receiver;

        public ConcereteCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        /// <summary>
        ///     说这个实现是“虚”的，因为它是通过调用接收者相应的操作来实现Execute的
        /// </summary>
        public void Execute()
        {
            receiver.Action();
        }
    }
}