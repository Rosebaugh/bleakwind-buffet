using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using PointOfSale.POSCustomization.Drinks;
using PointOfSale.POSCustomization.Entrees;
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
    /// Interaction logic for ComboAlterButtons.xaml
    /// </summary>
    public partial class ComboAlterButtons : UserControl
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
        /// Initializes ComboAlterButtons
        /// </summary>
        public ComboAlterButtons()
        {
            InitializeComponent();
            meal = new ComboMeal();
            this.DataContext = meal;
        }

        /// <summary>
        /// Opens the proper item xaml and initiates a "item change event" for Entrees
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void EntreeButtonClick(object sender, RoutedEventArgs e)
        {
            IOrderItem item = meal.Entree;
            if (item is Entree)
            {
                Win.containerBorder.Child = null;
                if (item is BriarheartBurger)
                {
                    Win.Ent.BB = new BriarHeartCustom();
                    Win.containerBorder.Child = Win.Ent.BB;
                    Win.Ent.BB.AboveLevel = Win.Ent;
                    Win.Ent.BB.DataContext = (BriarheartBurger)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Ent.BB.Done.Click -= Win.Ent.BB.DoneClick;
                    Win.Ent.BB.Done.Click += Win.Ent.BB.CancelItem;
                    Win.Ent.BB.Done.Content = "Done";
                    Win.Ent.BB.Done.Visibility = Visibility.Visible;
                }
                else if (item is DoubleDraugr)
                {
                    Win.Ent.DD = new DoubleDraugrCustom();
                    Win.containerBorder.Child = Win.Ent.DD;
                    Win.Ent.DD.AboveLevel = Win.Ent;
                    Win.Ent.DD.DataContext = (DoubleDraugr)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Ent.DD.Done.Click -= Win.Ent.DD.DoneClick;
                    Win.Ent.DD.Done.Click += Win.Ent.DD.CancelItem;
                    Win.Ent.DD.Done.Content = "Done";
                    Win.Ent.DD.Done.Visibility = Visibility.Visible;
                }
                else if (item is GardenOrcOmelette)
                {
                    Win.Ent.GOO = new GardenOrcOmeletteCustom();
                    Win.containerBorder.Child = Win.Ent.GOO;
                    Win.Ent.GOO.AboveLevel = Win.Ent;
                    Win.Ent.GOO.DataContext = (GardenOrcOmelette)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Ent.GOO.Done.Click -= Win.Ent.GOO.DoneClick;
                    Win.Ent.GOO.Done.Click += Win.Ent.GOO.CancelItem;
                    Win.Ent.GOO.Done.Content = "Done";
                    Win.Ent.GOO.Done.Visibility = Visibility.Visible;
                }
                else if (item is PhillyPoacher)
                {
                    Win.Ent.PP = new PhillyPoacherCustom();
                    Win.containerBorder.Child = Win.Ent.PP;
                    Win.Ent.PP.AboveLevel = Win.Ent;
                    Win.Ent.PP.DataContext = (PhillyPoacher)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Ent.PP.Done.Click -= Win.Ent.PP.DoneClick;
                    Win.Ent.PP.Done.Click += Win.Ent.PP.CancelItem;
                    Win.Ent.PP.Done.Content = "Done";
                    Win.Ent.PP.Done.Visibility = Visibility.Visible;
                }
                else if (item is SmokehouseSkeleton)
                {
                    Win.Ent.SS = new SmokehouseSkeletonCustom();
                    Win.containerBorder.Child = Win.Ent.SS;
                    Win.Ent.SS.AboveLevel = Win.Ent;
                    Win.Ent.SS.DataContext = (SmokehouseSkeleton)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Ent.SS.Done.Click -= Win.Ent.SS.DoneClick;
                    Win.Ent.SS.Done.Click += Win.Ent.SS.CancelItem;
                    Win.Ent.SS.Done.Content = "Done";
                    Win.Ent.SS.Done.Visibility = Visibility.Visible;
                }
                else if (item is ThalmorTriple)
                {
                    Win.Ent.TT = new ThalmorTripleCustom();
                    Win.containerBorder.Child = Win.Ent.TT;
                    Win.Ent.TT.AboveLevel = Win.Ent;
                    Win.Ent.TT.DataContext = (ThalmorTriple)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Ent.TT.Done.Click -= Win.Ent.TT.DoneClick;
                    Win.Ent.TT.Done.Click += Win.Ent.TT.CancelItem;
                    Win.Ent.TT.Done.Content = "Done";
                    Win.Ent.TT.Done.Visibility = Visibility.Visible;
                }
                else if (item is ThugsTBone)
                {
                    Win.Ent.TTB = new ThugsTBoneCustom();
                    Win.containerBorder.Child = Win.Ent.TTB;
                    Win.Ent.TTB.AboveLevel = Win.Ent;
                    Win.Ent.TTB.DataContext = (ThugsTBone)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Ent.TTB.Done.Click -= Win.Ent.TTB.DoneClick;
                    Win.Ent.TTB.Done.Click += Win.Ent.TTB.CancelItem;
                    Win.Ent.TTB.Done.Content = "Done";
                    Win.Ent.TTB.Done.Visibility = Visibility.Visible;
                }
                else
                {
                    Win.Menu = 0;
                    Win.LayerIndex = 0;
                    Win.Back.IsEnabled = false;
                    Win.containerBorder.Child = Win.Topie;
                    Win.isCombo = false;
                    Win.OrderItem = false;
                }
            }
        }

        /// <summary>
        /// Opens the proper item xaml and initiates a "item change event" for sides
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void SidesButtonClick(object sender, RoutedEventArgs e)
        {
            IOrderItem item = meal.Side;
            if (item is Side)
            {
                if (item is DragonbornWaffleFries)
                {
                    Win.Sid.DW = new DragonbornWaffleFriesCustom();
                    Win.containerBorder.Child = Win.Sid.DW;
                    Win.Sid.DW.AboveLevel = Win.Sid;
                    Win.Sid.DW.DataContext = (DragonbornWaffleFries)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Sid.DW.Done.Click -= Win.Sid.DW.DoneClick;
                    Win.Sid.DW.Done.Click += Win.Sid.DW.CancelItem;
                    Win.Sid.DW.Done.Content = "Done";
                    Win.Sid.DW.Done.Visibility = Visibility.Visible;
                }
                else if (item is FriedMiraak)
                {
                    Win.Sid.FM = new FriedMiraakCustom();
                    Win.containerBorder.Child = Win.Sid.FM;
                    Win.Sid.FM.AboveLevel = Win.Sid;
                    Win.Sid.FM.DataContext = (FriedMiraak)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Sid.FM.Done.Click -= Win.Sid.FM.DoneClick;
                    Win.Sid.FM.Done.Click += Win.Sid.FM.CancelItem;
                    Win.Sid.FM.Done.Content = "Done";
                    Win.Sid.FM.Done.Visibility = Visibility.Visible;
                }
                else if (item is MadOtarGrits)
                {
                    Win.Sid.MOG = new MadOtarGritsCustom();
                    Win.containerBorder.Child = Win.Sid.MOG;
                    Win.Sid.MOG.AboveLevel = Win.Sid;
                    Win.Sid.MOG.DataContext = (MadOtarGrits)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Sid.MOG.Done.Click -= Win.Sid.MOG.DoneClick;
                    Win.Sid.MOG.Done.Click += Win.Sid.MOG.CancelItem;
                    Win.Sid.MOG.Done.Content = "Done";
                    Win.Sid.MOG.Done.Visibility = Visibility.Visible;
                }
                else if (item is VokunSalad)
                {
                    Win.Sid.VS = new VokunSaladCustom();
                    Win.containerBorder.Child = Win.Sid.VS;
                    Win.Sid.VS.AboveLevel = Win.Sid;
                    Win.Sid.VS.DataContext = (VokunSalad)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Sid.VS.Done.Click -= Win.Sid.VS.DoneClick;
                    Win.Sid.VS.Done.Click += Win.Sid.VS.CancelItem;
                    Win.Sid.VS.Done.Content = "Done";
                    Win.Sid.VS.Done.Visibility = Visibility.Visible;
                }
                else
                {
                    Win.Menu = 0;
                    Win.LayerIndex = 0;
                    Win.Back.IsEnabled = false;
                    Win.containerBorder.Child = Win.Topie;
                    Win.isCombo = false;
                    Win.OrderItem = false;
                }
            }
        }

        /// <summary>
        /// Opens the proper item xaml and initiates a "item change event" for drinks
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        void DrinksButtonClick(object sender, RoutedEventArgs e)
        {
            IOrderItem item = meal.Drink;
            if (item is Drink)
            {
                if (item is AretinoAppleJuice)
                {
                    Win.Dri.AA = new AretinoAppleJuiceCustom();
                    Win.containerBorder.Child = Win.Dri.AA;
                    Win.Dri.AA.AboveLevel = Win.Dri;
                    Win.Dri.AA.DataContext = (AretinoAppleJuice)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Dri.AA.Done.Click -= Win.Dri.AA.DoneClick;
                    Win.Dri.AA.Done.Click += Win.Dri.AA.CancelItem;
                    Win.Dri.AA.Done.Content = "Done";
                    Win.Dri.AA.Done.Visibility = Visibility.Visible;
                }
                else if (item is CandlehearthCoffee)
                {
                    Win.Dri.CC = new CandlehearthCoffeeCustom();
                    Win.containerBorder.Child = Win.Dri.CC;
                    Win.Dri.CC.AboveLevel = Win.Dri;
                    Win.Dri.CC.DataContext = (CandlehearthCoffee)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Dri.CC.Done.Click -= Win.Dri.CC.DoneClick;
                    Win.Dri.CC.Done.Click += Win.Dri.CC.CancelItem;
                    Win.Dri.CC.Done.Content = "Done";
                    Win.Dri.CC.Done.Visibility = Visibility.Visible;
                }
                else if (item is MarkarthMilk)
                {
                    Win.Dri.MM = new MarkarthMilkCustom();
                    Win.containerBorder.Child = Win.Dri.MM;
                    Win.Dri.MM.AboveLevel = Win.Dri;
                    Win.Dri.MM.DataContext = (MarkarthMilk)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Dri.MM.Done.Click -= Win.Dri.MM.DoneClick;
                    Win.Dri.MM.Done.Click += Win.Dri.MM.CancelItem;
                    Win.Dri.MM.Done.Content = "Done";
                    Win.Dri.MM.Done.Visibility = Visibility.Visible;
                }
                else if (item is SailorSoda)
                {
                    Win.Dri.SS = new SailorsSodaCustom();
                    Win.containerBorder.Child = Win.Dri.SS;
                    Win.Dri.SS.AboveLevel = Win.Dri;
                    Win.Dri.SS.DataContext = (SailorSoda)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Dri.SS.Done.Click -= Win.Dri.SS.DoneClick;
                    Win.Dri.SS.Done.Click += Win.Dri.SS.CancelItem;
                    Win.Dri.SS.Done.Content = "Done";
                    Win.Dri.SS.Done.Visibility = Visibility.Visible;
                }
                else if (item is WarriorWater)
                {
                    Win.Dri.AA = new AretinoAppleJuiceCustom();
                    Win.containerBorder.Child = Win.Dri.AA;
                    Win.Dri.AA.AboveLevel = Win.Dri;
                    Win.Dri.AA.DataContext = (AretinoAppleJuice)item;
                    Win.OrderItem = true;
                    Win.Back.IsEnabled = true;
                    Win.Dri.AA.Done.Click -= Win.Dri.AA.DoneClick;
                    Win.Dri.AA.Done.Click += Win.Dri.AA.CancelItem;
                    Win.Dri.AA.Done.Content = "Done";
                    Win.Dri.AA.Done.Visibility = Visibility.Visible;
                }
                else
                {
                    Win.Menu = 0;
                    Win.LayerIndex = 0;
                    Win.Back.IsEnabled = false;
                    Win.containerBorder.Child = Win.Topie;
                    Win.isCombo = false;
                    Win.OrderItem = false;
                }
            }
        }

        /// <summary>
        /// doesnt do anything
        /// </summary>
        public void Done(object sender, RoutedEventArgs e)
        {
            Win.isCombo = false;
        }

        /// <summary>
        /// Grabs the apropriate IOrderItem and removes it
        /// Passes click event afterwards to EntreeButtons.xaml
        /// </summary>
        /// <param name="sender"> button object</param>
        /// <param name="e"> event </param>
        public void CancelItem(object sender, RoutedEventArgs e)
        {
            Win.CancelItem(meal); // 
        }
    }
}
