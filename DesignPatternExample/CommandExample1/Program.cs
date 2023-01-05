// 創建接收者及命令

IReceiver tv = new TV();
IReceiver fan = new Fan();
OpenCommand tvOpenCommand = new OpenCommand(tv);
OpenCommand fanCommand = new OpenCommand(fan);
CloseCommand tvCloseCommand = new CloseCommand(tv);
CloseCommand fanCloseCommand = new CloseCommand(fan);

// 創建遙控器並設置命令
Controller controller = new Controller();
controller.SetOpenFanCommand(fanCommand);
controller.SetOpenTVCommand(tvOpenCommand);
controller.SetCloseTVCommand(tvCloseCommand);
controller.SetCloseFanCommand(fanCloseCommand);

// 按下按鈕
controller.OpenTVButtonPress();
controller.CloseTVButtonPress();
controller.OpenFanButtonPress();
controller.CloseFanButtonPress();

interface ICommand
{
    void Execute();
}

interface IReceiver
{
    void Open();
    void Close();
}

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

class Controller
{
    private ICommand[] openCommands = new ICommand[2];
    private ICommand[] closeCommands = new ICommand[2];

    public void SetOpenTVCommand(ICommand command)
    {
        openCommands[0] = command;
    }

    public void SetOpenFanCommand(ICommand command)
    {
        openCommands[1] = command;
    }

    public void SetCloseTVCommand(ICommand command)
    {
        closeCommands[0] = command;
    }

    public void SetCloseFanCommand(ICommand command)
    {
        closeCommands[1] = command;
    }

    public void OpenTVButtonPress()
    {
        openCommands[0].Execute();
    }

    public void OpenFanButtonPress()
    {
        openCommands[1].Execute();
    }

    public void CloseTVButtonPress()
    {
        closeCommands[0].Execute();
    }

    public void CloseFanButtonPress()
    {
        closeCommands[1].Execute();
    }
}