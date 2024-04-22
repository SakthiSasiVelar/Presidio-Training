using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pizza_Store_Model_library;

namespace Pizza_Store_BL_Library
{
    public interface IOrderService 
    {
        public int AddOrder(Order order);

        public int UpdateOrder(Order order);

        public int DeleteOrder(int orderId);

        public Order GetOrderById(int orderId);

        public List<Order> GetAllOrders();
    }
}
