// See https://aka.ms/new-console-template for more information

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