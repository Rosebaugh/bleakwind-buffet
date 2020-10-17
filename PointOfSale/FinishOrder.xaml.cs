/*
 * Author: Caleb Rosebaugh
 * Class name: FinishOrder.xaml.cs
 * Purpose: Class used to create WPF user control.
 */
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using RoundRegister;
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
    /// Interaction logic for FinishOrder.xaml
    /// </summary>
    public partial class FinishOrder : UserControl
    {
        /// <summary>
        /// Holds reference to MainWindow.xaml
        /// </summary>
        public MainWindow Win { get; set; }

        /// <summary>
        /// Holds reference for CurrencyCreen.xaml
        /// </summary>
        public CurrencyScreen temp { get; set; }

        /// <summary>
        /// Holds Order
        /// </summary>

        public Order price;

        /// <summary>
        /// initializes class
        /// </summary>
        public FinishOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Credit/Debit click event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Event args</param>
        public void CashClick(object sender, EventArgs e)
        {
            Win.containerBorder.Child = null;
            temp = new CurrencyScreen();
            temp.Win = Win;
            temp.order = price;
            Win.ChangeLayerIndex(1);
            Win.containerBorder.Child = temp; 
        }
        /// <summary>
        /// Handles Credit/Debit click event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">Event args</param>
        public void CreditDebitClick(object sender, EventArgs e)
        {
            CardTransactionResult k = CardReader.RunCard(Convert.ToDouble(price.Total));
            switch (k)
            {
                case CardTransactionResult.Approved:
                    PrintOrder("Card", price.Total, price.Total);
                    Win.NewOrder();
                    break;
                case CardTransactionResult.Declined:
                    MessageBox.Show("Card was declined. Please try new card");
                    break;
                case CardTransactionResult.ReadError:
                    MessageBox.Show("Error reading card. Please try again");
                    break;
                case CardTransactionResult.InsufficientFunds:
                    MessageBox.Show("Card Has insufficient Funds");
                    break;
                case CardTransactionResult.IncorrectPin:
                    MessageBox.Show("Transaction Failed. Incorrect pin");
                    break;
            }
        }

        /// <summary>
        /// Creates Printable Order reciebt
        /// </summary>
        public void PrintOrder(string method, string payment, string change)
        {
            List<string> printable = new List<string>();

            string topline = "Bleakwind Buffet";
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)) + topline + String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)));
            topline = "Phone Number: 785-123-4567";
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)) + topline + String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)));
            topline = "12345 Food Drive";
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)) + topline + String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)));
            topline = "Manhattan, KS";
            printable.Add(String.Join("", Enumerable.Repeat(" ", ((40 - topline.Length) / 2) + 1)) + topline + String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)));
            printable.Add(String.Join("", Enumerable.Repeat(" ", 40)));
            topline = "Order #" + price.OrderNumber;
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)) + topline + String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)));
            printable.Add(String.Join("", Enumerable.Repeat(" ", 40)));
            printable.Add(String.Join("", Enumerable.Repeat("-", 40)));

            foreach (IOrderItem k in price)
            {
                string priceLine = " | $" + Math.Round(k.Price, 2);
                string blankLine = " |  " + String.Join("", Enumerable.Repeat(" ", Math.Round(k.Price, 2).ToString().Length));
                int wordCount = 40 - priceLine.Length;
                int WordsInLine = 0;
                bool firstLine = true;
                string curLine = "";
                string[] words = k.ToString().Replace("\n", " ").Split(' ');

                if (k is ComboMeal comb)
                {
                    string phrase = "Combo Meal:";
                    printable.Add(phrase + String.Join("", Enumerable.Repeat(" ", (40 - phrase.Length - priceLine.Length))) + priceLine);
                    IOrderItem curItem = comb.Entree;
                    for (int i = 0; i < 3; i++)
                    {
                        words = curItem.ToString().Replace("\n", " ").Split(' ');
                        curLine = "";
                        firstLine = false;
                        WordsInLine = 0;
                        wordCount = 40 - blankLine.Length;

                        foreach (string word in words)
                        {
                            if (word.Length > wordCount && WordsInLine == 0) // if line wanted to print is too long to be printed in one line
                            {
                                printable.Add(word.Substring(0, wordCount) + blankLine);
                                string unUsed = word.Substring(wordCount);
                                bool toolong = true;
                                while (toolong)
                                {
                                    if (unUsed.Length > wordCount)
                                    {
                                        printable.Add(word.Substring(0, wordCount) + blankLine);
                                        unUsed = word.Substring(wordCount);
                                    }
                                    else
                                    {
                                        printable.Add(word.Substring(0, wordCount) + blankLine);
                                        toolong = false;
                                    }
                                }
                            } // if line wanted to print is too long to be printed in one line
                            else if (word.Length > wordCount && word.Length > (40 - blankLine.Length))// if line wanted to add new word but the word is too long for one line
                            {
                                printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                                wordCount = 40 - blankLine.Length;
                                curLine = "";
                                WordsInLine = 0;

                                printable.Add(word.Substring(0, wordCount) + blankLine);
                                string unUsed = word.Substring(wordCount);
                                bool toolong = true;
                                while (toolong)
                                {
                                    if (unUsed.Length > wordCount)
                                    {
                                        printable.Add(word.Substring(0, wordCount) + blankLine);
                                        unUsed = word.Substring(wordCount);
                                    }
                                    else
                                    {
                                        wordCount -= word.Length;
                                        printable.Add(word.Substring(0, wordCount) + Enumerable.Repeat(" ", wordCount) + blankLine);
                                        toolong = false;
                                    }
                                }
                                wordCount = 40 - blankLine.Length;

                            }// if line wanted to add new word but the word is too long for one line
                            else if (word.Length > (wordCount - 1))
                            {
                                printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                                curLine = word;
                                wordCount = 40 - blankLine.Length - word.Length;
                                WordsInLine = 1;
                            }
                            else if (word.Length == (wordCount - 1))
                            {
                                printable.Add(curLine + " " + word + blankLine);
                                curLine = "";
                                wordCount = 40 - blankLine.Length;
                                WordsInLine = 0;
                            }
                            else
                            {
                                curLine += " " + word;
                                wordCount -= (word.Length + 1);
                                WordsInLine += 1;
                            }
                        }
                        if (curLine.Length != 0)
                        {
                            printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                        }
                        string startLine = "\t-";
                        wordCount = 40 - blankLine.Length - startLine.Length;
                        foreach (string instruction in curItem.SpecialInstructions)
                        {
                            if (instruction.Length > wordCount)
                            {
                                printable.Add(startLine + instruction.Substring(0, wordCount) + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                                wordCount = 40 - blankLine.Length - startLine.Length;
                            }
                            else
                            {
                                wordCount -= instruction.Length;
                                printable.Add(startLine + instruction + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                                wordCount = 40 - blankLine.Length - startLine.Length;
                            }
                        }
                        if (i == 0) curItem = comb.Side;
                        else if (i == 1) curItem = comb.Drink;
                    }
                }
                else
                {

                    foreach (string word in words)
                    {
                        if (word.Length > wordCount && WordsInLine == 0) // if line wanted to print is too long to be printed in one line
                        {
                            if (firstLine)
                            {
                                printable.Add(word.Substring(0, wordCount) + priceLine);
                                string unUsed = word.Substring(wordCount);
                                firstLine = false;
                                bool toolong = true;
                                while (toolong)
                                {
                                    if (unUsed.Length > wordCount)
                                    {
                                        printable.Add(word.Substring(0, wordCount) + blankLine);
                                        unUsed = word.Substring(wordCount);
                                    }
                                    else
                                    {
                                        wordCount -= word.Length;
                                        printable.Add(word.Substring(0, wordCount) + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                                        toolong = false;
                                    }
                                }
                                wordCount = 40 - blankLine.Length;
                            }
                            else
                            {
                                printable.Add(word.Substring(0, wordCount) + blankLine);
                                string unUsed = word.Substring(wordCount);
                                firstLine = false;
                                bool toolong = true;
                                while (toolong)
                                {
                                    if (unUsed.Length > wordCount)
                                    {
                                        printable.Add(word.Substring(0, wordCount) + blankLine);
                                        unUsed = word.Substring(wordCount);
                                    }
                                    else
                                    {
                                        printable.Add(word.Substring(0, wordCount) + blankLine);
                                        toolong = false;
                                    }
                                }
                            }
                        } // if line wanted to print is too long to be printed in one line
                        else if (word.Length > wordCount && word.Length > (40 - priceLine.Length))// if line wanted to add new word but the word is too long for one line
                        {
                            if (firstLine)
                            {
                                printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + priceLine);
                                firstLine = false;
                            }
                            else
                            {
                                printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                            }
                            wordCount = 40 - blankLine.Length;
                            curLine = "";
                            WordsInLine = 0;

                            printable.Add(word.Substring(0, wordCount) + blankLine);
                            string unUsed = word.Substring(wordCount);
                            firstLine = false;
                            bool toolong = true;
                            while (toolong)
                            {
                                if (unUsed.Length > wordCount)
                                {
                                    printable.Add(word.Substring(0, wordCount) + blankLine);
                                    unUsed = word.Substring(wordCount);
                                }
                                else
                                {
                                    wordCount -= word.Length;
                                    printable.Add(word.Substring(0, wordCount) + Enumerable.Repeat(" ", wordCount) + blankLine);
                                    toolong = false;
                                }
                            }
                            wordCount = 40 - blankLine.Length;

                        }// if line wanted to add new word but the word is too long for one line
                        else if (word.Length > (wordCount - 1))
                        {
                            if (firstLine)
                            {
                                printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + priceLine);
                                firstLine = false;
                            }
                            else
                            {
                                printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                            }
                            curLine = word;
                            wordCount = 40 - blankLine.Length - word.Length;
                            WordsInLine = 1;
                        }
                        else if (word.Length == (wordCount - 1))
                        {
                            if (firstLine)
                            {
                                printable.Add(curLine + " " + word + priceLine);
                                firstLine = false;
                            }
                            else
                            {
                                printable.Add(curLine + " " + word + blankLine);
                            }
                            curLine = "";
                            wordCount = 40 - blankLine.Length;
                            WordsInLine = 0;
                        }
                        else
                        {
                            curLine += " " + word;
                            wordCount -= (word.Length + 1);
                            WordsInLine += 1;
                        }
                    }
                    if (curLine.Length != 0)
                    {
                        if (firstLine == true) printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + priceLine);
                        else printable.Add(curLine + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                    }
                    string startLine = "\t-";
                    wordCount = 40 - blankLine.Length - startLine.Length;
                    foreach (string instruction in k.SpecialInstructions)
                    {
                        if (instruction.Length > wordCount)
                        {
                            printable.Add(startLine + instruction.Substring(0, wordCount) + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                            wordCount = 40 - blankLine.Length - startLine.Length;
                        }
                        else
                        {
                            wordCount -= instruction.Length;
                            printable.Add(startLine + instruction + String.Join("", Enumerable.Repeat(" ", wordCount)) + blankLine);
                            wordCount = 40 - blankLine.Length - startLine.Length;
                        }
                    }
                }
                printable.Add(String.Join("", Enumerable.Repeat("-", 40)));
            }


            topline = "SubTotal: " + price.Subtotal;
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length))) + topline);
            topline = "Tax: " + price.Tax;
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length))) + topline);
            topline = "Total: " + price.Total;
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length))) + topline);
            printable.Add(String.Join("", Enumerable.Repeat(" ", 40)));
            topline = "Payment Method: " + method;
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)) + topline + String.Join("", Enumerable.Repeat(" ", (40 - topline.Length) / 2)));
            topline = "Amount Paid: " + payment;
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length))) + topline);
            topline = "Change Given: " + change;
            printable.Add(String.Join("", Enumerable.Repeat(" ", (40 - topline.Length))) + topline);


            /*
            string printing = "";
            foreach (string r in printable)
            {
                printing += r + r.Length.ToString() + "\n";
            }
            MessageBox.Show(printing);
            /*/
            foreach(string r in printable)
            {
                RecieptPrinter.PrintLine(r);
            }
            RecieptPrinter.CutTape();
            //*/
        }
    }
}
