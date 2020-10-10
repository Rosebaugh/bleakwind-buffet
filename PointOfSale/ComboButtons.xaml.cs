using BleakwindBuffet.Data;
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
    /// Interaction logic for ComboButtons.xaml
    /// </summary>
    public partial class ComboButtons : UserControl
    {
        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// Instance of the Combo
        /// </summary>
        public ComboMeal meal;

        /// <summary>
        /// Initializes ComboButtons
        /// </summary>
        public ComboButtons()
        {
            InitializeComponent();
            meal = new ComboMeal();
            this.DataContext = meal;
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

        /// <summary>
        /// When The customize screens "done" button gets clicked, redirected to here
        /// </summary>
        public void Done(object sender, RoutedEventArgs e)
        {
            Win.isCombo = false;
            Win.AddItem(meal);
        }

        /// <summary>
        /// Grabs the apropriate IOrderItem and removes it
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void CancelItem(object sender, RoutedEventArgs e)
        {
            Win.CancelItem(meal);
        }
    }
}
