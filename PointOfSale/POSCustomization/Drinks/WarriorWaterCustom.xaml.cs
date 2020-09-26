﻿/*
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
        /// initializes customization WPF
        /// </summary>
        public WarriorWaterCustom()
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
            WarriorWater Cur = new WarriorWater();
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
            AboveLevel.Done();
        }
    }
}
