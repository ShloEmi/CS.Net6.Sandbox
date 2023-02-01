using FluentAssertions;
using NUnit.Framework;

namespace CSNet6Sandbox.OOP;


public class OOPTests
{
    // TODO: rename the tests to express what they prove.

    [Test]
    public void TBD1()
    {
        var d1 = new D1();
        B1 b1 = d1;

        b1.f1().Should().BeEquivalentTo("D1.f1");
    }

    [Test]
    public void TBD2()
    {
        var d1 = new D1();
        B1 b1 = d1;

        b1.f2().Should().BeEquivalentTo("D1.f2");
    }

    [Test]
    public void TBD3()
    {
        var d1 = new D1();

        ((B1)d1).f2().Should().BeEquivalentTo("D1.f2");
    }

    [Test]
    public void TBD4()
    {
        var c1 = new C1();
        c1.P1.Should().BeEquivalentTo("P1");
    }

    [Test]
    public void TBD5()
    {
        var c1 = new C1();
        c1.P1.Should().BeEquivalentTo("P1");
        //// all in remarks are compile-time-errors
        //c1.get_P1().Should().BeEquivalentTo("P1");
        //c1.get_P2().Should().BeEquivalentTo("P1");
        //c1.P2.Should().BeEquivalentTo("P2");
    }

    [Test]
    public void TBD6()
    {
        B1 x = new D1();
        x.f2().Should().BeEquivalentTo("D1.f2");
    }

    [Test]
    public void TBD7()
    {
        B1 x = new D1();

        Action act = () => ((D2)x).f4();
        act.Should().Throw<InvalidCastException>();
    }

    [Test]
    public void TBD8()
    {
        B1 x = new D1();

        Action act = () => ((D1)x).f3();
        act.Should().NotThrow();
    }



}
