
using System.Collections.Generic;
using System.Linq;

public class SupplierRepository
{
    private static List<Supplier> _suppliers = new List<Supplier>()
    {
        new Supplier()
        {
            Id = 1, ContactName = "Hamdi Speci", ContactTitle = "Manager", CompanyName = "Speci Shpk",
            PhoneNumber = "044123456", Address = "Rruga e tyne"
        },
        new Supplier()
        {
            Id = 2, ContactName = "Ruzhdi Pula", ContactTitle = "Employee", CompanyName = "Pula Shpk",
            PhoneNumber = "044223344", Address = "Rruga e atij"
        }
    };

    public static void Insert(Supplier supplier)
    {
        if (_suppliers.Any())
        {
            int lastId = _suppliers.Last().Id;
            supplier.Id = ++lastId;
            _suppliers.Add(supplier);
        }
        else
        {
            supplier.Id = 1;
            _suppliers.Add(supplier);
        }
    }

    public static void Update(Supplier supplier)
    {
        _suppliers.Remove(_suppliers.Single(x=>x.Id == supplier.Id));
        _suppliers.Add(supplier);
    }

    public static void Remove(Supplier supplier)
    {
        _suppliers.Remove(supplier);
    }

    public static List<Supplier> GetSuppliers()
    {
        return _suppliers;
    }

    public static Supplier GetSupplierById(int id)
    {
        return _suppliers.FirstOrDefault(x=>x.Id == id);
    }
}