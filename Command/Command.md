# 命令模式(Command)

## 定義

將請求封裝成一個物件，從而使你可以用不同的請求對其它物件進行參數化，排隊或記錄請求，以及支持撤銷動作

## 模式詳解

主要思路就是把命令給封裝起來，讓使用者不需關心內部如何實現，只需透過 Excute 的方法來執行，例如遙控器就是個很好的例子，使用者按下按鈕就可以完成需要的動作

### 結構示意圖

![command diagram](Image/Command%20Diagram.jpg)

## 埸景問題與示例

### 1. 設計一個遙控器可以開關電視及電風扇

首先先建立一個 Command 的介面 `ICommand`

```CSharp
interface ICommand
{
    void Execute();
}
```

創建接收者的介面

```CSharp
interface IReceiver
{
    void Open();
    void Close();
}
```

建立關、關命令，並開放傳入對應的接收者

```CSharp
class OpenCommand : ICommand
{
    private IReceiver _receiver;

    public OpenCommand(IReceiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Open();
    }
}

class CloseCommand : ICommand
{
    private IReceiver _receiver;

    public CloseCommand(IReceiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Close();
    }
}
```

建立接收者 TV、Fan

```CSharp
class TV : IReceiver
{
    public void Open()
    {
        Console.WriteLine("tv is opened");
    }

    public void Close()
    {
        Console.WriteLine("tv is closed");
    }
}

class Fan : IReceiver
{
    public void Open()
    {
        Console.WriteLine("fan is opened");
    }

    public void Close()
    {
        Console.WriteLine("fan is closed");
    }
}
```

建立遙控器

```CSharp
class TV : IReceiver
{
    public void Open()
    {
        Console.WriteLine("tv is opened");
    }

    public void Close()
    {
        Console.WriteLine("tv is closed");
    }
}

class Fan : IReceiver
{
    public void Open()
    {
        Console.WriteLine("fan is opened");
    }

    public void Close()
    {
        Console.WriteLine("fan is closed");
    }
}
```

Client 建立接收者及命令

```CSharp
IReceiver tv = new TV();
IReceiver fan = new Fan();
OpenCommand tvOpenCommand = new OpenCommand(tv);
OpenCommand fanCommand = new OpenCommand(fan);
CloseCommand tvCloseCommand = new CloseCommand(tv);
CloseCommand fanCloseCommand = new CloseCommand(fan);
```

創建搖控器並組合命令

```CSharp
Controller controller = new Controller();
controller.SetOpenFanCommand(fanCommand);
controller.SetOpenTVCommand(tvOpenCommand);
controller.SetCloseTVCommand(tvCloseCommand);
controller.SetCloseFanCommand(fanCloseCommand);
```

使用者按下按鈕

```CSharp
controller.OpenTVButtonPress();
controller.CloseTVButtonPress();
controller.OpenFanButtonPress();
controller.CloseFanButtonPress();
```

輸出結果

```
tv is opened
tv is closed
fan is opened
fan is closed
```
