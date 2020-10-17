/*
 * Author: Caleb Rosebaugh
 * Class name: CurrencyScreen.xaml.cs
 * Purpose: Class used to create WPF user control.
 */
using BleakwindBuffet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CurrencyScreen.xaml
    /// </summary>
    public partial class CurrencyScreen : UserControl
    {
        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// private Holder of Order Class
        /// </summary>
        private Order price;

        /// <summary>
        /// Returns Order Class
        /// </summary>
        public Order order
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                BottomPannel.Child = new TotalSale() { TotalAmount = "$" + string.Format("{0:N2}", Math.Round(Convert.ToDouble(price.Total), 2)), DueAmount = "$" + string.Format("{0:N2}", Math.Round(Convert.ToDouble(price.Total), 2)), ChangeOwed = "0.00", aboveLevel = this };
                
                ChangeDrawer = new Change();
                ChangeDrawer.aboveLevel = this;
                ChangeDrawer.Total = Convert.ToDouble(price.Total);
            }
        }

        /// <summary>
        /// Holds child variable of Change
        /// </summary>
        public Change ChangeDrawer;

        /// <summary>
        /// Initializes class
        /// </summary>
        public CurrencyScreen()
        {
            InitializeComponent();
            int[] dollars = new int[] { 100, 50, 20, 10, 5, 2, 1 };
            int[] coins = new int[] { 100, 50, 25, 10, 5, 1 };
            foreach (int dollar in dollars)
            {
                Left.Children.Add(new CoinButton() { CurrencyAmount = "$" + dollar, ReturnAmount = 0, CurrentAmount = 0, aboveLevel = this, isCoin = false });

            }
            foreach (int coin in coins)
            {
                if(coin == 100)
                {
                    Right.Children.Add(new CoinButton() { CurrencyAmount = "$" + 1, ReturnAmount = 0, CurrentAmount = 0, aboveLevel = this, isCoin = true });
                }
                else
                {
                    Right.Children.Add(new CoinButton() { CurrencyAmount = coin + "¢", ReturnAmount = 0, CurrentAmount = 0, aboveLevel = this, isCoin = true });
                }
            }
        }

        /// <summary>
        /// Updates Cash Change numbers
        /// </summary>
        /// <param name="Amount">Ammount paid</param>
        /// <param name="Currency">Type of bill</param>
        /// <param name="isAdding">bool of if adding or subtracting</param>
        public void UpdateTotalStuff(int Amount, string Currency, bool isAdding)
        {
            double CashAmount = 0;
            if (Currency.Contains("$"))
            {
                CashAmount = Convert.ToInt32(Currency.Replace("$", ""));
            }
            else
            {
                CashAmount = Convert.ToDouble(Currency.Replace("¢", ""))/100;
            }
            if (isAdding)
            {
                if (BottomPannel.Child is TotalSale tot)
                {
                    ChangeDrawer.givenAmount += CashAmount;
                    tot.DueAmount = "$" + string.Format("{0:N2}", Math.Round(Convert.ToDouble(ChangeDrawer.OwedStill), 2));
                    tot.ChangeOwed = "$" + string.Format("{0:N2}", Math.Round(Convert.ToDouble(ChangeDrawer.CustomerGive), 2));

                    ChangeDrawer.ChangeCalculator();
                    foreach (CoinButton coin in Left.Children)
                    {
                        switch (coin.CurrencyAmount)
                        {
                            case "$100":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[0];
                                break;
                            case "$50":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[1];
                                break;
                            case "$20":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[2];
                                break;
                            case "$10":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[3];
                                break;
                            case "$5":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[4];
                                break;
                            case "$2":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[5];
                                break;
                            case "$1":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[6];
                                break;
                        }
                    }
                    foreach (CoinButton coin in Right.Children)
                    {
                        switch (coin.CurrencyAmount)
                        {
                            
                            case "$1":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[7];
                                break;
                            case "50¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[8];
                                break;
                            case "25¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[9];
                                break;
                            case "10¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[10];
                                break;
                            case "5¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[11];
                                break;
                            case "1¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[12];
                                break;
                        }
                    }
                    tot.EnableFinalizeButton();
                }
            }
            else
            {
                if (BottomPannel.Child is TotalSale tot)
                {
                    ChangeDrawer.givenAmount -= CashAmount;
                    tot.DueAmount = "$" + string.Format("{0:N2}", Math.Round(Convert.ToDouble(ChangeDrawer.OwedStill), 2));
                    tot.ChangeOwed = "$" + string.Format("{0:N2}", Math.Round(Convert.ToDouble(ChangeDrawer.CustomerGive), 2));

                    ChangeDrawer.ChangeCalculator();
                    foreach (CoinButton coin in Left.Children)
                    {
                        switch (coin.CurrencyAmount)
                        {
                            case "$100":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[0];
                                break;
                            case "$50":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[1];
                                break;
                            case "$20":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[2];
                                break;
                            case "$10":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[3];
                                break;
                            case "$5":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[4];
                                break;
                            case "$2":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[5];
                                break;
                            case "$1":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[6];
                                break;
                        }
                    }
                    foreach (CoinButton coin in Right.Children)
                    {
                        switch (coin.CurrencyAmount)
                        {

                            case "$1":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[7];
                                break;
                            case "50¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[8];
                                break;
                            case "25¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[9];
                                break;
                            case "10¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[10];
                                break;
                            case "5¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[11];
                                break;
                            case "1¢":
                                coin.ReturnAmount = ChangeDrawer.GiveBackChange[12];
                                break;
                        }
                    }
                    tot.EnableFinalizeButton();
                }
            }
        }

        /// <summary>
        /// Enabled back button to not mess up cashDrawers count
        /// </summary>
        public void BackOutOfCash()
        {
            foreach (CoinButton coin in Left.Children)
            {
                switch (coin.CurrencyAmount)
                {
                    case "$100":
                        RoundRegister.CashDrawer.Hundreds -= coin.CurrentAmount;
                        break;
                    case "$50":
                        RoundRegister.CashDrawer.Fifties -= coin.CurrentAmount;
                        break;
                    case "$20":
                        RoundRegister.CashDrawer.Twenties -= coin.CurrentAmount;
                        break;
                    case "$10":
                        RoundRegister.CashDrawer.Tens -= coin.CurrentAmount;
                        break;
                    case "$5":
                        RoundRegister.CashDrawer.Fives -= coin.CurrentAmount;
                        break;
                    case "$2":
                        RoundRegister.CashDrawer.Twos -= coin.CurrentAmount;
                        break;
                    case "$1":
                        RoundRegister.CashDrawer.Ones -= coin.CurrentAmount;
                        break;
                }
            }
            foreach (CoinButton coin in Right.Children)
            {
                switch (coin.CurrencyAmount)
                {

                    case "$1":
                        RoundRegister.CashDrawer.Dollars -= coin.CurrentAmount;
                        break;
                    case "50¢":
                        RoundRegister.CashDrawer.HalfDollars -= coin.CurrentAmount;
                        break;
                    case "25¢":
                        RoundRegister.CashDrawer.Quarters -= coin.CurrentAmount;
                        break;
                    case "10¢":
                        RoundRegister.CashDrawer.Dimes -= coin.CurrentAmount;
                        break;
                    case "5¢":
                        RoundRegister.CashDrawer.Nickels -= coin.CurrentAmount;
                        break;
                    case "1¢":
                        RoundRegister.CashDrawer.Pennies -= coin.CurrentAmount;
                        break;
                }
            }
        }

        /// <summary>
        /// Finalizes sale of the items and put money in cash register and prints
        /// </summary>
        public void FinalizeSale()
        {
            foreach (CoinButton coin in Left.Children)
            {
                switch (coin.CurrencyAmount)
                {
                    case "$100":
                        RoundRegister.CashDrawer.Hundreds -= coin.ReturnAmount;
                        break;
                    case "$50":
                        RoundRegister.CashDrawer.Fifties -= coin.ReturnAmount;
                        break;
                    case "$20":
                        RoundRegister.CashDrawer.Twenties -= coin.ReturnAmount;
                        break;
                    case "$10":
                        RoundRegister.CashDrawer.Tens -= coin.ReturnAmount;
                        break;
                    case "$5":
                        RoundRegister.CashDrawer.Fives -= coin.ReturnAmount;
                        break;
                    case "$2":
                        RoundRegister.CashDrawer.Twos -= coin.ReturnAmount;
                        break;
                    case "$1":
                        RoundRegister.CashDrawer.Ones -= coin.ReturnAmount;
                        break;
                }
            }
            foreach (CoinButton coin in Right.Children)
            {
                switch (coin.CurrencyAmount)
                {

                    case "$1":
                        RoundRegister.CashDrawer.Dollars -= coin.ReturnAmount;
                        break;
                    case "50¢":
                        RoundRegister.CashDrawer.HalfDollars -= coin.ReturnAmount;
                        break;
                    case "25¢":
                        RoundRegister.CashDrawer.Quarters -= coin.ReturnAmount;
                        break;
                    case "10¢":
                        RoundRegister.CashDrawer.Dimes -= coin.ReturnAmount;
                        break;
                    case "5¢":
                        RoundRegister.CashDrawer.Nickels -= coin.ReturnAmount;
                        break;
                    case "1¢":
                        RoundRegister.CashDrawer.Pennies -= coin.ReturnAmount;
                        break;
                }
            }
            if(BottomPannel.Child is TotalSale tot)
            {
                RoundRegister.CashDrawer.OpenDrawer();
                Win.FinalizeOrder.PrintOrder("Cash", tot.TotalAmount, tot.ChangeOwed);
                Win.NewOrder();
            }
        }


    }
}
