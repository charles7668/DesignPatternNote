Component root = new Composite("root");
Component leaf1 = new Leaf("leaf");
Component composite1 = new Composite("Composite");
Component leaf2 = new Leaf("leaf");
Component leaf3 = new Leaf("leaf");

root.AddChild(leaf1);
root.AddChild(composite1);
root.AddChild(leaf2);
composite1.AddChild(leaf3);

root.Print("");

abstract class Component
{
    public string NodeName { get; set; }

    public abstract void AddChild(Component child);

    public abstract void Print(string prefix);
}

class Leaf : Component
{
    public Leaf(string nodeName)
    {
        NodeName = nodeName;
    }

    public override void AddChild(Component child)
    {
        throw new NotSupportedException();
    }

    public override void Print(string prefix)
    {
        Console.WriteLine(prefix + NodeName);
    }
}

class Composite : Component
{
    private List<Component> components;

    public Composite(string nodeName)
    {
        NodeName = nodeName;
        components = new List<Component>();
    }

    public override void AddChild(Component child)
    {
        components.Add(child);
    }

    public override void Print(string prefix)
    {
        Console.WriteLine(prefix + NodeName);
        foreach (var component in components)
        {
            component.Print(prefix + " ");
        }
    }
}