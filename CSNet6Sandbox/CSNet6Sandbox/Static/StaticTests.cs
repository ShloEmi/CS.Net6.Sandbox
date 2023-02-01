using FluentAssertions;
using NUnit.Framework;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CSNet6Sandbox.Static;

/*
CAN'T:
public static struct MyStaticStruct { }
*/

public /**/static/**/ class MyStaticClass
{
    //static const int NoNo1 = 42;
    public const int ConstInt = 42;
    public readonly static int ReadonlyStaticInt = 42;
    static int YesYes3 = 42;
    static Action staticActionDelegate = new Action(MyStaticClassMethod);


    public static int StaticInt = 42;
    // ERROR: int aa;

    static MyStaticClass()
    {
        if(ReadonlyStaticInt == 42){
            ReadonlyStaticInt = 43;
        }

        MyStaticClassMethod();

        var localActionDelegate = new Action(MyStaticClassMethod);
        staticActionDelegate = new Action(MyStaticClassMethod);

        // ConstInt = 44;

        throw new Exception("MyStaticClass throw");
    }

    public static void MyStaticClassMethod()
    {
        /* NOPE:
        ReadonlyStaticInt = 43;
        ConstInt = 44;
        */
    }
}



public class DynamicTests
{
    static bool firstTime = true;

    static void ExtMethodMustBeInStaticClass(/*this*/ DynamicTests qwe ) { }

    static DynamicTests()
    {
        // yes we can static-ctor!

        //.
        // THIS WILL KILL THIS TYPE:
        //  throw new Exception("StaticTests throw");

        if (firstTime)
        {
            firstTime = !firstTime;
            //throw new Exception("StaticTests throw");
        }
    }


    [Test]
    public void typeof_StaticClass_IsAbstract__Should_BeTrue() => 
        typeof(MyStaticClass).IsAbstract.Should().BeTrue();

    [Test]
    public void typeof_StaticClass_IsSealed__Should_BeTrue() => 
        typeof(MyStaticClass).IsSealed.Should().BeTrue();

    [Test]
    public void typeof_MyStaticClass_GetField_StaticInt_ShouldNotBeNull() {
        typeof(MyStaticClass).GetField("StaticInt").Should().NotBeNull();
    }

    [Test]
    public void typeof_MyStaticClass_GetField_ConstInt_ShouldNotBeNull() {
        typeof(MyStaticClass).GetField("ConstInt").Should().NotBeNull();
    }

/*
    [Test]
    public void typeof_MyStaticClass_GetField_ConstInt_ShouldNotBeNull2() {
        bool isThrown = false;
        try
        {
            var qwe = MyStaticClass.ReadonlyStaticInt;
        }
        catch (Exception ex)
        {
            isThrown = true;
        }
        isThrown.Should().BeTrue();

        //Q. What will happen if a static constructor throws an exception?
        // A. If a static constructor throws an exception, the runtime will not invoke it a second time, and the type will remain uninitialized for 
        //   the lifetime of the application domain in which your program is running. 
        //


        isThrown = false;
        try
        {
            var qwe = MyStaticClass.ReadonlyStaticInt;
        }
        catch (Exception ex)
        {
            isThrown = true;
        }
        isThrown.Should().BeFalse();


        isThrown = false;
        try
        {
            var qwe = MyStaticClass.ReadonlyStaticInt;
        }
        catch (Exception ex)
        {
            isThrown = true;
        }
        isThrown.Should().BeTrue();
    }
*/

}
