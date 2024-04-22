using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pizza_Store_Model_library;

namespace Pizza_Store_BL_Library
{
    public interface IPizzaService
    {
        public int  AddPizza(Pizza pizza);

        public int UpdatePizza(Pizza pizza);

        public int DeletePizza(int pizzaId);

        public Pizza GetPizzaById(int pizzaId);

        public List<Pizza> GetAllPizzaList();
    }
}
