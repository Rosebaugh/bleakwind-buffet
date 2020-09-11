/*
 * Author: Caleb Rosebaugh
 * Class: Drink.cs
 * Purpose: Create abstract class for Sides
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{

    /// <summary>
    /// A base class representing common properties of Sides
    /// </summary>
    public abstract class Side : IOrderItem
    {
        /// <summary>
        /// The size of the Side
        /// </summary>
        public virtual Size Size { get; set; } = Size.Small;

        /// <summary>
        /// The price of a Side
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        public abstract double Price { get; }

        /// <summary>
        /// The Calories of the Side
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the Side
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
