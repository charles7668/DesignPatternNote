# 外觀模式 (Facade)

## 定義

為子系統的一組介面提供一個一致的介面，Facade 模式定義了一個更高級的介面使子系統更容易使用

## 模式詳解

外觀模式的目的是為了減少外部與子系統間直接的交互，鬆散耦合，從而讓外部能更簡單的使用子系統，對於使用者來說也可以不需知道內部的實現

- 未使用外觀模式  
  ![unuse facade](./Image/unuse%20facade%20diagram.jpg)
- 使用外觀模式  
  ![use facade](./Image/use%20facade%20diagram.jpg)

### 類別圖

![facade diagram](./Image/facade%20diagram.jpg)

## 埸景問題與示例

### 1. 個人家庭戲院

個人的家庭戲院要啟動可能有很多的設備需要按下開機鍵並進行設定

#### 思考解決方法

首先思考一下沒有使用模式的解決辦法

> 由使用者一個一個對設備進行開啟

這時就會發現做為使用者你需要知道怎麼操作設備而且也比較麻煩

再來思考一下使用模式的解決辦法

> 把這些動作整合進一個控制器或遙控器

這時你發現所有的動作都變得很輕鬆，只需要按下一個 On 就可以啟動所有的機器

#### 程式部分

建立喇叭及投影機的 class

```CSharp
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
```

建立控制器

```CSharp
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
```

使用者透過控制器來啟動所有裝置

```CSharp
Controller controller = new Controller();
controller.On();
```

輸出結果

```
Speaker on
projector on
```
