# 組合模式(Composite)

## 定義

將物件組合成樹型結構以表示“部分-整體”的層次結構，組合模式使得用戶對單個物件和組合物件的使用具有一致性

## 模式詳解

組合模式設計的一個抽象類，並使組合物件及葉節點都繼承這個抽象類別，使得使用者在使用時無需詳細區分是否為葉節點

### 結構示意圖

![composite diagram](./Image/composite%20diagram.jpg)

## 應用埸景與示例

### 1. 建立一個樹

使用程式建立一個樹狀結構，如下圖
![figure1](./Image/composite%20example1%20figure1.jpg)

#### 思考

> 在不使用組合模式的情況下可能會設計兩種類別，一個可以包含子物件，一個不能，並在使用時會區分兩種物件
>
> 使用組合模式的情況，會抽出一個 Component 的抽象類，並將所有的節點都當作 Component

#### 程式

建立抽象類別

```CSharp
abstract class Component
{
    public string NodeName { get; set; }

    public abstract void AddChild(Component child);

    public abstract void Print(string prefix);
}
```

建立 Leaf Node 、 Composite Node

```CSharp
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
```

使用者生成樹

```CSharp
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
```

輸出結果

```
root
 leaf
 Composite
  leaf
 leaf
```
