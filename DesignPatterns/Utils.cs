namespace DesignPatterns;

public class Utils
{
    /// <summary>
    ///     反射实现深拷贝
    ///     传入TIn对象返回TOut对象
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <param name="tIn"></param>
    /// <returns></returns>
    public static TOut ReflectionClone<TIn, TOut>(TIn tIn)
    {
        var tOut = Activator.CreateInstance<TOut>();
        foreach (var itemOut in tOut.GetType().GetProperties())
        {
            var propIn = tIn.GetType().GetProperty(itemOut.Name);
            if (propIn != null)
            {
                itemOut.SetValue(tOut, propIn.GetValue(tIn));
            }
        }

        foreach (var itemOut in tOut.GetType().GetFields())
        {
            var fieldIn = tIn.GetType().GetField(itemOut.Name);
            if (fieldIn != null)
            {
                itemOut.SetValue(tOut, fieldIn.GetValue(tIn));
            }
        }

        return tOut;
    }

    /// <summary>
    ///     传入List<TIn>，返回List<TOut>
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    /// <param name="tInList"></param>
    /// <returns></returns>
    public static List<TOut> ReflectionCloneList<TIn, TOut>(List<TIn> tInList)
    {
        var result = new List<TOut>();
        foreach (var tIn in tInList)
        {
            var tOut = Activator.CreateInstance<TOut>();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                var propIn = tIn.GetType().GetProperty(itemOut.Name);
                if (propIn != null)
                {
                    itemOut.SetValue(tOut, propIn.GetValue(tIn));
                }
            }

            foreach (var itemOut in tOut.GetType().GetFields())
            {
                var fieldIn = tIn.GetType().GetField(itemOut.Name);
                if (fieldIn != null)
                {
                    itemOut.SetValue(tOut, fieldIn.GetValue(tIn));
                }
            }

            result.Add(tOut);
        }

        return result;
    }
}