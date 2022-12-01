using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;

       [SetUp]
       public void SetUp()
        {
            this.smartphone = new Smartphone("phoneModel", 100);
            this.shop = new Shop(5);
        }

        [Test]
        public void ShopCapacityGetterWorksCorrectly()
        {
            Assert.That(shop.Capacity, Is.EqualTo(5));
        }
    }
}