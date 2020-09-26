/*
 * Author: Caleb Rosebaugh
 * Class name: SideButtons.xaml.cs
 * Purpose: Class used to create WPF.
 */
using PointOfSale.POSCustomization.Sides;
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
    /// Interaction logic for Side.xaml
    /// </summary>
    public partial class SideButtons : UserControl
    {
        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// VokunSaladCustom shown after clicking VokunSalad
        /// </summary>
        public VokunSaladCustom VS { get; set; }

        /// <summary>
        /// FriedMiraakCustom shown after clicking FriedMiraak
        /// </summary>
        public FriedMiraakCustom FM { get; set; }

        /// <summary>
        /// MadOtarGritsCustom shown after clicking MadOtarGrits
        /// </summary>
        public MadOtarGritsCustom MOG { get; set; }

        /// <summary>
        /// DragonbornWaffleFriesCustom shown after clicking DragonbornWaffleFries
        /// </summary>
        public DragonbornWaffleFriesCustom DW { get; set; }

        /// <summary>
        /// Initializes sides wpf
        /// </summary>
        public SideButtons()
        {
            InitializeComponent();
        }

        /// <summary>
        /// creates new VokunSalad customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void VokunSaladClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            VS = new VokunSaladCustom();
            Win.containerBorder.Child = VS;
            Win.ChangeLayerIndex(1);
            VS.AboveLevel = this;
        }

        /// <summary>
        /// creates new FriedMiraak customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void FriedMiraakClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            FM = new FriedMiraakCustom();
            Win.containerBorder.Child = FM;
            Win.ChangeLayerIndex(1);
            FM.AboveLevel = this;
        }

        /// <summary>
        /// creates new MadOtarGrits customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void MadOtarGritsClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            MOG = new MadOtarGritsCustom();
            Win.containerBorder.Child = MOG;
            Win.ChangeLayerIndex(1);
            MOG.AboveLevel = this;
        }

        /// <summary>
        /// creates new DragonbornWaffleFries customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void DragonbornWaffleFriesClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            DW = new DragonbornWaffleFriesCustom();
            Win.containerBorder.Child = DW;
            Win.ChangeLayerIndex(1);
            DW.AboveLevel = this;
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
