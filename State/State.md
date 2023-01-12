# 狀態模式(State)

## 定義

允許一個物件在其內部狀態改變時改變其行為，該物件看起來像改變其類別

## 模式詳解

狀態模式將要執行的動作封裝成一個繼承 State 的類別，並可在特定狀況下去設定要執行的狀態行為

### 結構示意圖

![state diagram](./Image/state%20diagram.jpg)

## 應用埸景與示例

### 1. 個人簡易投票功能

在沒投票時顯示請投票，投了一票時顯示投票完成，投了二票顯示重複投票

#### 思考

> 功能本身其實很簡單，用個 if-else 都可以做到，但較不利於後續的修改，這裡就用狀態模式把三種票數的狀態設計成獨立的類別去執行。

#### 程式

建立狀態行為

```CSharp
interface IState
{
    void Handle();
}

class NoCountState : IState
{
    public void Handle()
    {
        Console.WriteLine("請投票");
    }
}

class OneCountState : IState
{
    public void Handle()
    {
        Console.WriteLine("投票已經完成");
    }
}

class TwoCountState : IState
{
    public void Handle()
    {
        Console.WriteLine("重複投票");
    }
}
```

建立 User 管理票數及狀態

```CSharp
class User
{
    IState state;
    private int voteCount = 0;

    public User()
    {
        state = new NoCountState();
    }

    public void Vote()
    {
        voteCount++;
        if (voteCount == 1)
        {
            state = new OneCountState();
        }
        else
        {
            state = new TwoCountState();
        }
    }

    public void PrintState()
    {
        state.Handle();
    }
}
```

輸出狀態並試著投票

```CSharp
User user = new User();
user.PrintState();
user.Vote();
user.PrintState();
user.Vote();
user.PrintState();
```

輸出結果

```
請投票
投票已經完成
重複投票
```
