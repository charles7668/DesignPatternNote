// 購買A公司1156pin的CPU與主機板

IAbstractFactory aCompanyFactory = new ACompanyFactory("1156");
Console.WriteLine(aCompanyFactory.CreateCPU().GetName());
Console.WriteLine(aCompanyFactory.CreateMotherBoard().GetName());

// 購買B公司1157pin的CPU與主機板

IAbstractFactory bCompanyFactory = new BCompanyFactory("1157");
Console.WriteLine(bCompanyFactory.CreateCPU().GetName());
Console.WriteLine(bCompanyFactory.CreateMotherBoard().GetName());

interface IMotherBoard
{
    string GetName();
}

interface ICPU
{
    string GetName();
}

class ACompanyMotherBoard : IMotherBoard
{
    private string _name;

    public ACompanyMotherBoard(string pin)
    {
        _name = "A Company MotherBoard with " + pin + " pin";
    }

    public string GetName()
    {
        return _name;
    }
}

class BCompanyMotherBoard : IMotherBoard
{
    private string _name;

    public BCompanyMotherBoard(string pin)
    {
        _name = "B Company MotherBoard with " + pin + " pin";
    }

    public string GetName()
    {
        return _name;
    }
}

class ACompanyCPU : ICPU
{
    private string _name;

    public ACompanyCPU(string pin)
    {
        _name = "A Company CPU with " + pin + " pin";
    }

    public string GetName()
    {
        return _name;
    }
}

class BCompanyCPU : ICPU
{
    private string _name;

    public BCompanyCPU(string pin)
    {
        _name = "B Company CPU with " + pin + " pin";
    }

    public string GetName()
    {
        return _name;
    }
}

interface IAbstractFactory
{
    IMotherBoard CreateMotherBoard();
    ICPU CreateCPU();
}

class ACompanyFactory : IAbstractFactory
{
    private string _pin = "1155";

    public ACompanyFactory(string pin)
    {
        _pin = pin;
    }

    public IMotherBoard CreateMotherBoard()
    {
        return new ACompanyMotherBoard(_pin);
    }

    public ICPU CreateCPU()
    {
        return new ACompanyCPU(_pin);
    }
}

class BCompanyFactory : IAbstractFactory
{
    private string _pin = "1155";

    public BCompanyFactory(string pin)
    {
        _pin = pin;
    }

    public IMotherBoard CreateMotherBoard()
    {
        return new BCompanyMotherBoard(_pin);
    }

    public ICPU CreateCPU()
    {
        return new BCompanyCPU(_pin);
    }
}