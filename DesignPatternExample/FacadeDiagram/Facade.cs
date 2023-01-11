namespace FacadeDiagram;

public class Facade
{
    private ModuleA _moduleA = new ModuleA();
    private ModuleB _moduleB = new ModuleB();

    public void Test()
    {
        _moduleA.TestA();
        _moduleB.TestB();
    }
}