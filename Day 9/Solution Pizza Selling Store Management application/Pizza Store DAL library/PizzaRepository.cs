using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pizza_Store_Model_library;

namespace Pizza_Store_DAL_library
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        readonly Dictionary<int, Pizza> _pizzaCart;

        public PizzaRepository()
        {
            _pizzaCart = new Dictionary<int, Pizza>();
        }

        int GenerateId()
        {
            if (_pizzaCart.Count == 0) return 1;
            int id = _pizzaCart.Keys.Max();
            return ++id;
        }
        public Pizza Add(Pizza item)
        {
            if(_pizzaCart.ContainsValue(item))
            {
                return null; 
            }
            item.Id = GenerateId();
            _pizzaCart.Add(item.Id, item);
            return item;
        }

        public Pizza Delete(int key)
        {
            if(_pizzaCart.ContainsKey(key))
            {
                Pizza pizza = _pizzaCart[key];
                _pizzaCart.Remove(key);
                return pizza;
            }
            return null;
            
        }

        public Pizza Get(int key)
        {
            if (_pizzaCart.ContainsKey(key))
            {
                return _pizzaCart[key];
            }
            return null;
           
        }

        public List<Pizza> GetAll()
        {
            if(_pizzaCart.Count > 0)
            {
                return _pizzaCart.Values.ToList();
            }
            return null;
            
        }

        public Pizza Update(Pizza item)
        {
            if (_pizzaCart.ContainsKey(item.Id))
            {
                _pizzaCart[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
