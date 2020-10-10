/*
 * Author: Caleb Rosebaugh
 * Class name: MadOtarGritsCustom.xaml.cs
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
    /// Interaction logic for MadOtarGritsCustom.xaml
    /// </summary>
    public partial class MadOtarGritsCustom : UserControl
    {
        /// <summary>
        /// Reference to SideButtons.xaml
        /// </summary>
        public SideButtons AboveLevel { get; set; }

        /// <summary>
        /// Instance of the Item
        /// </summary>
        public MadOtarGrits Side;

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public MadOtarGritsCustom()
        {
            InitializeComponent();
            Side = new MadOtarGrits();
            this.DataContext = Side;
        }

        /// <summary>
        /// Creates the apropriate IOrderItem and populates it
        /// Passes click event afterwards to SideButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void DoneClick(object sender, RoutedEventArgs e)
        {
            AboveLevel.Done(Side);
        }

        /// <summary>
        /// Grabs the apropriate IOrderItem and removes it
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void CancelItem(object sender, RoutedEventArgs e)
        {
            AboveLevel.Cancel(Side);
        }
    }
}
