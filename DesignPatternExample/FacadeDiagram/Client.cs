using System.Runtime.InteropServices;

namespace FacadeDiagram;

public class Client
{
    private Facade _facade = new Facade();

    public void Main()
    {
        _facade.Test();
    }
}