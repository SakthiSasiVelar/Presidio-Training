using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pizza_Store_Model_library;

namespace Pizza_Store_DAL_library
{
    public class OrderRepository : IRepository<int, Order>
    {
        readonly Dictionary<int, Order> _orders;

        public OrderRepository()
        {
            _orders = new Dictionary<int, Order>();
        }

        int GenerateId()
        {
            if (_orders.Count == 0) return 1;
            int id = _orders.Keys.Max();
            return ++id;
        }
        public Order Add(Order item)
        {
            if (_orders.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _orders.Add(item.Id, item);
            return item;
        }

        public Order Delete(int key)
        {
            if (_orders.ContainsKey(key))
            {
                Order Order = _orders[key];
                _orders.Remove(key);
                return Order;
            }
            return null;
        }

        public Order Get(int key)
        {
            if (_orders.ContainsKey(key))
            {
                return _orders[key];
            }
            return null;
        }

        public List<Order> GetAll()
        {
            if (_orders.Count > 0)
            {
                return _orders.Values.ToList();
            }
            return null;
        }

        public Order Update(Order item)
        {
            if (_orders.ContainsKey(item.Id))
            {
                _orders[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}

