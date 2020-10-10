/*
 * Author: Caleb Rosebaugh
 * Class name: EntreeButtons.xaml.cs
 * Purpose: Class used to create WPF.
 */
using BleakwindBuffet.Data;
using PointOfSale.POSCustomization.Entrees;
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
    /// Interaction logic for EntreeButtons.xaml
    /// </summary>
    public partial class EntreeButtons : UserControl
    {
        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// BriarHeartCustom shown after clicking BriarHeart burger
        /// </summary>
        public BriarHeartCustom BB { get; set; }

        /// <summary>
        /// DoubleDraugrCustom shown after clicking DoubleDraugr burger
        /// </summary>
        public DoubleDraugrCustom DD { get; set; }

        /// <summary>
        /// GardenOrcOmeletteCustom shown after clicking GardenOrc Omelette
        /// </summary>
        public GardenOrcOmeletteCustom GOO { get; set; }

        /// <summary>
        /// PhillyPoacherCustom shown after clicking PhillyPoacher 
        /// </summary>
        public PhillyPoacherCustom PP { get; set; }

        /// <summary>
        /// SmokehouseSkeletonCustom shown after clicking SmokehouseSkeleton
        /// </summary>
        public SmokehouseSkeletonCustom SS { get; set; }

        /// <summary>
        /// ThalmorTripleCustom shown after clicking ThalmorTriple burger
        /// </summary>
        public ThalmorTripleCustom TT { get; set; }

        /// <summary>
        /// ThugsTBoneCustom shown after clicking ThugsTBone
        /// </summary>
        public ThugsTBoneCustom TTB { get; set; }

        /// <summary>
        /// Initializes EntreeButtons
        /// </summary>
        public EntreeButtons()
        {
            InitializeComponent();
        }

        /// <summary>
        /// creates new briarheartburger customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void BriarheartBurgerClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            BB = new BriarHeartCustom();
            Win.containerBorder.Child = BB;
            Win.ChangeLayerIndex(1);
            BB.AboveLevel = this;
        }

        /// <summary>
        /// creates new DoubleDraugr customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void DoubleDraugrClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            DD = new DoubleDraugrCustom();
            Win.containerBorder.Child = DD;
            Win.ChangeLayerIndex(1);
            DD.AboveLevel = this;
        }

        /// <summary>
        /// creates new ThalmorTriple customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void ThalmorTripleClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            TT = new ThalmorTripleCustom();
            Win.containerBorder.Child = TT;
            Win.ChangeLayerIndex(1);
            TT.AboveLevel = this;
        }

        /// <summary>
        /// creates new SmokehouseSkeleton customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void SmokehouseSkeletonClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            SS = new SmokehouseSkeletonCustom();
            Win.containerBorder.Child = SS;
            Win.ChangeLayerIndex(1);
            SS.AboveLevel = this;
        }

        /// <summary>
        /// creates new GardenOrcOmelette customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void GardenOrcOmeletteClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            GOO = new GardenOrcOmeletteCustom();
            Win.containerBorder.Child = GOO;
            Win.ChangeLayerIndex(1);
            GOO.AboveLevel = this;
        }

        /// <summary>
        /// creates new PhillyPoacher customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void PhillyPoacherClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            PP = new PhillyPoacherCustom();
            Win.containerBorder.Child = PP;
            Win.ChangeLayerIndex(1);
            PP.AboveLevel = this;
        }

        /// <summary>
        /// creates new ThugsTBone customize screen
        /// </summary>
        /// <param name="sender"> buton object </param>
        /// <param name="e"> event </param>
        void ThugsTBoneClick(object sender, RoutedEventArgs e)
        {
            Win.containerBorder.Child = null;
            TTB = new ThugsTBoneCustom();
            Win.containerBorder.Child = TTB;
            Win.ChangeLayerIndex(1);
            TTB.AboveLevel = this;
        }

        /// <summary>
        /// When The customize screens "done" button gets clicked, redirected to here
        /// </summary>
        public void Done(IOrderItem that)
        {
            Win.AddItem(that);
        }

        /// <summary>
        /// When The customize screens "Cancel" button gets clicked, redirected to here
        /// </summary>
        public void Cancel(IOrderItem that)
        {
            Win.CancelItem(that);
        }
    }
}
