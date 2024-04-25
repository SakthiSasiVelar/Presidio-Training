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
        public void AddRepositorySuccessTest()
        {
            var result = productRepository.Add(new Product(2, 50, "chocolate", 5));
            Assert.AreEqual(2 , result.Id);

        }

        [Test]
        public void GetByKeySucessTest()
        {
            var result = productRepository.GetByKey(1);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]

        public void GetByKeyExceptionTest()
        {
            var result = Assert.Throws<NoProductWithGivenIdException>(() => productRepository.GetByKey(5));
            Assert.AreEqual("Product with the given Id is not present" , result.Message);
        }

        [Test]
        public void DeleteSucessTest() {
            var result = productRepository.Delete(1);
            Assert.AreEqual(1 , result.Id);
        }

        [Test]
        public void DeleteExceptionTest()
        {
            var result = Assert.Throws<Exception>(()=> productRepository.Delete(10));
            Assert.AreEqual("Product with the given Id is not present", result.Message);
        }

        [Test]
        public void UpdateSucessTest()
        {
            product.Name = "cake";
            var result = productRepository.Update(product);
            Assert.AreEqual(1 , result.Id);
        }
        [Test]

        public void UpdateExceptionTest()
        {
            Product newProduct = new Product(2, 50, "chocolate", 5);
            var result = Assert.Throws<NoProductWithGivenIdException>(()=>productRepository.Update(newProduct));
            Assert.AreEqual("Product with the given Id is not present", result.Message);

        }

        [Test]

        public void GetAll()
        {
            var result = productRepository.GetAll();
            Assert.AreEqual(1 , result.Count);
        }
    }
}