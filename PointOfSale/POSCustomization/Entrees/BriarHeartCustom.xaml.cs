/*
 * Author: Caleb Rosebaugh
 * Class name: BriarHeartCustom.xaml.cs
 * Purpose: Class used to create WPF.
 */
using BleakwindBuffet.Data.Entrees;
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

namespace PointOfSale.POSCustomization.Entrees
{
    /// <summary>
    /// Interaction logic for BriarHeartCustom.xaml
    /// </summary>
    public partial class BriarHeartCustom : UserControl
    {
        /// <summary>
        /// Reference to EntreeButtons.xaml
        /// </summary>
        public EntreeButtons AboveLevel { get; set; }

        /// <summary>
        /// Instance of the Item
        /// </summary>
        public BriarheartBurger Food;

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public BriarHeartCustom()
        {
            InitializeComponent();
            Food = new BriarheartBurger();
            this.DataContext = Food;
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void DoneClick(object sender, RoutedEventArgs e)
        {
            AboveLevel.Done(Food);
        }

        /// <summary>
        /// Grabs the apropriate IOrderItem and removes it
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void CancelItem(object sender, RoutedEventArgs e)
        {
            AboveLevel.Cancel(Food);
        }
    }
}
