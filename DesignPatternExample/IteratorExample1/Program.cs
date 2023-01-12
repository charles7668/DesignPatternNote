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

interface Iterator
{
    void First();
    void Next();
    bool IsDone();
    Product CurrentItem();
}

interface Aggregate
{
    Iterator CreateIterator();
}

class Product
{
    public string Name { get; set; }
    public int Number { get; set; }
}

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