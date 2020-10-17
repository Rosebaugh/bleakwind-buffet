/*
 * Author: Caleb Rosebaugh
 * Class name: OrderWindow.xaml.cs
 * Purpose: Class used to create WPF user control.
 */
using BleakwindBuffet.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : UserControl
    { 

        //public ObservableCollection<IOrderItem> Order;

        public Order price;

        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// Current Order Number
        /// </summary>
        public int Number;

        /// <summary>
        /// Initializes OrderWindow. It is Not Used Yet
        /// </summary>
        public OrderWindow()
        {
            InitializeComponent();
            //Order = new ObservableCollection<IOrderItem>();
            price = new Order();
            this.DataContext = price;
            itemsListView.DataContext = price; //was Order
            Number = 1;
            price.OrderNumber = Number;
            OrderNumber.Text = Number.ToString();
        }

        /// <summary>
        /// Adds item to Order named price
        /// </summary>
        /// <param name="that"></param>
        public void AddItem(IOrderItem that)
        {
            if (DataContext is Order)
            {
                price.Add(that);
            }
        }

        /// <summary>
        /// opens selected item to be altered
        /// </summary>
        /// <param name="sender">object clicked</param>
        /// <param name="e">event</param>
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(itemsListView.SelectedItem is IOrderItem item)
            {
                Win.AlterItem(item);
            }
        }

        /// <summary>
        /// unselects item in list
        /// </summary>
        public void UnselectItem()
        {
            itemsListView.SelectedItem = null;
        }

        /// <summary>
        /// removes item from Order named price
        /// </summary>
        /// <param name="item">item</param>
        public void Remove(IOrderItem item)
        {
            price.Remove(price[itemsListView.SelectedIndex]);
        }

        /// <summary>
        /// cancels order
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">event</param>
        public void Cancel(object sender, RoutedEventArgs e)
        {
            if(sender != null)
            {
                price = new Order();
                this.DataContext = price;
                itemsListView.DataContext = price; //was Order
                Win.Reset();
            }
            else
            {
                Number++;
                price = new Order();
                price.OrderNumber = Number;
                OrderNumber.Text = Number.ToString();
                this.DataContext = price;
                itemsListView.DataContext = price; //was Order
            }
        }

        /// <summary>
        /// submits order and makes new one
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">event</param>
        public void Finish(object sender, RoutedEventArgs e)
        {
            if(price.Count != 0)
            {
                //Number++;
                //price.OrderNumber = Number;
                OrderNumber.Text = Number.ToString();
                Win.Finish();
                //Win.Finish(price);
                //Cancel(sender, e);
            }
        }
    }
}
