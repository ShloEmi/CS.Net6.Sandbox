using FluentAssert;
using NUnit.Framework;

namespace CSNet6Sandbox.Events;

public class EventsTests
{
    [Test]
    public void InvokeExampleEvent__SeveralRegistrations_NormalEventsExecution__ExampleEvent_ShouldContainAll_expectedEvents()
    {
        var uut = new EventsTestClass();

        var list = new List<string>();


        uut.ExampleEvent += (s, args) => list.Add("1");
        uut.ExampleEvent += (s, args) => list.Add("2");


        //act
        uut.InvokeExampleEvent();


        var expected = new List<string> { "1", "2" };
        list.ShouldContainAll(expected);
    }


    [Test]
    public void InvokeExampleEvent__SeveralRegistrations_Event1ThrowsException__OnlyEvent1HandledAndNotEvent2Handled()
    {
        var uut = new EventsTestClass();

        var list = new List<string>();


        uut.ExampleEvent += (s, args) =>
        {
            list.Add("1");
            throw new Exception();
        };

        uut.ExampleEvent += (s, args) => list.Add("2");


        //act
        try
        {
            uut.InvokeExampleEvent();
        }
        catch (Exception exception)
        {
            list.Add("exception");
        }


        var expected = new List<string> { "1", "exception"};
        list.ShouldContainAll(expected);
    }
}