using NUnit.Framework;
using System;

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

        [Test]
        public void ShopCapacitySetterWithNegativeCapacityShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => shop = new Shop(-2));
        }

        [Test]
        public void ShopCountGetterWorksCorrectly()
        {
            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddPhoneWithExistentPhoneShouldThrow()
        {
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void AddPhoneOnFullCapacityShouldThrow()
        {
            shop = new Shop(1);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("model", 10)));
        }

        [Test]
        public void RemovePhoneWithNonExistentPhoneShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => shop.Remove("model"));
        }

        [Test]
        public void ShopRemovePhoneMethodWorksCorrectly()
        {
            shop.Add(smartphone);
            shop.Remove("phoneModel");
            Assert.That(shop.Count, Is.EqualTo(0));
        }


        [Test]
        public void TestPhoneWithNonExistentPhoneShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("model", 6));
        }

        [Test]
        public void TestPhoneWithLowBatteryShouldThrow()
        {
            smartphone = new Smartphone("phoneName", 2);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("phoneName", 6));
        }

        [Test]
        public void TestPhoneMethodWorksCorrectly()
        {
            shop.Add(smartphone);
            shop.TestPhone("phoneModel", 10);
        }
    }
}