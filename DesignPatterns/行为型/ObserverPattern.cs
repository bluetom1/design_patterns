namespace DesignPatterns.行为型;

/*
 * 观察者模式（Observer Pattern）
 * 观察者模式是一种对象行为模式。它定义对象间的一种一对多的依赖关系，当一个对象的状态发生改变时，所有依赖于它的对象都得到通知并被自动更新。
 * 在观察者模式中，主体是通知的发布者，它发出通知时并不需要知道谁是它的观察者，可以有任意数目的观察者订阅并接收通知。
 * 观察者模式不仅被广泛应用于软件界面元素之间的交互，在业务对象之间的交互、权限管理等方面也有广泛的应用。
 * 观察者模式的主要的作用就是对对象解耦，将观察者和被观察者完全隔离。
 */

/// <summary>
///     观察者模式（Observer Pattern）
/// </summary>
internal class ObserverPattern
{
    public static void Test()
    {
        var center = new Center();
        center.Add(new Cat());
        center.Add(new Dog());
        center.Add(new Dog());

        center.SoundObserver();
    }

    public class Center
    {
        private readonly List<Observer> _ObserverList = new();

        public void Add(Observer observer)
        {
            _ObserverList.Add(observer);
        }

        public void Remove(Observer observer)
        {
            _ObserverList.Remove(observer);
        }

        public void SoundObserver()
        {
            Console.WriteLine("{0} SoundObserver.....", GetType().Name);
            foreach (var observer in _ObserverList)
            {
                observer.Action();
            }
        }
    }

    public abstract class Observer
    {
        public abstract void Action();
    }

    public class Cat : Observer
    {
        public override void Action()
        {
            Console.WriteLine("{0} Action", GetType().Name);
        }
    }

    public class Dog : Observer
    {
        public override void Action()
        {
            Console.WriteLine("{0} Action", GetType().Name);
        }
    }
}