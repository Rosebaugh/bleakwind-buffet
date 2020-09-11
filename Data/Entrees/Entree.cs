/*
 * Author: Caleb Rosebaugh
 * Class: Drink.cs
 * Purpose: Create abstract class for Entrees
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// A base class representing common properties of Entrees
    /// </summary>
    public abstract class Entree : IOrderItem
    {
        /// <summary>
        /// The price of an Entree
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        public abstract double Price { get; }

        /// <summary>
        /// The Calories of the Entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the Entree
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }


    }
}
