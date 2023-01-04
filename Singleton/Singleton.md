# 單例模式(Singleton)

單例模式在設計上可能不符合某些設計原則，但在實務上是很常被使用且有效的方式

## 定義

確保全域只有一個實體，並提供一個全域的訪問點

## 模式詳解

單例模式會將建構式設為私有以確保物件不能透過 new 來被其它類別所創建，並提供一個取得物件實體的函數，通常會命名為 GetInstance 且會宣告成 static。
單例模式在創建物件實體時可簡單分為`懶漢模式` 與 `餓漢模式`

- 懶漢模式
  > 在物件實體被請求前都不會實例化
  >
  > - 優點
  >   - 物件如果沒有使用到則不會占用額外空間
  > - 缺點
  >   - 要另外處理多執行緒時可能會被重複創建實體的問題
- 餓漢模式
  > 在類別載入後就會進行實例化
  >
  > - 優點
  >   - 避免了多執行緒同步問題
  > - 缺點
  >   - 資源會在類別載入時就被占用

### 結構示意圖

![singleton diagram](Image/singleton%20diagram.jpg)

## 埸景問題與示例

### 1. 全域共用的應用程式設定

- 建立一個 class 並將建構式私有化
- 建立一個私有的物件實體
- 提供一個取得實體的方法

```CSharp
class Setting
{
    private static Setting _setting = null;

    public int Value = 0;

    private Setting()
    {
    }

    public static Setting GetInstance()
    {
        if (_setting == null)
        {
            _setting = new Setting();
        }

        return _setting;
    }
}
```

使用單例模式的實體

```CSharp
Setting setting = Setting.GetInstance();
Console.WriteLine(setting.Value);
```

輸出結果

```
0
```
