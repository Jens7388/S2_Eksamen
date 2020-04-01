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
                (bool isValid, string errorMessage) validationResult = ValidateProductID(value);
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
                (bool isValid, string errorMessage) validationResult = ValidateUnitPrice(value);
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
            else if(input < 0)
            {
                //Nej, dette er ikke bad practice, uanset hvad kan orderID ikke ende med at være i minus....
                return (false, "Quantity må ikke være i minus!");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateProductID(int productID)
        {
            if(productID == 0)
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (OrderID, ProductID, Unitprice og Quantity skal udfyldes!)");
            }
            else if(productID > 78)
            {
                return (false, "Dette produkt findes ikke! (laveste productID = 1, højeste = 78!)");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateUnitPrice(decimal unitPrice)
        {
            if(unitPrice == 0)
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (OrderID, ProductID, Unitprice og Quantity skal udfyldes!)");
            }
            else if(unitPrice < 0)
            {
                return (false, "UnitPrice må ikke være i minus!");
            }
            else
            {
                return (true, String.Empty);
            }
        }
    }
}