using System;

namespace class OrderProcessor
{
    private readonly IShippingCalculator _shippingCalculator;

    public OrderProcessor(IShippingCalculator shippingCalculator)
    {
        _shippingCalculator = shippingCalculator;
    }

    public void Process(Order order)
    {
        if (order.IsShipped)
            throw new InvalidOperationExeption("This order is already shipped");

        order.Shipment = new Shipment
        {
            Cost = _shippingCalculator.CalculateShipping(order),
            ShippingDate = DateTime.Today.AddDays(1)
        }
    }
}