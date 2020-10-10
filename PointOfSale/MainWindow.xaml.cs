/*
 * Author: Caleb Rosebaugh
 * Class name: MainWindow.xaml.cs
 * Purpose: Class used to create WPF.
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using PointOfSale.POSCustomization.Drinks;
using PointOfSale.POSCustomization.Entrees;
using PointOfSale.POSCustomization.Sides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Menu choice shown at start
        /// </summary>
        public MenuChoice Topie { get; set; }

        /// <summary>
        /// Order List shown on the right
        /// </summary>
        public OrderWindow Right { get; set; }

        /// <summary>
        /// EntreeButtons shown after clicking Entree
        /// </summary>
        public EntreeButtons Ent { get; set; }

        /// <summary>
        /// DrinkButtons shown after clicking Drinks
        /// </summary>
        public DrinkButtons Dri { get; set; }

        /// <summary>
        /// SideButtons shown after clicking Sides
        /// </summary>
        public SideButtons Sid { get; set; }

        /// <summary>
        /// ComboButtons shown after clicking Sides
        /// </summary>
        public ComboButtons Comb { get; set; }

        /// <summary>
        /// ComboAlterButtons shown after clicking on Combo on list
        /// </summary>
        public ComboAlterButtons CombAlt { get; set; }

        /// <summary>
        /// Index of which menu you are in
        /// </summary>
        /// <value>0 = Top Menu, 1 = Entree, 2 = Sides, 3 = Drinks</value>
        public int Menu = 0;

        /// <summary>
        /// Index of which layer you are in
        /// </summary>
        /// <value> 0 = top, 1 = Entree, Sides, or Drinks, 2 = Item Customization screen</value>
        public int LayerIndex = 0;

        /// <summary>
        /// bool of if customizing a combo item
        /// </summary>
        public bool isCombo = false;

        /// <summary>
        /// bool if altering added item
        /// </summary>
        public bool OrderItem = false;

        /// <summary>
        /// list of all finalized orders
        /// </summary>
        public List<Order> Orders;

        /// <summary>
        /// initializes WPF and public values
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            /*              
            Right = new OrderWindow();
            Right.Name = "SideList";
            orderBorder.Child = Right;
             */
            Topie = TopMenu;
            Ent = new EntreeButtons
            {
                Name="EntreeButtons"
            };
            Dri = new DrinkButtons
            {
                Name = "DrinkButtons"
            };
            Sid = new SideButtons
            {
                Name = "SideButtons"
            };
            Right = SideList;
            Right.Win = this;
            Topie.Win = this;
            Ent.Win = this;
            Dri.Win = this;
            Sid.Win = this;
        }

        /// <summary>
        /// When Entrees is clicked in MenuChoice.xaml, switch screen to Entrees
        /// </summary>
        public void Entrees()
        {
            containerBorder.Child = null;
            containerBorder.Child = Ent;
            Menu = 1;
            LayerIndex++;
            Back.IsEnabled = true;
        }

        /// <summary>
        /// When Sides is clicked in MenuChoice.xaml, switch screen to Sides
        /// </summary>
        public void Sides()
        {
            containerBorder.Child = null;
            containerBorder.Child = Sid;
            Menu = 2;
            LayerIndex++;
            Back.IsEnabled = true;
        }

        /// <summary>
        /// When Drinks is clicked in MenuChoice.xaml, switch screen to Drinks
        /// </summary>
        public void Drinks()
        {
            containerBorder.Child = null;
            containerBorder.Child = Dri;
            Menu = 3;
            LayerIndex++;
            Back.IsEnabled = true;
        }

        /// <summary>
        /// When Combo is clicked in MenuChoice.xaml, switch screen to Combo
        /// </summary>
        public void Combo()
        {
            Comb = new ComboButtons
            {
                Name = "ComboButtons"
            };
            Comb.Win = this;
            containerBorder.Child = null;
            containerBorder.Child = Comb;
            Menu = 4;
            LayerIndex++;
            Back.IsEnabled = true;
            isCombo = true;
        }

        /// <summary>
        /// Whenever back is clicked, goes back to previous screen (except if item was added to order)
        /// </summary>
        /// <param name="sender"> Button object</param>
        /// <param name="e"> Event </param>
        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (OrderItem)
            {
                OrderItem = false;
                LayerIndex--;
                BackButtonClick(sender, e);
                Right.UnselectItem();
                Reset();
            }
            else if (isCombo)
            {
                containerBorder.Child = null;
                if (Menu == 4)
                {
                    Menu = 0;
                    LayerIndex = 0;
                    Back.IsEnabled = false;
                    containerBorder.Child = Topie;
                    isCombo = false;
                }
                else if(LayerIndex == 3)
                {
                    if (Menu == 1) Entrees();
                    else if (Menu == 2) Sides();
                    else if (Menu == 3) Drinks();
                    else LayerIndex += 2;
                    LayerIndex--;
                    LayerIndex--;
                }
                else
                {
                    Menu = 4;
                    LayerIndex = 1;
                    containerBorder.Child = Comb;
                }
            }
            else
            {
                containerBorder.Child = null;
                LayerIndex--;
                if (LayerIndex <= 0 || Menu == 0)
                {
                    LayerIndex = 0;
                    Back.IsEnabled = false;
                    containerBorder.Child = Topie;
                    Menu = 0;
                }
                if (LayerIndex == 1)
                {
                    if (Menu == 1) Entrees();
                    else if (Menu == 2) Sides();
                    else if (Menu == 3) Drinks();
                    else LayerIndex++;
                    LayerIndex--;
                }
            }
        }

        /// <summary>
        /// Allows Other .xaml files to increment LayerIndex
        /// </summary>
        /// <param name="i"> number to change LayerIndex by</param>
        public void ChangeLayerIndex(int i)
        {
            LayerIndex += i;
        }

        /// <summary>
        /// Adds Item to the order if item is not in combo
        /// Adds items to the combo if in combo
        /// Adds combo to the order if not combo
        /// </summary>
        /// <param name="that">item to add</param>
        public void AddItem(IOrderItem that)
        {
            if (OrderItem)
            {
                if (that is Entree) Comb.meal.Entree = (Entree)that;
                else if (that is Side) Comb.meal.Side = (Side)that;
                else if (that is Drink) Comb.meal.Drink = (Drink)that;
                ChangeLayerIndex(-1);
                BackButtonClick(new object(), new RoutedEventArgs());
            }
            if (isCombo)
            {
                if (that is Entree) Comb.meal.Entree = (Entree)that;
                else if (that is Side) Comb.meal.Side = (Side)that;
                else if (that is Drink) Comb.meal.Drink = (Drink)that;
                ChangeLayerIndex(-1);
                BackButtonClick(new object(), new RoutedEventArgs());
            }
            else
            {
                Right.AddItem(that);
                ChangeLayerIndex(-1);
                BackButtonClick(new object(), new RoutedEventArgs());
            }
        }

        /// <summary>
        /// removes Item from the order if item is not in combo
        /// Adds changes item in combo if in combo
        /// </summary>
        /// <param name="that">item to add</param>
        public void CancelItem(IOrderItem item)
        {
            if (isCombo)
            {
                LayerIndex = 0;
                Back.IsEnabled = false;
                containerBorder.Child = Topie;
                Menu = 0;
                OrderItem = false;
                isCombo = false;
                Right.UnselectItem();
            }
            else
            {
                LayerIndex = 0;
                Back.IsEnabled = false;
                containerBorder.Child = Topie;
                Menu = 0;
                OrderItem = false;
                isCombo = false;
                Right.Remove(item);
                Right.UnselectItem();
                Reset();
            }
        }

        /// <summary>
        /// opens item customization screen
        /// </summary>
        /// <param name="item"></param>
        public void AlterItem(IOrderItem item)
        {
            if(item is ComboMeal)
            {
                containerBorder.Child = null;

                CombAlt = new ComboAlterButtons();
                CombAlt.meal = (ComboMeal)item;
                CombAlt.Win = this;
                containerBorder.Child = CombAlt;
                CombAlt.DataContext = (ComboMeal)item;
                OrderItem = true;
                isCombo = true;
                Back.IsEnabled = true;
                CombAlt.Cancel.Click += CombAlt.CancelItem;
            }
            else if(item is Entree)
            {
                containerBorder.Child = null;
                if (item is BriarheartBurger)
                {
                    Ent.BB = new BriarHeartCustom();
                    containerBorder.Child = Ent.BB;
                    Ent.BB.AboveLevel = Ent;
                    Ent.BB.DataContext = (BriarheartBurger)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Ent.BB.Done.Click -= Ent.BB.DoneClick;
                    Ent.BB.Done.Click += Ent.BB.CancelItem;
                    Ent.BB.Done.Content = "Cancel";
                }
                else if (item is DoubleDraugr)
                {
                    Ent.DD = new DoubleDraugrCustom();
                    containerBorder.Child = Ent.DD;
                    Ent.DD.AboveLevel = Ent;
                    Ent.DD.DataContext = (DoubleDraugr)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Ent.DD.Done.Click -= Ent.DD.DoneClick;
                    Ent.DD.Done.Click += Ent.DD.CancelItem;
                    Ent.DD.Done.Content = "Cancel";
                }
                else if (item is GardenOrcOmelette)
                {
                    Ent.GOO = new GardenOrcOmeletteCustom();
                    containerBorder.Child = Ent.GOO;
                    Ent.GOO.AboveLevel = Ent;
                    Ent.GOO.DataContext = (GardenOrcOmelette)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Ent.GOO.Done.Click -= Ent.GOO.DoneClick;
                    Ent.GOO.Done.Click += Ent.GOO.CancelItem;
                    Ent.GOO.Done.Content = "Cancel";
                }
                else if (item is PhillyPoacher)
                {
                    Ent.PP = new PhillyPoacherCustom();
                    containerBorder.Child = Ent.PP;
                    Ent.PP.AboveLevel = Ent;
                    Ent.PP.DataContext = (PhillyPoacher)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Ent.PP.Done.Click -= Ent.PP.DoneClick;
                    Ent.PP.Done.Click += Ent.PP.CancelItem;
                    Ent.PP.Done.Content = "Cancel";
                }
                else if (item is SmokehouseSkeleton)
                {
                    Ent.SS = new SmokehouseSkeletonCustom();
                    containerBorder.Child = Ent.SS;
                    Ent.SS.AboveLevel = Ent;
                    Ent.SS.DataContext = (SmokehouseSkeleton)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Ent.SS.Done.Click -= Ent.SS.DoneClick;
                    Ent.SS.Done.Click += Ent.SS.CancelItem;
                    Ent.SS.Done.Content = "Cancel";
                }
                else if (item is ThalmorTriple)
                {
                    Ent.TT = new ThalmorTripleCustom();
                    containerBorder.Child = Ent.TT;
                    Ent.TT.AboveLevel = Ent;
                    Ent.TT.DataContext = (ThalmorTriple)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Ent.TT.Done.Click -= Ent.TT.DoneClick;
                    Ent.TT.Done.Click += Ent.TT.CancelItem;
                    Ent.TT.Done.Content = "Cancel";
                }
                else if (item is ThugsTBone)
                {
                    Ent.TTB = new ThugsTBoneCustom();
                    containerBorder.Child = Ent.TTB;
                    Ent.TTB.AboveLevel = Ent;
                    Ent.TTB.DataContext = (ThugsTBone)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Ent.TTB.Done.Click -= Ent.TTB.DoneClick;
                    Ent.TTB.Done.Click += Ent.TTB.CancelItem;
                    Ent.TTB.Done.Content = "Cancel";
                }
                else
                {
                    Menu = 0;
                    LayerIndex = 0;
                    Back.IsEnabled = false;
                    containerBorder.Child = Topie;
                    isCombo = false;
                    OrderItem = false;
                }
            }
            else if( item is Side)
            {
                if (item is DragonbornWaffleFries)
                {
                    Sid.DW = new DragonbornWaffleFriesCustom();
                    containerBorder.Child = Sid.DW;
                    Sid.DW.AboveLevel = Sid;
                    Sid.DW.DataContext = (DragonbornWaffleFries)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Sid.DW.Done.Click -= Sid.DW.DoneClick;
                    Sid.DW.Done.Click += Sid.DW.CancelItem;
                    Sid.DW.Done.Content = "Cancel";
                }
                else if (item is FriedMiraak)
                {
                    Sid.FM = new FriedMiraakCustom();
                    containerBorder.Child = Sid.FM;
                    Sid.FM.AboveLevel = Sid;
                    Sid.FM.DataContext = (FriedMiraak)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Sid.FM.Done.Click -= Sid.FM.DoneClick;
                    Sid.FM.Done.Click += Sid.FM.CancelItem;
                    Sid.FM.Done.Content = "Cancel";
                }
                else if (item is MadOtarGrits)
                {
                    Sid.MOG = new MadOtarGritsCustom();
                    containerBorder.Child = Sid.MOG;
                    Sid.MOG.AboveLevel = Sid;
                    Sid.MOG.DataContext = (MadOtarGrits)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Sid.MOG.Done.Click -= Sid.MOG.DoneClick;
                    Sid.MOG.Done.Click += Sid.MOG.CancelItem;
                    Sid.MOG.Done.Content = "Cancel";
                }
                else if (item is VokunSalad)
                {
                    Sid.VS = new VokunSaladCustom();
                    containerBorder.Child = Sid.VS;
                    Sid.VS.AboveLevel = Sid;
                    Sid.VS.DataContext = (VokunSalad)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Sid.VS.Done.Click -= Sid.VS.DoneClick;
                    Sid.VS.Done.Click += Sid.VS.CancelItem;
                    Sid.VS.Done.Content = "Cancel";
                }
                else
                {
                    Menu = 0;
                    LayerIndex = 0;
                    Back.IsEnabled = false;
                    containerBorder.Child = Topie;
                    isCombo = false;
                    OrderItem = false;
                }
            }
            else if( item is Drink)
            {
                if(item is AretinoAppleJuice)
                {
                    Dri.AA = new AretinoAppleJuiceCustom();
                    containerBorder.Child = Dri.AA;
                    Dri.AA.AboveLevel = Dri;
                    Dri.AA.DataContext = (AretinoAppleJuice)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Dri.AA.Done.Click -= Dri.AA.DoneClick;
                    Dri.AA.Done.Click += Dri.AA.CancelItem;
                    Dri.AA.Done.Content = "Cancel";
                }
                else if (item is CandlehearthCoffee)
                {
                    Dri.CC = new CandlehearthCoffeeCustom();
                    containerBorder.Child = Dri.CC;
                    Dri.CC.AboveLevel = Dri;
                    Dri.CC.DataContext = (CandlehearthCoffee)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Dri.CC.Done.Click -= Dri.CC.DoneClick;
                    Dri.CC.Done.Click += Dri.CC.CancelItem;
                    Dri.CC.Done.Content = "Cancel";
                }
                else if (item is MarkarthMilk)
                {
                    Dri.MM = new MarkarthMilkCustom();
                    containerBorder.Child = Dri.MM;
                    Dri.MM.AboveLevel = Dri;
                    Dri.MM.DataContext = (MarkarthMilk)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Dri.MM.Done.Click -= Dri.MM.DoneClick;
                    Dri.MM.Done.Click += Dri.MM.CancelItem;
                    Dri.MM.Done.Content = "Cancel";
                }
                else if (item is SailorSoda)
                {
                    Dri.SS = new SailorsSodaCustom();
                    containerBorder.Child = Dri.SS;
                    Dri.SS.AboveLevel = Dri;
                    Dri.SS.DataContext = (SailorSoda)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Dri.SS.Done.Click -= Dri.SS.DoneClick;
                    Dri.SS.Done.Click += Dri.SS.CancelItem;
                    Dri.SS.Done.Content = "Cancel";
                }
                else if (item is WarriorWater)
                {
                    Dri.WW = new WarriorWaterCustom();
                    containerBorder.Child = Dri.WW;
                    Dri.WW.AboveLevel = Dri;
                    Dri.WW.DataContext = (WarriorWater)item;
                    OrderItem = true;
                    Back.IsEnabled = true;
                    Dri.WW.Done.Click -= Dri.WW.DoneClick;
                    Dri.WW.Done.Click += Dri.WW.CancelItem;
                    Dri.WW.Done.Content = "Cancel";
                }
                else
                {
                    Menu = 0;
                    LayerIndex = 0;
                    Back.IsEnabled = false;
                    containerBorder.Child = Topie;
                    isCombo = false;
                    OrderItem = false;
                }
            }
        }

        /// <summary>
        /// adds order to list of orders
        /// resets screen for new order
        /// </summary>
        /// <param name="thing"> order </param>
        public void Finish(Order thing)
        {
            if (Orders == null) Orders = new List<Order>();
            Orders.Add(thing);
            NewOrder();
        }

        /// <summary>
        /// resets screen for order. more might be added for this
        /// </summary>
        public void NewOrder()
        {
            Reset();
        }

        /// <summary>
        /// resets back to begining screen
        /// </summary>
        public void Reset()
        {
            LayerIndex = 0;
            Back.IsEnabled = false;
            containerBorder.Child = Topie;
            Menu = 0;
            OrderItem = false;
            isCombo = false;
            Right.UnselectItem();
        }
    }
}
