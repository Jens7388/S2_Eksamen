using Entities;
using System;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void TestOrderDetails()
        {
            int orderID = 1;
            int productID = 77;
            decimal unitPrice = 1;
            int quantity = 1;
            float discount = 0;
            if(productID == 0 && unitPrice == 0 && quantity == 0 && discount == 0)
            {

            }
            else
            {
                OrderDetails orderDetails = new OrderDetails(orderID, productID, unitPrice, quantity, discount);
            }
        }
    }
}