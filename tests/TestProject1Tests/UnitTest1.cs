namespace TestProject1Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        ClassLibrary1.Class1 c = new();
        Assert.IsTrue(c.Test());
    }
}