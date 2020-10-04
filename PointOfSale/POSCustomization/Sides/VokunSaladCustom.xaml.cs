/*
 * Author: Caleb Rosebaugh
 * Class name: VokunSaladCustom.xaml.cs
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
    /// Interaction logic for VokunSaladCustom.xaml
    /// </summary>
    public partial class VokunSaladCustom : UserControl
    {
        /// <summary>
        /// Reference to SideButtons.xaml
        /// </summary>
        public SideButtons AboveLevel { get; set; }

        /// <summary>
        /// Instance of the Item
        /// </summary>
        public VokunSalad Side;

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public VokunSaladCustom()
        {
            InitializeComponent();
            Side = new VokunSalad();
            this.DataContext = Side;
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it (for future use)
        /// Passes click event afterwards to SideButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void DoneClick(object sender, RoutedEventArgs e)
        {
            if ((bool)Small.IsChecked)
            {
                Side.Size = BleakwindBuffet.Data.Enums.Size.Small;
            }
            else if ((bool)Medium.IsChecked)
            {
                Side.Size = BleakwindBuffet.Data.Enums.Size.Medium;
            }
            else if ((bool)Large.IsChecked)
            {
                Side.Size = BleakwindBuffet.Data.Enums.Size.Large;
            }
            AboveLevel.Done();
        }
    }
}
