using System;
using NUnit.Framework;
using Assignment2;

namespace Assignment2.Tests
{ 
    public class ProductTests
    {
        private Product product;

        [SetUp]
        public void Setup()
        {
            product = new Product(100, "Camera", 999.99m, 50);
        }

        // 1. Valid product creation
        [Test]
        public void Constructor_ValidInputs_ShouldCreateProduct()
        {
            Assert.AreEqual(100, product.ProdID);
            Assert.AreEqual("Camera", product.ProdName);
            Assert.AreEqual(999.99m, product.ItemPrice);
            Assert.AreEqual(50, product.StockAmount);
        }

        // 2. Invalid product ID (too low)
        [Test]
        public void Constructor_ProductIDTooLow_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(4, "Camera", 999.99m, 50));
        }

        // 3. Invalid product ID (too high)
        [Test]
        public void Constructor_ProductIDTooHigh_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(50001, "Camera", 999.99m, 50));
        }

        // 4. Invalid price (too low)
        [Test]
        public void Constructor_PriceTooLow_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(10, "Camera", 4.99m, 10));
        }

        // 5. Invalid price (too high)
        [Test]
        public void Constructor_PriceTooHigh_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(20, "Camera", 5000.01m, 10));
        }

        // 6. Invalid stock amount (too low)
        [Test]
        public void Constructor_StockTooLow_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(30, "Camera", 100.00m, 4));
        }

        // 7. Invalid stock amount (too high)
        [Test]
        public void Constructor_StockTooHigh_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Product(40, "Camera", 200.00m, 500001));
        }

        // 8. IncreaseStock with a valid amount
        [TestCase(10)]
        [TestCase(100)]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock(int increaseAmount)
        {
            product.IncreaseStock(increaseAmount);
            Assert.AreEqual(50 + increaseAmount, product.StockAmount);
        }

        // 9. IncreaseStock with zero
        [Test]
        public void IncreaseStock_ZeroAmount_ShouldNotChangeStock()
        {
            product.IncreaseStock(0);
            Assert.AreEqual(50, product.StockAmount);
        }

        // 10. IncreaseStock with a negative amount
        [Test]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => product.IncreaseStock(-5));
        }

        // 11. DecreaseStock with a valid amount
        [TestCase(10)]
        [TestCase(20)]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock(int decreaseAmount)
        {
            product.DecreaseStock(decreaseAmount);
            Assert.AreEqual(50 - decreaseAmount, product.StockAmount);
        }

        // 12. DecreaseStock with zero
        [Test]
        public void DecreaseStock_ZeroAmount_ShouldNotChangeStock()
        {
            product.DecreaseStock(0);
            Assert.AreEqual(50, product.StockAmount);
        }

        // 13. DecreaseStock with a negative amount
        [Test]
        public void DecreaseStock_NegativeAmount_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => product.DecreaseStock(-5));
        }

        // 14. DecreaseStock to zero
        [Test]
        public void DecreaseStock_StockToZero_ShouldSucceed()
        {
            product.DecreaseStock(50);
            Assert.AreEqual(0, product.StockAmount);
        }

        // 15. DecreaseStock below zero
        [Test]
        public void DecreaseStock_BelowZero_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(51));
        }

        // 16. Valid boundary Product ID
        [TestCase(5)]
        public void Constructor_MinProductID_ShouldCreateProduct(int minID)
        {
            var product = new Product(minID, "Keyboard", 100.00m, 10);
            Assert.AreEqual(minID, product.ProdID);
        }

        // 17. Valid boundary price
        [TestCase(5.00)]
        public void Constructor_MinPrice_ShouldCreateProduct(decimal minPrice)
        {
            var product = new Product(30, "Mouse", minPrice, 10);
            Assert.AreEqual(minPrice, product.ItemPrice);
        }

        // 18. Large stock increase
        [Test]
        public void IncreaseStock_LargeAmount_ShouldIncreaseStock()
        {
            product.IncreaseStock(5000);
            Assert.AreEqual(5050, product.StockAmount);
        }
    }
}
