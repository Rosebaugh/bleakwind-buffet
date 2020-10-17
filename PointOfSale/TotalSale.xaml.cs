/*
 * Author: Caleb Rosebaugh
 * Class name: TotalSale.xaml.cs
 * Purpose: Class used to create WPF user control.
 */
using System;
using System.Collections.Generic;
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
    /// Interaction logic for TotalSale.xaml
    /// </summary>
    public partial class TotalSale : UserControl
    {
        /// <summary>
        /// Creates Dependency Property for the total
        /// </summary>
        public static DependencyProperty TotalAmountProperty = DependencyProperty.Register("TotalAmount", typeof(string), typeof(TotalSale));

        /// <summary>
        /// Creates Dependency Property for the amount due
        /// </summary>
        public static DependencyProperty DueAmountProperty = DependencyProperty.Register("DueAmount", typeof(string), typeof(TotalSale));

        /// <summary>
        /// Creates Dependency Property for the change
        /// </summary>
        public static DependencyProperty ChangeOwedProperty = DependencyProperty.Register("ChangeOwed", typeof(string), typeof(TotalSale));

        /// <summary>
        /// Variable that holds the higher class
        /// </summary>
        public CurrencyScreen aboveLevel;

        /// <summary>
        /// Total amount needed to pay
        /// </summary>
        /// <returns>$ total</returns>
        public string TotalAmount
        {
            get => (string)GetValue(TotalAmountProperty);
            set => SetValue(TotalAmountProperty, value);
        }

        /// <summary>
        /// Total amount still needed to pay
        /// </summary>
        /// <returns>$ owed</returns>
        public string DueAmount
        {
            get => (string)GetValue(DueAmountProperty);
            set
            {
                SetValue(DueAmountProperty, value);
                if((DueAmount == "$0.00" && ChangeOwed != "$0.00") || TotalAmount == "$0.00")
                {
                    EnableFinalizeButton();
                }
            }
        }

        /// <summary>
        /// Total amount needed to Returned to customer
        /// </summary>
        /// <returns>$ change</returns>
        public string ChangeOwed
        {
            get => (string)GetValue(ChangeOwedProperty);
            set
            {
                SetValue(ChangeOwedProperty, value);
                if ((DueAmount == "$0.00" && ChangeOwed != "$0.00") || TotalAmount == "$0.00")
                {
                    EnableFinalizeButton();
                }
            }
        }

        /// <summary>
        /// initializes class
        /// </summary>
        public TotalSale()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Enables or disables Finalize Button
        /// </summary>
        public void EnableFinalizeButton()
        {
            if(TotalAmount == "$0.00")
            {
                FinishSale.IsEnabled = true;
                return;
            }
            foreach(int k in aboveLevel.ChangeDrawer.GiveBackChange)
            {
                if(k != 0)
                {
                    FinishSale.IsEnabled = true;
                    return;
                }
            }
            FinishSale.IsEnabled = false;
        }

        /// <summary>
        /// alerts parent class that final sale done
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Event</param>
        void FinalizeSale(object sender, RoutedEventArgs e)
        {
            aboveLevel.FinalizeSale();
        }
    }
}
