# 策略模式(Strategy)

## 定義

封裝一系列算法，並使他們可以相互替換，本模式使得算法可獨立於使用者而變化。

## 模式詳解

程式內很多時候會遇到需要許多 if-else 來進行判斷並執行不同的工作，本模式將執行的工作抽象出來，使得策略可獨立於類別進行修改，且讓策略移至更上層進行選擇，使得類別本身無需關心策略的選擇。

### 結構示意圖

![strategy diagram](./Image/strategy%20diagram.jpg)

## 應用埸景與示例

### 1. 簡易計算機

設計一個可計算 2 個數之間加減乘除的計算機

### 程式

首先訂義計算的策略界面

```CSharp
interface IStrategy
{
    double Calc(double a, double b);
}
```

建立 +-\*/ 的計算策略

```CSharp
class Add : IStrategy
{
    public double Calc(double a, double b)
    {
        return a + b;
    }
}

class Multiply : IStrategy
{
    public double Calc(double a, double b)
    {
        return a * b;
    }
}

class Divide : IStrategy
{
    public double Calc(double a, double b)
    {
        return a / b;
    }
}

class Subtract : IStrategy
{
    public double Calc(double a, double b)
    {
        return a - b;
    }
}
```

建立計算機用來持有並執行策略

```CSharp
class Calculator
{
    private IStrategy _strategy;
    public double Result { get; set; }

    public Calculator()
    {
        _strategy = new Add();
    }

    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Calc(double a, double b)
    {
        Result = _strategy.Calc(a, b);
    }
}
```

使用者使用計算機進行計算

```CSharp
//建立計算機

Calculator calculator = new Calculator();
// 計算 2+5
calculator.SetStrategy(new Add());
calculator.Calc(2, 5);
Console.WriteLine("2+5=" + calculator.Result);
// 計算 10-8
calculator.SetStrategy(new Subtract());
calculator.Calc(10, 8);
Console.WriteLine("10-8=" + calculator.Result);
// 計算 10*5
calculator.SetStrategy(new Multiply());
calculator.Calc(10, 5);
Console.WriteLine("10*5=" + calculator.Result);
// 計算 20/2
calculator.SetStrategy(new Divide());
calculator.Calc(20, 2);
Console.WriteLine("20/2=" + calculator.Result);
```

輸出結果

```
2+5=7
10-8=2
10*5=50
20/2=10
```
