using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class OrderDetails
    {
        protected int orderID;
        protected int productID;
        protected Decimal unitPrice;
        protected int quantity;
        protected float discount;

        public OrderDetails(int orderID, int productID, decimal unitPrice, int quantity, float discount)
        {
            OrderID = orderID;
            ProductID = productID;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
        }

        public virtual int OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateInts(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != orderID)
                {
                    orderID = value;
                }
            }
        }

        public virtual int ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateInts(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != productID)
                {
                    productID = value;
                }
            }
        }

        public virtual decimal UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateDecimals(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != unitPrice)
                {
                    unitPrice = value;
                }
            }
        }

        public virtual int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateInts(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != quantity)
                {
                    quantity = value;
                }
            }
        }

        public virtual float Discount
        {
            get
            {
                return discount;
            }

            set
            {
                if(value != discount)
                {
                    discount = value;
                }
            }
        }
        public static (bool, string) ValidateInts(int input)
        {
            if(input == 0)
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (OrderID, ProductID, Unitprice og Quantity skal udfyldes!)");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateDecimals(decimal input)
        {
            if(input == 0)
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (OrderID, ProductID, Unitprice og Quantity skal udfyldes!)");
            }
            else
            {
                return (true, String.Empty);
            }
        }
    }
}