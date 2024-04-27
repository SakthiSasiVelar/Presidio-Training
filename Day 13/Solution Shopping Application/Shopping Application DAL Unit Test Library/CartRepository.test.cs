using NuGet.Frameworks;
using NUnit.Framework.Interfaces;
using Shopping_DAL_Library;
using Shopping_Model_Library;
using Shopping_Model_Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Application_DAL_Unit_Test_Library
{
    public class CartRepositoryTests
    {
        IRepository<int, Cart> cartRepository;
        Cart cart;

        [SetUp]
        public void SetUp()
        {
             cartRepository = new CartRepository();
             List<CartItem> items = new List<CartItem>();
            cart = new Cart(1, 101, new Customer(), items);
            cartRepository.Add(cart);   
        }
        [Test]

        public async Task GetByKeySuccessTest()
        {
            var result = await cartRepository.GetByKey(1);
            Assert.AreEqual(1,result.Id);
        }

        [Test]

        public async Task GetByKeyExceptionTest()
        {
            var result = Assert.ThrowsAsync<NoCartWithGivenIdException>(() => cartRepository.GetByKey(10));
            Assert.AreEqual("Cart with the given Id is not present", result.Message);
        }
        [Test]

        public async Task DeleteSucccessTest()
        {
            var result = await cartRepository.Delete(1);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]

        public async Task DeleteExceptionTest()
        {
            var result = Assert.ThrowsAsync<Exception>(()=> cartRepository.Delete(10));
            Assert.AreEqual("Cart with the given Id is not present", result.Message);
        }

        [Test]

        public async Task UpdateSuccessTest()
        {
            cart.CustomerId = 102;
            var result = await cartRepository.Update(cart);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]

        public async Task UpdateExceptionTest()
        {
            List<CartItem> items = new List<CartItem>();
            Cart cart1 = new Cart(5, 101, new Customer(), items);
            var result = Assert.ThrowsAsync<NoCartWithGivenIdException>(()=>cartRepository.Update(cart1));
            Assert.AreEqual("Cart with the given Id is not present", result.Message);
        }
    }
}
