/*
 * Author: Caleb Rosebaugh
 * Class name: MenuChoice.xaml.cs
 * Purpose: Class used to create WPF user control.
 */
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

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for MenuChoice.xaml
    /// </summary>
    public partial class MenuChoice : UserControl
    {
        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// Initializes MenuChoice
        /// </summary>
        public MenuChoice()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Redirects Click Event to MainWindow.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void EntreeButtonClick(object sender, RoutedEventArgs e)
        {
            Win.Entrees();
        }

        /// <summary>
        /// Redirects Click Event to MainWindow.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void SidesButtonClick(object sender, RoutedEventArgs e)
        {
            Win.Sides();
        }

        /// <summary>
        /// Redirects Click Event to MainWindow.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void DrinksButtonClick(object sender, RoutedEventArgs e)
        {
            Win.Drinks();
        }
    }
}
