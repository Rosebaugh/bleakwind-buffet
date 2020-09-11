/*
 * Author: Caleb Rosebaugh
 * Class: Drink.cs
 * Purpose: Create interface for entrees drinks and sides to follow
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data
{
    public interface IOrderItem
    {
        /// <summary>
        /// The price of a Item
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        double Price { get; }

        /// <summary>
        /// The Calories of the Item
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the Item
        /// </summary>
        List<string> SpecialInstructions { get; }
    }
}
