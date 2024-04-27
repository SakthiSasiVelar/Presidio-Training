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
    public class CustomerRespositoryTests
    {
        IRepository<int, Customer> customerRepository;
        Customer customer;

        [SetUp]

        public void SetUp()
        {
            customerRepository = new CustomerRepository();
            customer = new Customer(1, "243535", 20);
            customerRepository.Add(customer);
        }

        [Test]

        public async Task GetCustomerByKeySuccessTest() {
            var result = await customerRepository.GetByKey(1);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]

        public async Task GetCustomerByKeyExceptionTest() {
            var result = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(()=>customerRepository.GetByKey(10));
            Assert.AreEqual("Customer with the given Id is not present", result.Message);

        }

        [Test]

        public async Task DeleteCustomerSuccessTest() {
            var result = await customerRepository.Delete(1);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]

        public async Task DeleteCustomerExceptionTest()
        {
            var result = Assert.ThrowsAsync<Exception>(()=>customerRepository.Delete(10));
            Assert.AreEqual("Customer with the given Id is not present", result.Message);
        }

        [Test]

        public async Task UpdateCustomerSuccessTest()
        {
            customer.Phone = "11234566";
            var result = await customerRepository.Update(customer);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]

        public async Task  UpdateCustomerExceptionTest()
        {
            Customer customer = new Customer(2, "12345", 5);
            var result = Assert.ThrowsAsync<NoCustomerWithGiveIdException>(()=> customerRepository.Update(customer));
            Assert.AreEqual("Customer with the given Id is not present", result.Message);
        }
    }
}
