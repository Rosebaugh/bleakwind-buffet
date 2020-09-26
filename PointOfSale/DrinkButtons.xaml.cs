/*
 * Author: Caleb Rosebaugh
 * Class name: DrinkButtons.xaml.cs
 * Purpose: Class used to create WPF.
 */
using PointOfSale.POSCustomization.Drinks;
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
    /// Interaction logic for Drinks.xaml
    /// </summary>
    public partial class DrinkButtons : UserControl
    {
        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// SailorsSodaCustom shown after clicking SailorsSoda
        /// </summary>
        public SailorsSodaCustom SS { get; set; }

        /// <summary>
        /// MarkarthMilkCustom shown after clicking MarkarthMilk
        /// </summary>
        public MarkarthMilkCustom MM { get; set; }

        /// <summary>
        /// AretinoAppleJuiceCustom shown after clicking AretinoAppleJuice
        /// </summary>
        public AretinoAppleJuiceCustom AA { get; set; }

        /// <summary>
        /// CandlehearthCoffeeCustom shown after clicking CandlehearthCoffee
        /// </summary>
        public CandlehearthCoffeeCustom CC { get; set; }

        /// <summary>
        /// WarriorWaterCustom shown after clicking WarriorWater
        /// </summary>
        public WarriorWaterCustom WW { get; set; }

        /// <summary>
        /// Initializes drinks wpf
        /// </summary>
        public DrinkButtons()
        {
            InitializeComponent();
        }

        /// <summary>
        /// creates new SailorsSoda customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void SailorsSodaClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            SS = new SailorsSodaCustom();
            Win.containerBorder.Child = SS;
            Win.ChangeLayerIndex(1);
            SS.AboveLevel = this;
        }

        /// <summary>
        /// creates new MarkarthMilk customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void MarkarthMilkClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            MM = new MarkarthMilkCustom();
            Win.containerBorder.Child = MM;
            Win.ChangeLayerIndex(1);
            MM.AboveLevel = this;
        }

        /// <summary>
        /// creates new AretinoAppleJuice customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void AretinoAppleJuiceClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            AA = new AretinoAppleJuiceCustom();
            Win.containerBorder.Child = AA;
            Win.ChangeLayerIndex(1);
            AA.AboveLevel = this;
        }

        /// <summary>
        /// creates new CandlehearthCoffee customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void CandlehearthCoffeeClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            CC = new CandlehearthCoffeeCustom();
            Win.containerBorder.Child = CC;
            Win.ChangeLayerIndex(1);
            CC.AboveLevel = this;
        }

        /// <summary>
        /// creates new WarriorWater customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void WarriorWaterClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            WW = new WarriorWaterCustom();
            Win.containerBorder.Child = WW;
            Win.ChangeLayerIndex(1);
            WW.AboveLevel = this;
        }

        /// <summary>
        /// When The customize screens "done" button gets clicked, redirected to here
        /// </summary>
        public void Done()
        {
            Win.ChangeLayerIndex(-1);
            Win.BackButtonClick(new object(), new RoutedEventArgs());
        }
    }
}
