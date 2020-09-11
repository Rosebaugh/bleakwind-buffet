/*
 * Author: Caleb Rosebaugh
 * Class: Drink.cs
 * Purpose: Create abstract class for Drinks
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    /// <summary>
    /// A base class representing common properties of drinks
    /// </summary>
    public abstract class Drink : IOrderItem
    {
        /// <summary>
        /// The size of the drink
        /// </summary>
        public virtual Size Size { get; set; } = Size.Small;

        /// <summary>
        /// The price of a drink
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        public abstract double Price { get; }

        /// <summary>
        /// The Calories of the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the drink
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
