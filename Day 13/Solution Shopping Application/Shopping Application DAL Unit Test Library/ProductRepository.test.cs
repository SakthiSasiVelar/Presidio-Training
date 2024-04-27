using Shopping_Model_Library;

using Shopping_DAL_Library;
using NUnit.Framework.Constraints;
using Shopping_Model_Library.Exceptions;

namespace Shopping_Application_DAL_Unit_Test_Library
{
    public class ProductRepositoryTests
    {
        IRepository<int, Product> productRepository;
        Product product;
        [SetUp]
        public void Setup()
        {
            productRepository = new ProductRepository();
            product = new Product(1 , 20 , "cookies" , 5);
            var result = productRepository.Add(product);
        }

        [Test]
        public async Task  AddRepositorySuccessTest()
        {
            var result = await productRepository.Add(new Product(2, 50, "chocolate", 5));
            Assert.AreEqual(2 , result.Id);

        }

        [Test]
        public async Task GetByKeySucessTest()
        {
            var result = await productRepository.GetByKey(1);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]

        public async Task GetByKeyExceptionTest()
        {
            var result = Assert.ThrowsAsync<NoProductWithGivenIdException>(() => productRepository.GetByKey(5));
            Assert.AreEqual("Product with the given Id is not present" , result.Message);
        }

        [Test]
        public async Task DeleteSucessTest() {
            var result = await productRepository.Delete(1);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]
        public async Task DeleteExceptionTest()
        {
            var result = Assert.ThrowsAsync<Exception>(()=> productRepository.Delete(10));
            Assert.AreEqual("Product with the given Id is not present", result.Message);
        }

        [Test]
        public async Task UpdateSucessTest()
        {
            product.Name = "cake";
            var result = await productRepository.Update(product);
            Assert.AreEqual(1 , result.Id);
        }
        [Test]

        public async Task UpdateExceptionTest()
        {
            Product newProduct = new Product(2, 50, "chocolate", 5);
            var result = Assert.ThrowsAsync<NoProductWithGivenIdException>(() => productRepository.Update(newProduct));
            Assert.AreEqual("Product with the given Id is not present", result.Message);

        }

        [Test]

        public async Task GetAll()
        {
            var result = await productRepository.GetAll();
            Assert.AreEqual(1 , result.Count);
        }
    }
}