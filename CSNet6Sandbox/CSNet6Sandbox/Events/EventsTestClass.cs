namespace CSNet6Sandbox.Events;

public class EventsTestClass
{
    public event EventHandler<ExampleEventArgs>? ExampleEvent;


    protected virtual void OnExampleEvent(ExampleEventArgs e) =>
        ExampleEvent?.Invoke(this, e);

    public void InvokeExampleEvent()
    {
        OnExampleEvent(new ExampleEventArgs(0, DateTime.Now, "x"));
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
