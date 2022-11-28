using NUnit.Framework;

namespace CSNet6Sandbox.DataStruct;

public class StackTests
{
    public class MyClass<T> : Stack<T>
    {
        public new void Push(T item)
        {
            // ... override old behaviour
        }


        public T Pop()
        {
            // ... override old behaviour
            return default(T);
        }
    }

    [Test]
    public void TBD()
    {
        var s1 = new Stack<int>();
        s1.Push(1);

        var s2 = new Stack<int>(100);
        s2.Pop();
    }
}
