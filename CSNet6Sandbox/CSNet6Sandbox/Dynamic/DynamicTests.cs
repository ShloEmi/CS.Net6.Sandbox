using FluentAssertions;
using NUnit.Framework;
using System.Diagnostics;

namespace CSNet6Sandbox.Dynamic;


public class DynamicTestClass
{
    public static int Method(int i) {
        return i;
    }
    public static int Method(long i) {
        return (int)i;
    }
    public static int Method(double i) {
        return (int)i;
    }
    public static int Method(string i) {
        return 0;
    }
    public static object Method(IDisposable i) {
        return -2;
    }
    public static int Method(object i) {
        if(Debugger.IsAttached)            
            Debug.Fail("dfgdfg");

        // log me!!

        return -1;
    }
}

public class DynamicTests
{
    [Test]
    public void TBD()
    {
        DynamicTestClass.Method((int)42).Should().Be(42);
    }

    [Test]
    public void TBD1()
    {
        unchecked{
            DynamicTestClass.Method((int)0xFFFFFFFFFFFFFFFF).Should().Be(-1);
        }
    }

    [Test]
    public void TBD3()
    {
        DynamicTestClass.Method(42.2).Should().Be(42);
    }

    [Test]
    public void TBD11()
    {
        int r = DynamicTestClass.Method("abc" as dynamic);
            
        r.Should().Be(0);
    }

    [Test]
    public void TBD12()
    {
        DynamicTestClass.Method(new Exception("qeqwe") /*as dynamic*/).Should().Be(-1);
    }




    [Test]
    public void TBD21()
    {
        Object input = new Object();

        DynamicTestClass.Method(input).Should().Be(-1);
    }

    [Test]
    public void TBD22()
    {
        Object input = "42";

        DynamicTestClass.Method(input).Should().Be(-1);
    }

    [Test]
    public void TBD23()
    {
        Object input = "42";

        int r = DynamicTestClass.Method(input as dynamic);

        r.Should().Be(0);
    }

    [Test]
    public void TBD24()
    {
        int r = DynamicTestClass.Method((Object)"42" as dynamic);

        r.Should().Be(0);
    }
}
