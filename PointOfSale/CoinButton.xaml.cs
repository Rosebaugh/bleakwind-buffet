/*
 * Author: Caleb Rosebaugh
 * Class name: CoinButton.xaml.cs
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
    /// Interaction logic for CoinButton.xaml
    /// </summary>
    public partial class CoinButton : UserControl
    {
        /// <summary>
        /// Creates Dependency Property for the ReturnAmount
        /// </summary>
        public static DependencyProperty ReturnAmountProperty = DependencyProperty.Register("ReturnAmount", typeof(int), typeof(CoinButton));

        /// <summary>
        /// Creates Dependency Property for the CurrentAmount
        /// </summary>
        public static DependencyProperty CurrentAmountProperty = DependencyProperty.Register("CurrentAmount", typeof(int), typeof(CoinButton));

        /// <summary>
        /// Creates Dependency Property for the CurrencyAmount
        /// </summary>
        public static DependencyProperty CurrencyAmountProperty = DependencyProperty.Register("CurrencyAmount", typeof(string), typeof(CoinButton));

        /// <summary>
        /// variable for above parent class
        /// </summary>
        public CurrencyScreen aboveLevel;

        /// <summary>
        /// bool of if is a coin or dollar bill
        /// </summary>
        public bool isCoin;

        /// <summary>
        /// get set for return amount
        /// </summary>
        public int ReturnAmount
        {
            get => (int)GetValue(ReturnAmountProperty);
            set => SetValue(ReturnAmountProperty, value);
        }

        /// <summary>
        /// get set for Current amount
        /// </summary>
        public int CurrentAmount
        {
            get => (int)GetValue(CurrentAmountProperty);
            set => SetValue(CurrentAmountProperty, value);
        }

        /// <summary>
        /// get set for Currency amount
        /// </summary>
        public string CurrencyAmount
        {
            get => (string)GetValue(CurrencyAmountProperty);
            set => SetValue(CurrencyAmountProperty, value);
        }

        /// <summary>
        /// initializes class
        /// </summary>
        public CoinButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Addition and subtraction events
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">event</param>
        void HandleAddSubtract(object sender, RoutedEventArgs e)
        {
            if(e.OriginalSource is Button b)
            {
                if (b.Name == "Add")
                {
                    CurrentAmount++;

                    ChangeRegister(CurrencyAmount, 1);

                    aboveLevel.UpdateTotalStuff(CurrentAmount, CurrencyAmount, true);
                    e.Handled = true;
                }
                else if (b.Name == "Subtract" && CurrentAmount > 0)
                {
                    CurrentAmount--;

                    ChangeRegister(CurrencyAmount, -1);

                    aboveLevel.UpdateTotalStuff(CurrentAmount, CurrencyAmount, false);
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Adds money given to register to accuratly give change
        /// </summary>
        /// <param name="k">bill type</param>
        /// <param name="i">amount to add</param>
        void ChangeRegister(string k, int i)
        {
            switch (k)
            {
                case "$100":
                    RoundRegister.CashDrawer.Hundreds += i;
                    break;
                case "$50":
                    RoundRegister.CashDrawer.Fifties += i;
                    break;
                case "$20":
                    RoundRegister.CashDrawer.Twenties += i;
                    break;
                case "$10":
                    RoundRegister.CashDrawer.Tens += i;
                    break;
                case "$5":
                    RoundRegister.CashDrawer.Fives += i;
                    break;
                case "$2":
                    RoundRegister.CashDrawer.Twos += i;
                    break;
                case "$1":
                    if (isCoin)
                    {
                        RoundRegister.CashDrawer.Dollars += i;
                    }
                    else
                    {
                        RoundRegister.CashDrawer.Ones += i;
                    }
                    break;
                case "50¢":
                    RoundRegister.CashDrawer.HalfDollars += i;
                    break;
                case "25¢":
                    RoundRegister.CashDrawer.Quarters += i;
                    break;
                case "10¢":
                    RoundRegister.CashDrawer.Dimes += i;
                    break;
                case "5¢":
                    RoundRegister.CashDrawer.Nickels += i;
                    break;
                case "1¢":
                    RoundRegister.CashDrawer.Pennies += i;
                    break;
            }
        }
    }
}
