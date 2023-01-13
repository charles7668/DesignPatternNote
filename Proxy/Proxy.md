# 代理模式(Proxy)

## 定義

為另一個物件提供代理以控制對它的訪問

## 模式詳解

代理模式是用戶不會對實際的目標直接發送請求，而是透過一個中間的代理層來發送請求並回傳資料，使得中間得代理層能對此請求進行額外的控制

### 結構示意圖

![proxy diagram](./Image/proxy%20diagram.jpg)

## 埸景問題與示例

### 1. 使用來理來平衡負載

有兩台伺服器 server1 , server2，每台伺服器只能接收 3 個 request，使用代理當 server1 達到 3 個 request 後自動轉發到 server2

#### 思考

> 首先可能會先建立一個 server 的介面，並建立 server1,server2,proxy，proxy 內要建立一個計數器來計算是否達到 3 次 request 來決定是否轉發，用戶只需持續對 proxy 進行請求即可

#### 程式

建立 Server 介面

```CSharp
interface IServer
{
    void Request();
}
```

建立 Server 及 ServerProxy 的 class

```CSharp
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
```

用戶對 ServerProxy 進行請求

```CSharp
IServer server = new ServerProxy();
server.Request();
server.Request();
server.Request();
server.Request();
server.Request();
server.Request();
```

輸出結果

```
Server1 Request
Server1 Request
Server1 Request
Server2 Request
Server2 Request
Server2 Request
```
