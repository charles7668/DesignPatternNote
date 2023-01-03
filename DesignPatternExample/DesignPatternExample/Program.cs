IFrenchFries noSaltFrenchFries = FrenchFriesFactory.CreateFrenchFries(0);
Console.WriteLine(noSaltFrenchFries.GetName());
IFrenchFries frenchFries = FrenchFriesFactory.CreateFrenchFries(1);
Console.WriteLine(frenchFries.GetName());

interface IFrenchFries
{
    string GetName();
}

class FrenchFries : IFrenchFries
{
    public string GetName()
    {
        return "French Fries";
    }
}

class NoSaltFries : IFrenchFries
{
    public string GetName()
    {
        return "No Salt French Fries";
    }
}

static class FrenchFriesFactory
{
    public static IFrenchFries CreateFrenchFries(int type)
    {
        if (type == 1)
            return new NoSaltFries();
        else
            return new FrenchFries();
    }
}