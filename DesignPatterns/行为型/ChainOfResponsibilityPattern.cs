namespace DesignPatterns.行为型;

/*
 * 责任链模式（Chain of Responsibility Pattern）
 * 责任链模式是一种对象行为模式。在责任链模式里，很多对象由每一个对象对其下家的引用而连接起来形成一条链。
 * 请求在这个链上传递，直到链上的某一个对象决定处理此请求。
 * 发出这个请求的客户端并不知道链上的哪一个对象最终处理这个请求，这使得系统可以在不影响客户端的情况下动态地重新组织和分配责任。
 * 也就是通常每个接收者都包含对另一个接收者的引用。
 * 如果一个对象不能处理该请求，那么它会把相同的请求传给下一个接收者，依此类推。
 */

/// <summary>
///     责任链模式（Chain of Responsibility Pattern）
/// </summary>
internal class ChainOfResponsibilityPattern
{
    public static void Test()
    {
        Handler h1 = new ConcreteHandler1();
        Handler h2 = new ConcreteHandler2();
        Handler h3 = new ConcreteHandler3();

        h1.SetSuccessor(h2);
        h2.SetSuccessor(h3);

        int[] requests = {2, 5, 14, 22, 18, 3, 27, 20};

        foreach (var request in requests)
        {
            h1.HandleRequest(request);
        }
    }

    public abstract class Handler
    {
        public abstract void HandleRequest(int request);

        protected Handler _successor;

        public void SetSuccessor(Handler successor)
        {
            _successor = successor;
        }
    }

    public class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request is >= 0 and < 10)
            {
                Console.WriteLine("0-10:{0} handled request {1}", GetType().Name, request);
            }
            else
            {
                _successor?.HandleRequest(request);
            }
        }
    }

    public class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request is >= 10 and < 20)
            {
                Console.WriteLine("10-20:{0} handled request {1}", GetType().Name, request);
            }
            else
            {
                _successor?.HandleRequest(request);
            }
        }
    }

    public class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request is >= 20 and < 30)
            {
                Console.WriteLine("20-30:{0} handled request {1}", GetType().Name, request);
            }
            else
            {
                _successor?.HandleRequest(request);
            }
        }
    }
}