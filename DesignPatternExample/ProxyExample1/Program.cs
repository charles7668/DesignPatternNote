IServer server = new ServerProxy();
server.Request();
server.Request();
server.Request();
server.Request();
server.Request();
server.Request();

interface IServer
{
    void Request();
}

class Server : IServer
{
    private int _index = 0;
    public Server(int index)
    {
        _index = index;
    }
    public void Request()
    {
        Console.WriteLine($"Server{_index} Request");
    }
}

class ServerProxy : IServer
{
    private int _counter = 0;
    private IServer[] _servers;

    public ServerProxy()
    {
        _servers = new IServer[] { new Server(1), new Server(2) };
    }

    public void Request()
    {
        if (_counter < 3)
        {
            _servers[0].Request();
        }
        else
        {
            _servers[1].Request();
        }

        _counter++;
    }
}