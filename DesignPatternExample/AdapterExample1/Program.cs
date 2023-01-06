Test testLibrary = new Test();
ITarget target = new Adapter(testLibrary);
Console.WriteLine("temperature : " + target.GetTemperature());

class Test
{
    public int GetData()
    {
        return 10;
    }
}

interface ITarget
{
    int GetTemperature();
}

class Adapter : ITarget
{
    private Test _test;

    public Adapter(Test test)
    {
        _test = test;
    }

    public int GetTemperature()
    {
        return _test.GetData();
    }
}