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
    public class CartItemRepositoryTests
    {
        IRepository<int, CartItem> cartItemRepository;
        CartItem cartItem;

        [SetUp]
        public void SetUp() { 
            cartItemRepository = new CartItemRepository();
            cartItem = new CartItem(1 , 101 , 201 , new Product() , 5 , 20.0 , 5 , new DateTime(2000 , 1, 10));
            cartItemRepository.Add(cartItem);
        }

        [Test]

        public async Task GetCartItemByKeySuccessTest()
        {
            var result = await cartItemRepository.GetByKey(1);
            Assert.AreEqual(1, result.Id);
        }

        [Test]

        public async Task GetCartItemByKeyExceptionTest() {

            var result = Assert.ThrowsAsync<NoCartItemWithGivenIdException>(()=> cartItemRepository.GetByKey(10));
            Assert.AreEqual("Cart Item with the given Id is not present", result.Message);
        }

        [Test]

        public async Task DeleteCartItemTest()
        {
            var result = await cartItemRepository.Delete(1);
            Assert.AreEqual(1, result.Id);
        }

        [Test]

        public async Task DeleteCartItemExceptionTest()
        {
            var result = Assert.ThrowsAsync<Exception>(()=> cartItemRepository.Delete(10));
            Assert.AreEqual("Cart Item with the given Id is not present", result.Message);
        }

        [Test]

        public async Task UpdateCartItemSuccessTest()
        {
            cartItem.Price = 100.0;
            var result = await cartItemRepository.Update(cartItem);
            Assert.AreEqual(1, result.Id);
        }

        [Test]

        public async Task UpdateCartItemExceptionTest()
        {
            CartItem cartItem2 = new CartItem(2, 101, 201, new Product(), 5, 20.0, 5, new DateTime(2000, 1, 10));
            var result = Assert.ThrowsAsync<NoCartItemWithGivenIdException>(()=>cartItemRepository.Update(cartItem2));
            Assert.AreEqual("Cart Item with the given Id is not present", result.Message);
        }
    }
}
