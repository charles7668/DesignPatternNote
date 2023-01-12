# 迭代器模式

## 定義

提供一個順序訪問聚合物件內元素，且不必曝露該物件內部表示的方法

## 模式詳解

在操作聚合類型的物件時，例如 list,array,collection...，有可能會遇到的問題是訪問物件內部元素的方法不一樣，所以使用者可能要針對每種容器寫一個訪問的方法，而迭代器模式就是為了解決這個問題使用的，提供一個相同的介面始得使用者可以用同一種固定的方法來進行訪問，這樣使用者就不需為每種容器寫一個特定的訪問方式。

### 結構示意圖

![iterator diagram](./Image/iterator%20diagram.jpg)

## 埸景問題與示例

### 1. 整合兩間公司的產品資料

> 現在有兩間公司提供了格式差不多的產品資料表給你，希望你可以將資料整合起來，但他們內部存放資料的容器不一樣，一個使用 Array，一個使用 List。

#### 思考

> 現在只有兩家公司，直接訪問其實也不複雜，但今天如果再加入一家公司時，會發現每次有變動，使用者端的程式就需要調整一次，所以可以使用迭代器模式來解決問題，以固定使用者訪問元素的方法。

#### 程式

建立 Iterator 介面

```CSharp
interface Iterator
{
    void First();
    void Next();
    bool IsDone();
    Product CurrentItem();
}
```

建立聚合物件的介面

```CSharp
interface Aggregate
{
    Iterator CreateIterator();
}
```

建立產品資訊的類別

```CSharp
class Product
{
    public string Name { get; set; }
    public int Number { get; set; }
}
```

建立 Iterator 的實現

```CSharp
class ProductArrayIterator : Iterator
{
    Product[] products;
    int position;

    public ProductArrayIterator(Product[] products)
    {
        this.products = products;
        position = 0;
    }

    public void First()
    {
        position = 0;
    }

    public void Next()
    {
        position++;
    }

    public bool IsDone()
    {
        if (position >= products.Length)
            return true;
        else
            return false;
    }

    public Product CurrentItem()
    {
        return products[position];
    }
}

class ProductListIterator : Iterator
{
    List<Product> products;
    int position = 0;

    public ProductListIterator(List<Product> products)
    {
        this.products = products;
        position = 0;
    }

    public void First()
    {
        position = 0;
    }

    public void Next()
    {
        position++;
    }

    public bool IsDone()
    {
        if (position >= products.Count)
            return true;
        else
            return false;
    }

    public Product CurrentItem()
    {
        return products[position];
    }
}
```

建立兩家公司並實現 Aggregate

```CSharp
class CompanyA : Aggregate
{
    Product[] products;

    public CompanyA()
    {
        products = new Product[3];
        products[0] = new Product { Name = "Product A1", Number = 1 };
        products[1] = new Product { Name = "Product A2", Number = 2 };
        products[2] = new Product { Name = "Product A3", Number = 3 };
    }

    public Iterator CreateIterator()
    {
        return new ProductArrayIterator(products);
    }
}

class CompanyB : Aggregate
{
    List<Product> products;

    public CompanyB()
    {
        products = new List<Product>
        {
            new Product { Name = "Product B1", Number = 1 },
            new Product { Name = "Product B2", Number = 2 },
            new Product { Name = "Product B3", Number = 3 }
        };
    }

    public Iterator CreateIterator()
    {
        return new ProductListIterator(products);
    }
}
```

使用者遍歷兩家公司資料

```CSharp
Aggregate companyA = new CompanyA();
var iteratorA = companyA.CreateIterator();
Aggregate companyB = new CompanyB();
var iteratorB = companyB.CreateIterator();
while (!iteratorA.IsDone())
{
    Console.WriteLine(iteratorA.CurrentItem().Name);
    iteratorA.Next();
}

while (!iteratorB.IsDone())
{
    Console.WriteLine(iteratorB.CurrentItem().Name);
    iteratorB.Next();
}
```

輸出結果

```
Product A1
Product A2
Product A3
Product B1
Product B2
Product B3
```
