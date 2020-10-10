/*
 * Author: Caleb Rosebaugh
 * Class name: MarkarthMilkCustom.xaml.cs
 * Purpose: Class used to create WPF.
 */
using BleakwindBuffet.Data.Drinks;
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

namespace PointOfSale.POSCustomization.Drinks
{
    /// <summary>
    /// Interaction logic for MarkarthMilkCustom.xaml
    /// </summary>
    public partial class MarkarthMilkCustom : UserControl
    {
        /// <summary>
        /// Reference to DrinkButtons.xaml
        /// </summary>
        public DrinkButtons AboveLevel { get; set; }

        /// <summary>
        /// Instance of the Item
        /// </summary>
        public  MarkarthMilk BoneJuice;

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public MarkarthMilkCustom()
        {
            InitializeComponent();
            BoneJuice = new MarkarthMilk();
            this.DataContext = BoneJuice;
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it
        /// Passes click event afterwards to DrinkButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void DoneClick(object sender, RoutedEventArgs e)
        {
            AboveLevel.Done(BoneJuice);
        }

        /// <summary>
        /// Grabs the apropriate IOrderItem and removes it
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void CancelItem(object sender, RoutedEventArgs e)
        {
            AboveLevel.Cancel(BoneJuice);
        }
    }
}
