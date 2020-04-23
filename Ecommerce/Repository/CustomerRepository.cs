using System.Collections.Generic;
using System.Linq;

public class CustomerRepository
{
    private static List<Customer> _customers = new List<Customer>()
    {
        new Customer() 
        {
            Id = 1, FirstName = "Dren", LastName = "Haziri", PhoneNumber = "044123123",
            Email = "dren@haziri.com", Address = "Rruga qysh t'kom qef une"
        },
        new Customer()
        {
            Id = 2, FirstName = "Edi", LastName = "Hasaj", PhoneNumber = "049987987",
            Email = "edi@hasaj.com", Address = "Rruga e tigrave"
        }
    };

    public static void Insert(Customer customer)
    {
        if (_customers.Any())
        {
            int lastId = _customers.Last().Id;
            customer.Id = ++lastId;
            _customers.Add(customer);
        }
        else
        {
            customer.Id = 1;
            _customers.Add(customer);
        }
    }

    public static void Update(Customer customer)
    {
        _customers.Remove(_customers.FirstOrDefault(x=>x.Id == customer.Id));
        _customers.Add(customer);
    }

    public static void Remove(Customer customer)
    {
         _customers.Remove(customer);
    }

    public static List<Customer> GetCustomers()
    {
        return _customers;
    }
    
    public static Customer GetCustomerById(int id)
    {
        return _customers.Single(x=>x.Id == id);
    }
}