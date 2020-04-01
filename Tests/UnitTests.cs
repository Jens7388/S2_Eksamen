using Entities;
using System;
using System.Collections.Generic;
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
        [Fact]
        public void TestOrder()
        {
        int orderID = 0;
        string customerID = "test4";
        int employeeID = 1;
        DateTime orderDate = new DateTime(default);
        DateTime requiredDate = new DateTime(default);
        DateTime shippedDate = new DateTime(default);
        int shipVia = 1;
        decimal freight = 1;
        string shipName = "test";
        string shipAddress = "test4";
        string shipCity = "t";
        string shipRegion = "";
        string shipPostalCode = "test5";
        string shipCountry = "test";
        List<OrderDetails> orderDetails = new List<OrderDetails>();
            Order order = new Order(orderID, customerID, employeeID, orderDate, requiredDate, shippedDate, shipVia, freight, shipName, shipAddress, shipCity, shipRegion, shipPostalCode, shipCountry, orderDetails);
        }
    }
}