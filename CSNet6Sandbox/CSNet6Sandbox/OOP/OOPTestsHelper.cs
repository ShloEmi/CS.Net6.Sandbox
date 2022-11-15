namespace CSNet6Sandbox.Events;

abstract internal class B1
{
    public string f0() => "B1.f0";

    public abstract string f1();

    public virtual string f2() => "B1.f2";
}

internal class D1 : B1
{
    public override string f1() => "D1.f1";

    public override string f2() => "D1.f2";

    public string f3() => "D1.f3";
}

internal class D2 : B1
{
    public override string f1() => "D1.f1";

    public override string f2() => "D1.f2";

    public string f4() => "D1.f3";
}


internal class C1
{
    // ~~~ c# Syntax Sugar ~~~~~~~~~~~~~~~~~~~~~~~
    public string P1 { get; set; } = "P1";
    // ^^ same idea as: 
    private string __P2 = "P2";
    public string get_P2(){ return __P2; }
    public void set_P2(string value){ __P2 = value; }
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
