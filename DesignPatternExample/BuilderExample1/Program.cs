IBuilder blackTeaBuilder = new BlackTeaBuilder();
Director director = new Director(blackTeaBuilder);
director.MakeTea();
IBuilder greenTeaBuilder = new GreenTeaBuilder();
director = new Director(greenTeaBuilder);
director.MakeTea();

interface IBuilder
{
    void PrepareCup();
    void AddTea();
}

class Director
{
    private IBuilder _builder;

    public Director(IBuilder builder)
    {
        _builder = builder;
    }

    public void MakeTea()
    {
        _builder.PrepareCup();
        _builder.AddTea();
    }
}

class BlackTeaBuilder : IBuilder
{
    Tea _tea = new Tea();

    public void PrepareCup()
    {
        Console.WriteLine("prepare a cup");
    }

    public void AddTea()
    {
        Console.WriteLine("add black tea into cup");
        _tea.AddTea("green tea");
    }

    public Tea GetTea()
    {
        return _tea;
    }
}

class GreenTeaBuilder : IBuilder
{
    Tea _tea = new Tea();

    public void PrepareCup()
    {
        Console.WriteLine("prepare a cup");
    }

    public void AddTea()
    {
        Console.WriteLine("add green tea into cup");
        _tea.AddTea("green tea");
    }

    public Tea GetTea()
    {
        return _tea;
    }
}

class Tea
{
    public string Name { get; set; }

    public Tea()
    {
    }

    public void AddTea(string name)
    {
        Name = name;
    }
}