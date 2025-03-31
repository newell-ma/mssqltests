using Testcontainers.MsSql;

namespace TestProject1Tests;

public class Tests
{
    private MsSqlContainer _dbContainer;

    [OneTimeSetUp]
    public async Task BeforeAnyTests()
    {
        _dbContainer = new MsSqlBuilder()
          .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
          .Build();
        await _dbContainer.StartAsync();

        Console.WriteLine($"SQL Server is running at: {_dbContainer.GetConnectionString()}");
    }

    [OneTimeTearDown]
    public async Task AfterAllTests()
    {
        if (_dbContainer != null)
        {
            await _dbContainer.StopAsync();
            await _dbContainer.DisposeAsync();

        }
    }

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