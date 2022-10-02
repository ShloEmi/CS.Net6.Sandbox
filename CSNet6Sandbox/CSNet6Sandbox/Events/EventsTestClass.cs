namespace CSNet6Sandbox.Events;

public class EventsTestClass
{
    public event EventHandler<ExampleEventArgs>? ExampleEvent;


    protected virtual void OnExampleEvent(ExampleEventArgs e) =>
        ExampleEvent?.Invoke(this, e);


    public void InvokeExampleEvent() => 
        OnExampleEvent(new ExampleEventArgs(0, DateTime.Now, "x"));

    public void InvokeExampleEventParallel()
    {
        Delegate[] invocationList = ExampleEvent?.GetInvocationList();
        ParallelQuery<Delegate> parallelQuery = invocationList?.AsParallel();
        foreach (Delegate @delegate in parallelQuery)
        {
            var args = new ExampleEventArgs(0, DateTime.Now, $"{Thread.CurrentThread.ManagedThreadId}");
            @delegate.DynamicInvoke(this, args);
        }
    }

    public void InvokeExampleEventParallelUsingThreads()
    {
        /* TODO: Shlomi, test prove me */
        Delegate[] invocationList = ExampleEvent?.GetInvocationList();
        foreach (Delegate @delegate in invocationList)
        {
            new Thread(() =>
            {
                var args = new ExampleEventArgs(0, DateTime.Now, $"{Thread.CurrentThread.ManagedThreadId}");
                @delegate.DynamicInvoke(this, args);
            }).Start();
        }
    }
}


public class ExampleEventArgs : EventArgs
{
    public int ExampleInt { get; }
    public DateTime ExampleDate { get; }
    public string ExampleString { get; }


    public ExampleEventArgs(int exampleInt, DateTime exampleDate, string exampleString)
    {
        ExampleInt = exampleInt;
        ExampleDate = exampleDate;
        ExampleString = exampleString;
    }
}
