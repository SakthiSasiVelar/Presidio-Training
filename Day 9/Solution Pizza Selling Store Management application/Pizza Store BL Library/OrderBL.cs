using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pizza_Store_Model_library;

using Pizza_Store_DAL_library;

using Pizza_Store_Exception_Library;

namespace Pizza_Store_BL_Library
{
    public  class OrderBL : IOrderService
    {
        readonly OrderRepository _orderRepository;

        public OrderBL()
        {
            _orderRepository = new OrderRepository();
        }

        public int AddOrder(Order order)
        {
            Order result = _orderRepository.Add(order);
            if(result != null)
            {
                return result.Id;                                  
            }
            throw new AddOrderException();
        }

        public int DeleteOrder(int orderId)
        {
            Order result = _orderRepository.Delete(orderId);
            if(result != null)
            {
                return result.Id;
            }
            throw new DeleteOrderException();
        }

        public List<Order> GetAllOrders()
        {
            List<Order> result = _orderRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new GetAllOrderException();
        }

        public Order GetOrderById(int orderId)
        {
            Order result = _orderRepository.Get(orderId);
            if( result != null )
            {
                return result;
            }
            throw new GetOrderException();
        }

        public int UpdateOrder(Order order)
        {
            Order result = _orderRepository.Update(order);
            if(result != null)
            {
                return result.Id;
            }
            throw new UpdateOrderException();
        }
    }
}
