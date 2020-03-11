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
        protected Decimal discount;

        public OrderDetails(int orderID, int productID, decimal unitPrice, int quantity, decimal discount)
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
                if(value != quantity)
                {
                    quantity = value;
                }
            }
        }

        public virtual decimal Discount
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
    }
}