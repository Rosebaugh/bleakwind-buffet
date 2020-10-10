/*
 * Author: Caleb Rosebaugh
 * Class name: WarriorWaterCustom.xaml.cs
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
    /// Interaction logic for WarriorWaterCustom.xaml
    /// </summary>
    public partial class WarriorWaterCustom : UserControl
    {
        /// <summary>
        /// Reference to DrinkButtons.xaml
        /// </summary>
        public DrinkButtons AboveLevel { get; set; }

        /// <summary>
        /// Instance of the Item
        /// </summary>
        public WarriorWater Agua;

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public WarriorWaterCustom()
        {
            InitializeComponent();
            Agua = new WarriorWater();
            this.DataContext = Agua;
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it
        /// Passes click event afterwards to DrinkButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void DoneClick(object sender, RoutedEventArgs e)
        {
            AboveLevel.Done(Agua);
        }

        /// <summary>
        /// Grabs the apropriate IOrderItem and removes it
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void CancelItem(object sender, RoutedEventArgs e)
        {
            AboveLevel.Cancel(Agua);
        }
    }
}
