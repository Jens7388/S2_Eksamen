using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Order
    {
        protected int orderID;
        protected string customerID;
        protected int employeeID;
        protected DateTime orderDate;
        protected DateTime requiredDate;
        protected DateTime shippedDate;
        protected int shipVia;
        protected decimal freight;
        protected string shipName;
        protected string shipAddress;
        protected string shipCity;
        protected string shipRegion;
        protected string shipPostalCode;
        protected string shipCountry;
        protected List<OrderDetails> orderDetails;

        public Order(int orderID, string customerID, int employeeID, DateTime orderDate, DateTime requiredDate, DateTime shippedDate, int shipVia, decimal freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, List<OrderDetails> orderDetails)
        {
            OrderID = orderID;
            CustomerID = customerID;
            EmployeeID = employeeID;
            OrderDate = orderDate;
            RequiredDate = requiredDate;
            ShippedDate = shippedDate;
            ShipVia = shipVia;
            Freight = freight;
            ShipName = shipName;
            ShipAddress = shipAddress;
            ShipCity = shipCity;
            ShipRegion = shipRegion;
            ShipPostalCode = shipPostalCode;
            ShipCountry = shipCountry;
            OrderDetails = orderDetails;
        }

        public virtual int OrderID
        {
            get
            {
                return orderID;
            }
            set
            {
                if(orderID != value)
                {
                    orderID = value;
                }
            }
        }

        public virtual string CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateStringsWithNumbers(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != customerID)
                {
                    customerID = value;
                }
            }
        }

        public virtual int EmployeeID
        {
            get
            {
                return employeeID;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateInts(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != employeeID)
                {
                    employeeID = value;
                }
            }
        }

        public virtual DateTime OrderDate
        {
            get
            {
                return orderDate;
            }
            set
            {
                if(orderDate != value)
                {
                    orderDate = value;
                }
            }
        }

        public virtual DateTime RequiredDate
        {
            get
            {
                return requiredDate;
            }
            set
            {
                if(requiredDate != value)
                {
                    requiredDate = value;
                }
            }
        }

        public virtual DateTime ShippedDate
        {
            get
            {
                return shippedDate;
            }
            set
            {
                if(shippedDate != value)
                {
                    shippedDate = value;
                }
            }
        }

        public virtual int ShipVia
        {
            get
            {
                return shipVia;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateInts(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != shipVia)
                {
                    shipVia = value;
                }
            }
        }

        public virtual decimal Freight
        {
            get
            {
                return freight;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateFreight(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != freight)
                {
                    freight = value;
                }
            }
        }

        public virtual string ShipName
        {
            get
            {
                return shipName;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateStringsWithoutNumbers(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != shipName)
                {
                    shipName = value;
                }
            }
        }

        public virtual string ShipAddress
        {
            get
            {
                return shipAddress;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateStringsWithNumbers(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != shipAddress)
                {
                    shipAddress = value;
                }
            }
        }

        public virtual string ShipCity
        {
            get
            {
                return shipCity;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateStringsWithoutNumbers(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != shipCity)
                {
                    shipCity = value;
                }
            }
        }

        public virtual string ShipRegion
        {
            get
            {
                return shipRegion;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateShipRegion(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != shipRegion)
                {
                    shipRegion = value;
                }
            }
        }

        public virtual string ShipPostalCode
        {
            get
            {
                return shipPostalCode;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateStringsWithNumbers(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != shipPostalCode)
                {
                    shipPostalCode = value;
                }
            }
        }

        public virtual string ShipCountry
        {
            get
            {
                return shipCountry;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateStringsWithoutNumbers(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(nameof(orderID), validationResult.errorMessage);
                }
                if(value != shipCountry)
                {
                    shipCountry = value;
                }
            }
        }

        public virtual List<OrderDetails> OrderDetails
        {
            get
            {
                return orderDetails;
            }

            set
            {
                if(orderDetails != value)
                {
                    orderDetails = value;
                }
            }
        }

        public static (bool, string) ValidateStringsWithoutNumbers(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (Alle felter undtaget ShippedDate, ShipRegion, ShipPostalCode skal udfyldes)");
            }
            else if(input.Any(char.IsDigit))
            {
                return (false, "ShipName, ShipCity, ShipRegion og ShipCountry må ikke indeholde tal!");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateInts(int input)
        {
            if(input == 0)
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (Alle felter undtaget ShippedDate, ShipRegion, ShipPostalCode skal udfyldes)");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateStringsWithNumbers(string input)
        {
            if(string.IsNullOrWhiteSpace(input))
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (Alle felter undtaget ShippedDate, ShipRegion, ShipPostalCode skal udfyldes)");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateFreight(decimal freight)
        {
            if(freight == 0)
            {
                return (false, "Du mangler at udfylde et af de nødvendige felter! (Alle felter undtaget ShippedDate, ShipRegion, ShipPostalCode skal udfyldes)");
            }
            else if(freight < 0)
            {
                return (false, "Freight må ikke være mindre end 0!");
            }
            else
            {
                return (true, String.Empty);
            }
        }

        public static (bool, string) ValidateShipRegion(string shipRegion)
        {
            if(shipRegion.Any(char.IsDigit))
            {
                return (false, "ShipRegion må ikke indeholde tal!)");
            }
            else
            {
                return (true, String.Empty);
            }
        }
    }   
}