using FluentAssertions;
using NUnit.Framework;

namespace CSNet6Sandbox.Reflection;

public class ReflectionTests
{
    [Test]
    public void TBD1() => 
        typeof(object).IsPrimitive.Should().BeFalse();
}
