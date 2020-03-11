using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class OrderDetails
    {
        protected int orderId;
        protected int productId;
        protected Decimal unitPrice;
        protected int quantity;
        protected Decimal discount;

        public OrderDetails(int orderId, int productId, decimal unitPrice, int quantity, decimal discount)
        {
            OrderId = orderId;
            ProductId = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
        }

        public virtual int OrderId
        {
            get
            {
                return orderId;
            }

            set
            {
                if(value != orderId)
                {
                    orderId = value;
                }
            }
        }

        public virtual int ProductId
        {
            get
            {
                return productId;
            }

            set
            {
                if(value != productId)
                {
                    productId = value;
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