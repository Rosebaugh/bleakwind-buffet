/*
 * Author: Caleb Rosebaugh
 * Class name: Change.cs
 * Purpose: Class used to create change for money
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;

namespace PointOfSale
{
    public class Change
    {
        /// <summary>
        /// abovelevel variable
        /// </summary>
        public CurrencyScreen aboveLevel;

        /// <summary>
        /// private backing variable
        /// </summary>
        private double total;

        /// <summary>
        /// Total customer needs to pay <<get, set>>
        /// </summary>
        public double Total
        {
            get
            {
                return Math.Round(total, 2);
            }
            set
            {
                total = value;
            }
        }

        /// <summary>
        /// Amount customer has given
        /// </summary>
        public double givenAmount;

        /// <summary>
        /// Value of money customer still needs to pay
        /// </summary>
        public double OwedStill
        {
            get
            {
                return (Math.Round(Total - givenAmount, 2) <= 0) ? 0 : Math.Round(Total - givenAmount, 2);
            }
        }

        /// <summary>
        /// Value of money the customer paid over
        /// </summary>
        public double CustomerGive
        {
            get
            {
                if ((OwedStill == 0))
                {
                    return Math.Round(givenAmount - Total, 2);
                }
                else {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Array that will hold updated optimal change given back
        /// </summary>
        /// <index>0 = $100, 1 = $50, 2 = $20, 3 = $10, 4 = $5, 5 = $2, 6 = $1, 7 = 100¢, 8 = 50¢, 9 = 25¢, 10 = 10¢, 11 = 5¢, 12 = 1¢</index>
        public int[] GiveBackChange;

        /// <summary>
        /// initializes change
        /// </summary>
        public Change()
        {
            GiveBackChange = new int[13];
        }

        /// <summary>
        /// Caclulates the change for the amount of cash given 
        /// </summary>
        public void ChangeCalculator()
        {
            GiveBackChange = new int[13];
            double MoneyLeft = CustomerGive;
            double prevMoney;
            do
            {
                prevMoney = MoneyLeft;
                if (MoneyLeft >= 100 && RoundRegister.CashDrawer.Hundreds > GiveBackChange[0])
                {
                    GiveBackChange[0]++;
                    MoneyLeft -= 100;
                }
                else if (MoneyLeft >= 50 && RoundRegister.CashDrawer.Fifties > GiveBackChange[1])
                {
                    GiveBackChange[1]++;
                    MoneyLeft -= 50;
                }
                else if (MoneyLeft >= 20 && RoundRegister.CashDrawer.Twenties > GiveBackChange[2])
                {
                    GiveBackChange[2]++;
                    MoneyLeft -= 20;
                }
                else if (MoneyLeft >= 10 && RoundRegister.CashDrawer.Tens > GiveBackChange[3])
                {
                    GiveBackChange[3]++;
                    MoneyLeft -= 10;
                }
                else if (MoneyLeft >= 5 && RoundRegister.CashDrawer.Fives > GiveBackChange[4])
                {
                    GiveBackChange[4]++;
                    MoneyLeft -= 5;
                }
                else if (MoneyLeft >= 2 && RoundRegister.CashDrawer.Twos > GiveBackChange[5])
                {
                    GiveBackChange[5]++;
                    MoneyLeft -= 2;
                }
                else if (MoneyLeft >= 1 && RoundRegister.CashDrawer.Ones > GiveBackChange[6])
                {
                    GiveBackChange[6]++;
                    MoneyLeft -= 1;
                }
                else if (MoneyLeft >= 1 && RoundRegister.CashDrawer.Dollars > GiveBackChange[7])
                {
                    GiveBackChange[7]++;
                    MoneyLeft -= 1;
                }
                else if (MoneyLeft >= .5 && RoundRegister.CashDrawer.HalfDollars > GiveBackChange[8])
                {
                    GiveBackChange[8]++;
                    MoneyLeft -= .5;
                }
                else if (MoneyLeft >= .25 && RoundRegister.CashDrawer.Quarters > GiveBackChange[9])
                {
                    GiveBackChange[9]++;
                    MoneyLeft -= .25;
                }
                else if (MoneyLeft >= .10 && RoundRegister.CashDrawer.Dimes > GiveBackChange[10])
                {
                    GiveBackChange[10]++;
                    MoneyLeft -= .10;
                }
                else if (MoneyLeft >= .05 && RoundRegister.CashDrawer.Nickels > GiveBackChange[11])
                {
                    GiveBackChange[11]++;
                    MoneyLeft -= .05;
                }
                else if (MoneyLeft >= .01 && RoundRegister.CashDrawer.Pennies > GiveBackChange[12])
                {
                    GiveBackChange[12]++;
                    MoneyLeft -= .01;
                }

                if (MoneyLeft == prevMoney && total != 0 && CustomerGive != 0)
                {
                    MessageBox.Show("Not Enough money in Cash Register to complete Transaction");
                    GiveBackChange = new int[13];
                    MoneyLeft = 0;
                    return;
                }
                MoneyLeft = Math.Round(MoneyLeft, 2);
            } while (MoneyLeft != 0);
        }
    }
}