/*
 * Author: Caleb Rosebaugh
 * Class name: ThalmorTripleCustom.xaml.cs
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
    /// Interaction logic for ThalmorTripleCustom.xaml
    /// </summary>
    public partial class ThalmorTripleCustom : UserControl
    {
        /// <summary>
        /// Reference to EntreeButtons.xaml
        /// </summary>
        public EntreeButtons AboveLevel { get; set; }

        /// <summary>
        /// initializes customization WPF
        /// </summary>
        public ThalmorTripleCustom()
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
            ThalmorTriple Cur = new ThalmorTriple();
            Cur.Bun = (bool)Bun.IsChecked;
            Cur.Ketchup = (bool)Ketchup.IsChecked;
            Cur.Mustard = (bool)Mustard.IsChecked;
            Cur.Pickle = (bool)Pickle.IsChecked;
            Cur.Cheese = (bool)Cheese.IsChecked;
            Cur.Tomato = (bool)Tomato.IsChecked;
            Cur.Lettuce = (bool)Lettuce.IsChecked;
            Cur.Mayo = (bool)Mayo.IsChecked;
            Cur.Bacon = (bool)Bacon.IsChecked;
            Cur.Egg = (bool)Egg.IsChecked;
            AboveLevel.Done();
        }
    }
}
