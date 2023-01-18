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

// 輸出訂單
Console.WriteLine("訂單1");
Console.WriteLine(order1.Customer);
Console.WriteLine(order1.Date);
Console.WriteLine(order1.Product);
Console.WriteLine(order1.Number);

Console.WriteLine("訂單2");
Console.WriteLine(order2.Customer);
Console.WriteLine(order2.Date);
Console.WriteLine(order2.Product);
Console.WriteLine(order2.Number);

Console.WriteLine("訂單3");
Console.WriteLine(order3.Customer);
Console.WriteLine(order3.Date);
Console.WriteLine(order3.Product);
Console.WriteLine(order3.Number);

interface Order
{
    string Date { get; set; }
    string Customer { get; set; }
    string Product { get; set; }
    int Number { get; set; }
    Order Clone();
}

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