using Entities;
using System;
using System.Collections.Generic;
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
        }

        private void buttonSaveOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OrderSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBoxProductID.Text = null;
            textBoxUnitPrice.Text = null;
            textBoxQuantity.Text = null;
            textBoxDiscount.Text = null;

            viewModel.SelectedOrderDetails = viewModel.SelectedOrder.OrderDetails;
            foreach(OrderDetails orderDetails in viewModel.SelectedOrderDetails) 
            {
                //next step: try to make textboxes scrollable!
                textBoxProductID.Text += $"{orderDetails.ProductID}\n";
                textBoxUnitPrice.Text += $"{orderDetails.UnitPrice}\n";
                textBoxQuantity.Text += $"{orderDetails.Quantity}\n";
                textBoxDiscount.Text += $"{orderDetails.Discount}\n";
            }
        }
    }
}