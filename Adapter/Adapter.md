# 適配器模式(Adapter)

## 定義

將一個類別的介面轉換為客戶預期的另一個介面，使得原本因介面不相容而不能一起工作的類別間能一起工作

## 模式詳解

適配器模式比較好理解的例子是插頭與插座，不同國家在這方面都有自己的規範，所以一個外國買的電器用品可能會在買回來後發現沒辦法插到現有的插座上，這時就會需要一個轉接頭，而這個轉接頭就是現在要提的"適配器"。

適配器有兩種實現方式，分別是`物件適配器(Object-Adapter)`及`類別適配器(Class-Adapter)`，其差別是物件適配器使用組合(Composite)的方式將適配對像做為成員來進行使用，類別適配器則透過繼承來讓自已成為被適配對像，並在此基礎上增加目標的成員函數。

### 結構示意圖

1. 物件適配器
   ![object adapter diagram](Image/object%20adapter%20diagram.jpg)

2. 類別適配器
   ![class adapter diagram](Image/class%20adapter%20diagram.jpg)

## 埸景問題與示例

### 1. 今天對方提供了一個內有 GetData 的函式庫 Test，但你的使用端希望使用的是 GetTemprature 來方辨自己判斷這個資料是溫度

首先建立函式庫 Test

```CSharp
class Test
{
    public int GetData()
    {
        return 10;
    }
}
```

建立 Target 介面

```CSharp
interface ITarget
{
    int GetTemperature();
}
```

建立 Adapter 實現 Target 介面，並將要適配的 library 傳入

```CSharp
class Adapter : ITarget
{
    private Test _test;

    public Adapter(Test test)
    {
        _test = test;
    }

    public int GetTemperature()
    {
        return _test.GetData();
    }
}
```

使用者使用

```CSharp
Test testLibrary = new Test();
ITarget target = new Adapter(testLibrary);
Console.WriteLine("temperature : " + target.GetTemperature());
```

輸出結果

```
temperature : 10
```
