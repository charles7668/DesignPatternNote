# 簡易工廠(Simple Factory)

簡易工廠並不算一種設計模式，但是很常被使用在程式設計上的手法，也算是一種簡化版的[工廠模式(Factory Method)](./Factory.md)

## 定義

提供一個創建對像實例的功能，無需關心對像的具體實現方式，對像可以是 介面(Interface)、抽像(Abstract) 或是具體的類別(Class)

## 模式詳解

客戶端不直接依賴產品的具體實現來創建對像，而是透過一個工廠類別來進行對像的創建，所以建立對像的選擇會由工廠類別來進行，客戶端無需知道具體實現的類別，工廠類別也可使用靜態類別而不需建立工廠的實例

### 結構示意圖

![simple factory diagram.jpg](Image/simple%20factory%20diagram.jpg)

## 埸景問題與示例

### 1. 創建一個薯條工廠，工廠可以生產 無鹽薯條 或 有鹽薯條

首先先建立一個薯條的介面(Interface) `IFrenchFries`

```CSharp
interface IFrenchFries
{
    string GetName();
}
```

再來建立 薯條，無鹽薯條的類別，分別去實現 `IFrenchFries`

```CSharp
class Fries : IFrenchFries
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
```

建立一個工廠來負責生產薯條

```CSharp
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
```

客戶透過工廠來生產薯條

```CSharp
IFrenchFries noSaltFrenchFries = FrenchFriesFactory.CreateFrenchFries(0);
Console.WriteLine(noSaltFrenchFries.GetName());
IFrenchFries frenchFries = FrenchFriesFactory.CreateFrenchFries(1);
Console.WriteLine(frenchFries.GetName());
```

執行結果

```
French Fries
No Salt French Fries
```
