Drink drink = new GreenTea();
drink.Make();
Drink drink2 = new HotBlackTea();
drink2.Make();

abstract class Drink
{
    public void Make()
    {
        PrepareCup();
        AddIngredients();
        Shake();
    }

    private void PrepareCup()
    {
        Console.WriteLine("prepare cup");
    }

    private void Shake()
    {
        Console.WriteLine("shake");
    }

    protected abstract void AddIngredients();
}

class GreenTea : Drink
{
    protected override void AddIngredients()
    {
        Console.WriteLine("add green tea");
        Console.WriteLine("add sugar");
        Console.WriteLine("add ice");
    }
}

class HotBlackTea : Drink
{
    protected override void AddIngredients()
    {
        Console.WriteLine("add hot black tea");
        Console.WriteLine("add sugar");
    }
}