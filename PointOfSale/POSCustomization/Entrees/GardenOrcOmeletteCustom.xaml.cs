/*
 * Author: Caleb Rosebaugh
 * Class name: GardenOrcOmeletteCustom.xaml.cs
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
    /// Interaction logic for GardenOrcOmeletteCustom.xaml
    /// </summary>
    public partial class GardenOrcOmeletteCustom : UserControl
    {
        /// <summary>
        /// Reference to EntreeButtons.xaml
        /// </summary>
        public EntreeButtons AboveLevel { get; set; }

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public GardenOrcOmeletteCustom()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it (for future use)
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void DoneClick(object sender, RoutedEventArgs e)
        {
            GardenOrcOmelette Cur = new GardenOrcOmelette();
            Cur.Broccoli = (bool)Broccoli.IsChecked;
            Cur.Mushrooms = (bool)Mushrooms.IsChecked;
            Cur.Tomato = (bool)Tomato.IsChecked;
            Cur.Cheddar = (bool)Cheddar.IsChecked;
            AboveLevel.Done();
        }
    }
}
