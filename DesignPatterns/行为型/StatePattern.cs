namespace DesignPatterns.行为型;

/*
 * 状态模式（State Pattern）
 * 状态模式是一种行为型模式，又叫做快照模式。当一个对象的内在状态改变时允许改变其行为，这个对象看起来像是改变了其类。
 * 状态模式主要解决的是当控制一个对象状态的条件表达式过于复杂时的情况。
 * 把状态的判断逻辑转移到表示不同状态的一系列类中，可以把复杂的判断逻辑简化。
 * 状态模式在工作流或游戏等各种系统中大量使用。
 */

/// <summary>
///     状态模式（State Pattern）
/// </summary>
internal class StatePattern
{
    public static void Test()
    {
        var context = new Context(new StateA());

        // Issue requests, which toggles state
        context.Request();
        context.Request();
        context.Request();
        context.Request();
        context.Request();
    }

    public class Context
    {
        private State _state;

        public Context(State state)
        {
            this.State = state;
        }

        public State State
        {
            get => _state;
            set
            {
                _state = value;
                Console.WriteLine("State: " + _state.GetType().Name);
            }
        }

        public void Request()
        {
            _state.DoAction(this);
        }
    }

    public abstract class State
    {
        public abstract void DoAction(Context context);
    }

    public class StateA : State
    {
        public override void DoAction(Context context)
        {
            context.State = new StateB();
        }
    }

    public class StateB : State
    {
        public override void DoAction(Context context)
        {
            context.State = new StateA();
        }
    }
}