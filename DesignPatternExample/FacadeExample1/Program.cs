Controller controller = new Controller();
controller.On();

class Speaker
{
    public void On()
    {
        Console.WriteLine("Speaker on");
    }
}

class Projector
{
    public void On()
    {
        Console.WriteLine("projector on");
    }
}

class Controller
{
    public void On()
    {
        Speaker speaker = new Speaker();
        Projector projector = new Projector();
        speaker.On();
        projector.On();
    }
}