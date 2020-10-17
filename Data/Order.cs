/*
 * Author: Caleb Rosebaugh
 * Class: Order.cs
 * Purpose: Create order for New order
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BleakwindBuffet.Data;
using System.Collections.Specialized;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;

namespace BleakwindBuffet.Data
{
    public class Order : ObservableCollection<IOrderItem>
    {

        /// <summary>
        /// total calories of all items
        /// </summary>
        public virtual uint Calories
        {
            get
            {
                uint calories = 0;
                foreach (IOrderItem item in this)
                {
                    calories += item.Calories;
                }
                return calories;
            }
        }

        /// <summary>
        /// subtotal of all items
        /// </summary>
        public virtual string Subtotal
        {
            get
            {
                double subtotal = 0;
                foreach (IOrderItem item in this)
                {
                    subtotal += item.Price;
                }
                return string.Format("{0:N2}", subtotal);
            }
        }

        /// <summary>
        /// taxpercent for all items
        /// </summary>
        protected double taxPercent = 0.12;

        /// <summary>
        /// gets or sets taxPercent
        /// </summary>
        public virtual double TaxPercent
        {
            get
            {
                return taxPercent;
            }
            set
            {
                taxPercent = value;
            }
        }

        /// <summary>
        /// total Tax for all items
        /// </summary>
        public virtual string Tax
        {
            get
            {
                return string.Format("{0:N2}", Math.Round(Convert.ToDouble(Subtotal) * taxPercent, 2));
            }
        }

        /// <summary>
        /// total for all items
        /// </summary>
        public virtual string Total
        {
            get
            {
                return string.Format("{0:N2}", Convert.ToDouble(Subtotal) + Convert.ToDouble(Tax));
            }
        }
    }
}
