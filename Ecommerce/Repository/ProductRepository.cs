using System.Collections.Generic;
using System.Linq;

public class ProductRepository
{
    private static List<Product> _products = new List<Product>()
    {
        new Product() 
        {
            Id = 1, Name = "Macbook Air", Description = "Diqka",
            PurchasePrice = 899, RetailPrice = 999, CategoryId = 1
        },
        new Product()
        {
            Id = 2, Name = "X1 Extreme", Description = "Apet diqka",
            PurchasePrice = 1500, RetailPrice = 1850, CategoryId = 1
        }
    };

    public static void Insert(Product product)
    {
        if (_products.Any())
        {
            int lastId = _products.Last().Id;
            product.Id = ++lastId;
            _products.Add(product);
        }
        else
        {
            product.Id = 1;
            _products.Add(product);
        }
    }

    public static void Update(Product product)
    {
        _products.Remove(_products.FirstOrDefault(x=>x.Id == product.Id));
        _products.Add(product);
    }

    public static void Remove(Product product)
    {
         _products.Remove(product);
    }

    public static List<Product> GetProducts()
    {
        return _products;
    }

    public static Product GetProductById(int id)
    {
        //return _products.Single(x=>x.Id == id);
        foreach(var item in _products)
            if(item.Id == id)
                return item;

        throw new System.Exception();
    }

    public static int CountProductsByCategoryId(int id)
    {
        return _products.Count(x=>x.CategoryId == id);
    }

    public static bool IsEmpty()
    {
        if (_products.Any())
        {
            return true;
        }

        return fale;
    }
}