# 原型模式(Prototype)

## 定義

使用原型的實例指定將要創建的物件類型，通過複製這個實例創建物件

## 模式詳解

會使物件的基礎介面類別具有 clone 方法，使得物件可以透過 clone 來創建一個資料相同的新物件

### 結構示意圖

![prototype diagram](./Image/prototype%20diagram.jpg)

## 應用埸景與示例

### 1. 訂單複製

有個客人今天下了一個新的訂單，但訂購內容基本都相同，只有日期不同

#### 程式

建立包含 Clone 的 Order 原型

```CSharp
interface Order
{
    string Date { get; set; }
    string Customer { get; set; }
    string Product { get; set; }
    int Number { get; set; }
    Order Clone();
}
```

具體的訂單類別

```CSharp
class OrderImpl : Order
{
    public string Date { get; set; }
    public string Customer { get; set; }
    public string Product { get; set; }
    public int Number { get; set; }

    public Order Clone()
    {
        var order = new OrderImpl();
        order.Date = Date;
        order.Customer = Customer;
        order.Product = Product;
        order.Number = Number;
        return order;
    }
}
```

建立訂單

```CSharp
//第一次的訂單,假設1990.01.01訂的
Order order1 = new OrderImpl();
order1.Customer = "Test";
order1.Date = "1990.01.01";
order1.Product = "test-product";
order1.Number = 10;

// 2000.01.01 又訂了一次但訂單內容相同
Order order2 = order1.Clone();
order2.Date = "2000.01.01";

// 2000.05.05 再訂一次相同的訂單
Order order3 = order1.Clone();
order3.Date = "2000.05.05";
```

輸出結果

```
訂單1
Test
1990.01.01
test-product
10
訂單2
Test
2000.01.01
test-product
10
訂單3
Test
2000.05.05
test-product
10
```
