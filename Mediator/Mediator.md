# 中介者模式(Mediator)

## 定義

定義一個中介物件來封裝一系列物件之間的交互，使物件之間的耦合鬆散，且可以獨立地改變它們之間的交互。中介者模式又叫調停模式，它是迪米特法則的典型應用。

## 模式詳解

不同類型的物件之間不直接進行交互，而是透過一個中介者來進行交互，彼此之間不需知道其它物件的具體實現，只需持有中介者即可。

### 結構示意圖

![mediator diagram](./Image/mediator%20diagram.jpg)

## 應用埸景與示例

### 1. 公司內聊天

公司簡單將職位分為 A,B,C，但聊天時不需要知道對方的詳細資料，可以指定編號進行訊息發送

#### 程式

建立中介者類

```CSharp
interface IMediator
{
    public void Register(Staff staff);
    public void Send(Staff staff, string message, int targetId);
}

class ConcreteMediator : IMediator
{
    private Dictionary<int, Staff> _staffs = new Dictionary<int, Staff>();

    public void Register(Staff staff)
    {
        _staffs.Add(staff.Id, staff);
    }

    public void Send(Staff staff, string message, int targetId)
    {
        _staffs[targetId].Receive(message, staff.Id);
    }
}
```

建立工作人員

```CSharp
abstract class Staff
{
    public int Id { get; protected set; }
    protected IMediator _mediator;

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public abstract void Receive(string message, int receiveId);
    public abstract void Send(string message, int targetId);
}

class StaffA : Staff
{
    public StaffA(int id)
    {
        Id = id;
    }

    public override void Receive(string message, int id)
    {
        Console.WriteLine("StaffA {0} received message {1} from {2}", Id, message, id);
    }

    public override void Send(string message, int targetId)
    {
        Console.WriteLine("StaffA {0} send message {1} to {2}", Id, message, targetId);
        _mediator.Send(this, message, targetId);
    }
}

class StaffB : Staff
{
    public StaffB(int id)
    {
        Id = id;
    }

    public override void Receive(string message, int id)
    {
        Console.WriteLine("StaffB {0} received message {1} from {2}", Id, message, id);
    }

    public override void Send(string message, int targetId)
    {
        Console.WriteLine("StaffB {0} send message {1} to {2}", Id, message, targetId);
        _mediator.Send(this, message, targetId);
    }
}

class StaffC : Staff
{
    public StaffC(int id)
    {
        Id = id;
    }

    public override void Receive(string message, int id)
    {
        Console.WriteLine("StaffC {0} received message {1} from {2}", Id, message, id);
    }

    public override void Send(string message, int targetId)
    {
        Console.WriteLine("StaffC {0} send message {1} to {2}", Id, message, targetId);
        _mediator.Send(this, message, targetId);
    }
}
```

註冊及聊天

```CSharp
// 創建中介者

IMediator mediator = new ConcreteMediator();
// 創建工作人員
Staff staff1 = new StaffA(0);
Staff staff2 = new StaffB(1);
Staff staff3 = new StaffC(2);

// 設定中介者
staff1.SetMediator(mediator);
staff2.SetMediator(mediator);
staff3.SetMediator(mediator);

// 註冊
mediator.Register(staff1);
mediator.Register(staff2);
mediator.Register(staff3);

// 發送消息
staff1.Send("test", 1);
staff2.Send("test2", 0);
staff3.Send("test3", 2);
```

輸出結果

```
StaffA 0 send message test to 1
StaffB 1 received message test from 0
StaffB 1 send message test2 to 0
StaffA 0 received message test2 from 1
StaffC 2 send message test3 to 2
StaffC 2 received message test3 from 2
```
