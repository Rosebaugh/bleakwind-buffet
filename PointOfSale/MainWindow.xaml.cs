/*
 * Author: Caleb Rosebaugh
 * Class name: MainWindow.xaml.cs
 * Purpose: Class used to create WPF.
 */
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
        /// Index of which menu you are in
        /// </summary>
        /// <value>0 = Top Menu, 1 = Entree, 2 = Sides, 3 = Drinks</value>
        private int Menu = 0;

        /// <summary>
        /// Index of which layer you are in
        /// </summary>
        /// <value> 0 = top, 1 = Entree, Sides, or Drinks, 2 = Item Customization screen</value>
        private int LayerIndex = 0;

        /// <summary>
        /// initializes WPF and public values
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
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
        /// Whenever back is clicked, goes back to previous screen (except if item was added to order)
        /// </summary>
        /// <param name="sender"> Button object</param>
        /// <param name="e"> Event </param>
        public void BackButtonClick(object sender, RoutedEventArgs e)
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

        /// <summary>
        /// Allows Other .xaml files to increment LayerIndex
        /// </summary>
        /// <param name="i"> number to change LayerIndex by</param>
        public void ChangeLayerIndex(int i)
        {
            LayerIndex += i;
        }
    }
}
