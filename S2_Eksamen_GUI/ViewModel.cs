using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace S2_Eksamen_GUI
{
    public class ViewModel
    {     
        public ViewModel()
        {
            Repository repository = new Repository();
            List<Order> orders = repository.GetAllOrders();
            Orders = new ObservableCollection<Order>(orders);
           
        }
        public ObservableCollection<Order> Orders { get; set; }
        public Order SelectedOrder { get; set; }
        public List<OrderDetails> SelectedOrderDetails { get; set; }     
    }
}