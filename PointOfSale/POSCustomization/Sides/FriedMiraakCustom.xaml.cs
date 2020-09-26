﻿/*
 * Author: Caleb Rosebaugh
 * Class name: FriedMiraakCustom.xaml.cs
 * Purpose: Class used to create WPF.
 */
using BleakwindBuffet.Data.Sides;
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

namespace PointOfSale.POSCustomization.Sides
{
    /// <summary>
    /// Interaction logic for FriedMiraakCustom.xaml
    /// </summary>
    public partial class FriedMiraakCustom : UserControl
    {
        /// <summary>
        /// Reference to SideButtons.xaml
        /// </summary>
        public SideButtons AboveLevel { get; set; }

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public FriedMiraakCustom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it (for future use)
        /// Passes click event afterwards to SideButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void DoneClick(object sender, RoutedEventArgs e)
        {
            FriedMiraak Cur = new FriedMiraak();
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
