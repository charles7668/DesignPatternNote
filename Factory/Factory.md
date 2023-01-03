# 工廠模式(Factory Method)

工廠模式跟[簡易工廠(Simple Factory)](./SimpleFactory.md)很相似，差別在於工廠模式中用於創建對像的工廠被抽像化了

## 定義

定義一個創建對像的接口，讓子類決定實例化哪個類別，Factory Method 使一個類的實例化推遲到子類

## 模式詳解

建立產品跟工廠的抽像或介面，並建立一個具體的類別繼承，客戶端使用時不直接依賴具體的工廠與產品，不必關心內部的具體實現方式，客戶端可直接透過工廠操作由工廠創建的對像或使用由工廠回傳的對像。

### 結構示意圖

![factory method diagram](./Image/factory%20method%20diagram.jpg)

## 埸景問題與示例

### 1. 今天你開了一家炸雞店，店內來了兩個客人，一個客人想點韓式的辣味炸雞，一個客人想點美式的原味炸雞。

---

#### 設計思路說明

> 使用簡易工廠時的情況，可能會建立 x 式的 x 味炸雞的產品，如果產品不會再增加的話其實也沒什麼問題，但如果今天多了一個台式，就要再把台式的所有口味炸雞建立一個產品，修改的程式量比較大，也不太符合開閉原則(Open-Closed principle)。
>
> 這裡使用工廠模式的話產品的部分分成原味、辣味，接下來只需建立各個國家風味的炸雞工廠去生產這兩種口味的炸雞即可

#### Code

首先建立炸雞的介面

```CSharp
interface IFriedChicken
{
    string GetName();
}
```

分別建立辣味及原味炸雞的類別，實現炸雞的介面

```CSharp
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
```

建立一個炸雞工廠的抽像類，裡面實現基本的取得產品的方法

```CSharp
abstract class FriedChickenFactory
{
    protected abstract IFriedChicken FactoryMethod(int type);

    public IFriedChicken GetProduct(int type)
    {
        return FactoryMethod(type);
    }
}
```

建立美式炸雞工廠及韓式炸雞工廠分別實現 factory method

```CSharp
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
```

客戶開始點餐

```CSharp
// 第一個客人點了美式原味炸雞
FriedChickenFactory factory1 = new AmericaFriedChickenFactory();
Console.WriteLine(factory1.GetProduct(0).GetName());
// 第二個客人點了韓式辣味炸雞
FriedChickenFactory factory2 = new KoreanFriedChickenFactory();
Console.WriteLine(factory2.GetProduct(1).GetName());
```

執行結果

```
America Spicy Fried Chicken
Korean Original Fried Chicken
```
