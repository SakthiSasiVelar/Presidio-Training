using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shopping_DAL_Library;

using Shopping_Model_Library;

namespace Shopping_BL_Library
{
    public interface ICartService
    {
        public int AddCart(Cart item);

        public double GetCartItemsAmount(Cart item);
    }
}
