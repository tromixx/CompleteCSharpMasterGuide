using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Interfaces
{
    [TestClass]
    public class OrderProcessorTest
    {
        [TestMethod]
        [ExpectedExeption(typeof(InvalidOperationExeption))]
        public void Process_OrderIsAlreadyShipped_ThrosAnExeption()
        {
            //Arrange
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            var order = new Order
            {
                Shipment = new Shipment()
            };

            //Act
            orderProcessor.Process(order);

            //Assert not needed
        }

        [TestMethod]
        public void Process_OrderIsNotShipped_ShouldSetTheShipmentPropertyOfTheOrder()
        {
            var orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            var order = new Order();

            orderProcessor.Process(order);

            Assert.IsTrue(order.IsShipped);
            Assert.AreEqual(1, order.Shipment.Cost);
            Assert.AreEqual(DateTime.Today.AddDays(1), order.Shipment.ShippingDate);
        }
    }

    public class FakeShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            return 1;
        }
    }
}