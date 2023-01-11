# 模板方法 (Template Method)

## 定義

在方法中定義算法的骨架，將一些步驟推遲到子類，模板方法使得子類可以重新定義部分步驟而不改變算法的結構

## 模式詳解

模板方法會固定好算法的骨架，如同 SOP(標準操作流程)，骨架內一些方法可定義為抽象(abstract)具體實現由子類別各自去實做，也可定義好預設的行為，由子類別決定是否覆寫(override)，後者的方法稱為“鉤子”(hook)

模板方法同時也符合設計原則中的“好萊塢原則”，也就是“不要來聯系我們，我們會聯系你”，是一種控制反轉(IoC)的具體實現

### 結構示意圖

![template diagram](./Image/template%20diagram.jpg)

## 埸景問題與示例

### 1. 飲料製作

首先思考一下沒有用設計模式時可能的做法

> 為每種飲料建立一個類別並實現 Make 方法

就結果而言確行可行，但想了想會發現飲料的製作流程大致相同

1. 準備杯子
2. 加入倒入飲料，配料
3. 蓋上蓋子後搖一搖

這中間可能會有不一樣的只有第 2 點會根據需求變化

這時可以使用模板方法來實現

> 定義一個製作飲料的流程模板 Make 並將第 2 點定義為抽象，各自飲料的類別繼承這個模板並實現第 2 點的動作

#### 程式範例

定義飲料的模板

```CSharp
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
```

定義冰綠茶及熱紅茶

```CSharp
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
```

製作飲料

```CSharp
Drink drink = new GreenTea();
drink.Make();
Drink drink2 = new HotBlackTea();
drink2.Make();
```

輸出結果

```
prepare cup
add green tea
add sugar
add ice
shake
prepare cup
add hot black tea
add sugar
shake
```
