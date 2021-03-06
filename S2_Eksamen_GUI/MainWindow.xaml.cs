﻿using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace S2_Eksamen_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        private ViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            DataContext = viewModel;
            GetComboBoxItems();
        }

        private void buttonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            try
            {
                int.TryParse(comboBoxEmployeeID.Text, out int employeeID);
                int.TryParse(comboBoxShipVia.Text, out int shipVia);
                decimal.TryParse(textBoxFreight.Text, out decimal freight);
                Order order = new Order(1, comboBoxCustomerID.Text, employeeID, datePickerOrderDate.SelectedDate.Value.Date,
                    datePickerOrderDate.SelectedDate.Value.Date, datePickerOrderDate.SelectedDate.Value.Date, shipVia, freight,
                    textBoxShipName.Text, textBoxShipAddress.Text, textBoxShipCity.Text, textBoxShipRegion.Text, textBoxShipPostalCode.Text,
                    textBoxShipCountry.Text, orderDetails);

                Repository repository = new Repository();
                repository.AddOrder(order);
                viewModel.Orders.Add(order);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OrderSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxOrderID.SelectedItem = null;
            textBoxProductID.Text = null;
            textBoxUnitPrice.Text = null;
            textBoxQuantity.Text = null;
            textBoxDiscount.Text = null;

            viewModel.SelectedOrderDetails = viewModel.SelectedOrder.OrderDetails;
            foreach(OrderDetails orderDetails in viewModel.SelectedOrderDetails)
            {
                comboBoxOrderID.SelectedItem = orderDetails.OrderID;
                textBoxProductID.Text += $"{orderDetails.ProductID}\n";
                textBoxUnitPrice.Text += $"{orderDetails.UnitPrice}\n";
                textBoxQuantity.Text += $"{orderDetails.Quantity}\n";
                textBoxDiscount.Text += $"{orderDetails.Discount}\n";
            }
        }

        private void buttonAddOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            string[] productIDArray = textBoxProductID.Text.Split("\n");
            string[] unitPriceArray = textBoxUnitPrice.Text.Split("\n");
            string[] quantityArray = textBoxQuantity.Text.Split("\n");
            string[] discountArray = textBoxDiscount.Text.Split("\n");

            try
            {
                for(int i = 0; i < productIDArray.Length; i++)
                {
                    int.TryParse(comboBoxOrderID.Text, out int orderID);
                    int.TryParse(productIDArray[i], out int productID);
                    Decimal.TryParse(unitPriceArray[i], out Decimal unitPrice);
                    int.TryParse(quantityArray[i], out int quantity);
                    float.TryParse(discountArray[i], out float discount);

                    if(productID == 0 && unitPrice == 0 && quantity == 0 && discount == 0)
                    {

                    }
                    else
                    {
                        OrderDetails orderDetail = new OrderDetails(orderID, productID, unitPrice,
                        quantity, discount);
                        orderDetails.Add(orderDetail);
                    }
                }
                Repository repository = new Repository();
                repository.AddOrderDetails(orderDetails);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GetComboBoxItems()
        {
            for(int i = 0; i < viewModel.Orders.Count; i++)
            {
                comboBoxOrderID.Items.Add(viewModel.Orders[i].OrderID);
            }
            for(int i = 0; i < viewModel.Orders.Count; i++)
            {
              comboBoxCustomerID.Items.Add(viewModel.Orders[i].CustomerID);
            }
            for(int i = 0; i < 10; i++)
            {
                comboBoxEmployeeID.Items.Add(i);
            }
            for(int i = 200; i < 212; i++)
            {
                comboBoxEmployeeID.Items.Add(i);
            }
            for(int i = 0; i < 4; i++)
            {
                comboBoxShipVia.Items.Add(i);
            }
        }

        private void buttonSaveOrderEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Repository repository = new Repository();
                repository.EditOrder(viewModel.SelectedOrder);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buttonSaveOrderDetailEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}