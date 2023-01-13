# 建造者模式(Builder)

## 定義

將一個複雜物件的構建與其表示分離，使得同樣的構建過程可以創建不同的表示

## 模式詳解

建造者模式通常有個 Director 來決定建造流程，流程中的各個方法的實做由各自的建造物件進行處理

### 結構示意圖

![builder diagram](./Image/builder%20diagram.jpg)

## 埸景問題與示例

### 1. 準備一杯綠茶及一杯紅茶

使用建造者模式來處理此問題
假設準備紅茶及綠茶的流程如下

1. 準備杯子
2. 倒入綠茶/紅茶

### 思考

> 首先要設計一個 Builder 的介面，並實作 BlackTeaBuilder 及 GreenTeaBuilder 的類別，且有一個 Tea 的產品類，最後再設計一個 Director 來負責中間的流程

### 程式

建立 Build 的介面

```CSharp
interface IBuilder
{
    void PrepareCup();
    void AddTea();
}
```

實作 GreenTeaBuilder , BlackTeaBuilder 及產品的 Tea

```CSharp
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
```

建立 Director 來負責生產的流程

```CSharp
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
```

開始製做

```CSharp
IBuilder blackTeaBuilder = new BlackTeaBuilder();
Director director = new Director(blackTeaBuilder);
director.MakeTea();
IBuilder greenTeaBuilder = new GreenTeaBuilder();
director = new Director(greenTeaBuilder);
director.MakeTea();
```

輸出結果

```
prepare a cup
add black tea into cup
prepare a cup
add green tea into cup
```
