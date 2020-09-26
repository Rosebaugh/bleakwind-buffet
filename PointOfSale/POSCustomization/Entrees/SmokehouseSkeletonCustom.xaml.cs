/*
 * Author: Caleb Rosebaugh
 * Class name: SmokehouseSkeletonCustom.xaml.cs
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
    /// Interaction logic for SmokehouseSkeletonCustom.xaml
    /// </summary>
    public partial class SmokehouseSkeletonCustom : UserControl
    {
        /// <summary>
        /// Reference to EntreeButtons.xaml
        /// </summary>
        public EntreeButtons AboveLevel { get; set; }

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public SmokehouseSkeletonCustom()
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
            SmokehouseSkeleton Cur = new SmokehouseSkeleton();
            Cur.SausageLink = (bool)SausageLink.IsChecked;
            Cur.Egg = (bool)Egg.IsChecked;
            Cur.HashBrowns = (bool)HashBrowns.IsChecked;
            Cur.Pancake = (bool)Pancake.IsChecked;
            AboveLevel.Done();
        }
    }
}
