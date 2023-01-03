// 第一個客人點了美式原味炸雞
FriedChickenFactory factory1 = new AmericaFriedChickenFactory();
Console.WriteLine(factory1.GetProduct(0).GetName());
// 第二個客人點了韓式辣味炸雞
FriedChickenFactory factory2 = new KoreanFriedChickenFactory();
Console.WriteLine(factory2.GetProduct(1).GetName());

interface IFriedChicken
{
    string GetName();
}

class SpicyFriedChicken : IFriedChicken
{
    private string _name;

    public SpicyFriedChicken(string flavor)
    {
        _name = flavor + " Spicy Fried Chicken";
    }

    public string GetName()
    {
        return _name;
    }
}

class OriginalFriedChicken : IFriedChicken
{
    private string _name;

    public OriginalFriedChicken(string flavor)
    {
        _name = flavor + " Original Fried Chicken";
    }

    public string GetName()
    {
        return _name;
    }
}

abstract class FriedChickenFactory
{
    protected abstract IFriedChicken FactoryMethod(int type);

    public IFriedChicken GetProduct(int type)
    {
        return FactoryMethod(type);
    }
}

class AmericaFriedChickenFactory : FriedChickenFactory
{
    protected override IFriedChicken FactoryMethod(int type)
    {
        return type == 0 ? new SpicyFriedChicken("America") : new OriginalFriedChicken("America");
    }
}

class KoreanFriedChickenFactory : FriedChickenFactory
{
    protected override IFriedChicken FactoryMethod(int type)
    {
        return type == 0 ? new SpicyFriedChicken("Korean") : new OriginalFriedChicken("Korean");
    }
}