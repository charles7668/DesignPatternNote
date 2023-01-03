# 抽象工廠(Abstract Factory)

抽象工廠與[工廠模式](./Factory.md)都是拿來創建具體的對像用的，比較不同的地方是，抽象工廠創建的是一系列相關的產品，工廠模式用來創建較單一的對像

## 定義

提供一個相關或相互依賴的對像的介面，而不需指定它們具體的類

## 模式詳解

建立一個工廠的介面及一系列產品的介面，並建立實現這些介面的類別，工廠負責建立一系列相關的產品，客戶端只會透過這些介面與產品交互

### 結構示意圖

![abstract factory diagram](./Image/abstract%20factory%20diagram.jpg)

## 埸景問題與示例

### 1. 購買電腦的 CPU 與主機板

#### 設計思路說明

> 如果使用工廠模式來思考，可以建立一個 CPU 跟一個主機板的工廠然後生產這些零件，但這會產生一個問題，主機板與 CPU 的腳位數可能會對不上。
>
> 因為產品之間有依賴關系，所以這裡可以使用抽象工廠來設計，同一個工廠只會提供可組合的 CPU 跟主機板

#### Code

建立一個主機板、CPU 與工廠的介面

```CSharp
interface IMotherBoard
{
    string GetName();
}

interface ICPU
{
    string GetName();
}

interface IAbstractFactory
{
    IMotherBoard CreateMotherBoard();
    ICPU CreateCPU();
}
```

建立具體的實現

```CSharp
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
```

客戶購買同一家公司指定腳位的 CPU 與主機板

```CSharp
// 購買A公司1156pin的CPU與主機板

IAbstractFactory aCompanyFactory = new ACompanyFactory("1156");
Console.WriteLine(aCompanyFactory.CreateCPU().GetName());
Console.WriteLine(aCompanyFactory.CreateMotherBoard().GetName());

// 購買B公司1157pin的CPU與主機板

IAbstractFactory bCompanyFactory = new BCompanyFactory("1157");
Console.WriteLine(bCompanyFactory.CreateCPU().GetName());
Console.WriteLine(bCompanyFactory.CreateMotherBoard().GetName());
```

輸出結果

```
A Company CPU with 1156 pin
A Company MotherBoard with 1156 pin
B Company CPU with 1157 pin
B Company MotherBoard with 1157 pin
```
