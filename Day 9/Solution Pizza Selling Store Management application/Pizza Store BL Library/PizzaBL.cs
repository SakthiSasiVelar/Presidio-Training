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
    public class PizzaBL : IPizzaService
    {
        readonly PizzaRepository _pizzaRepository;

        public PizzaBL()
        {
            _pizzaRepository = new PizzaRepository();
        }
        public int AddPizza(Pizza pizza)
        {
            Pizza result = _pizzaRepository.Add(pizza);
            if(result != null)
            {
                return result.Id;
            }
            throw new AddPizzaException();
        }

        public int DeletePizza(int pizzaId)
        {
            Pizza result = _pizzaRepository.Delete(pizzaId);
            if(result != null)
            {
                return result.Id;
            }
            throw new DeletePizzaException();
        }

        public List<Pizza> GetAllPizzaList()
        {
            List<Pizza> result = _pizzaRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new GetAllPizzaException();
        }

        public Pizza GetPizzaById(int pizzaId)
        {
            Pizza result = _pizzaRepository.Get(pizzaId);
            if(result != null)
            {
                return result;
            }
            throw new GetPizzaException();
        }

        public int UpdatePizza(Pizza pizza)
        {
            Pizza result = _pizzaRepository.Update(pizza);
            if( result != null)
            { 
                return result.Id;
            }
            throw new UpdatePizzaException();
        }
    }
}
