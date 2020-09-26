﻿/*
 * Author: Caleb Rosebaugh
 * Class name: SailorsSodaCustom.xaml.cs
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
    /// Interaction logic for SailorsSodaCustom.xaml
    /// </summary>
    public partial class SailorsSodaCustom : UserControl
    {
        /// <summary>
        /// Reference to DrinkButtons.xaml
        /// </summary>
        public DrinkButtons AboveLevel { get; set; }

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public SailorsSodaCustom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it (for future use)
        /// Passes click event afterwards to DrinkButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void DoneClick(object sender, RoutedEventArgs e)
        {
            SailorSoda Cur = new SailorSoda();
            Cur.Ice = (bool)Ice.IsChecked;
            if ((bool)Small.IsChecked)
            {
                Cur.Size = BleakwindBuffet.Data.Enums.Size.Small;
            }
            else if ((bool)Medium.IsChecked)
            {
                Cur.Size = BleakwindBuffet.Data.Enums.Size.Medium;
            }
            else if ((bool)Large.IsChecked)
            {
                Cur.Size = BleakwindBuffet.Data.Enums.Size.Large;
            }


            if ((bool)Cherry.IsChecked)
            {
                Cur.Flavor = BleakwindBuffet.Data.Enums.SodaFlavor.Cherry;
            }
            else if ((bool)Blackberry.IsChecked)
            {
                Cur.Flavor = BleakwindBuffet.Data.Enums.SodaFlavor.Blackberry;
            }
            else if ((bool)Grapefruit.IsChecked)
            {
                Cur.Flavor = BleakwindBuffet.Data.Enums.SodaFlavor.Grapefruit;
            }
            else if ((bool)Blackberry.IsChecked)
            {
                Cur.Flavor = BleakwindBuffet.Data.Enums.SodaFlavor.Lemon;
            }
            else if ((bool)Grapefruit.IsChecked)
            {
                Cur.Flavor = BleakwindBuffet.Data.Enums.SodaFlavor.Peach;
            }
            else if ((bool)Blackberry.IsChecked)
            {
                Cur.Flavor = BleakwindBuffet.Data.Enums.SodaFlavor.Watermelon;
            }

            AboveLevel.Done();
        }
    }
}
