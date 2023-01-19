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

interface IStrategy
{
    double Calc(double a, double b);
}

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