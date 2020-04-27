

using System.Collections.Generic;
using System.Linq;

public class OrderRepository
{
    private static List<Order> _orders = new List<Order>();

    public static void Insert(Order order)
    {
        if (!_orders.Any())
        {
            order.Id = 1;
            _orders.Add(order);
        }
        else
        {
            int lastId = _orders.Last().Id;
            order.Id = ++lastId;
            _orders.Add(order);
        }
        
    }

    public static void Update(Order order)
    {
        _orders.Remove(_orders.Single(x=>x.Id == order.Id));
        _orders.Add(order);
    }

    public static void Remove(Order order)
    {
        _orders.Remove(order);
    }

    public static List<Order> GetOrders()
    {
        return _orders;
    }

    public static Order GetOrderById(int id)
    {
        return _orders.FirstOrDefault(x=>x.Id == id);
    }
}