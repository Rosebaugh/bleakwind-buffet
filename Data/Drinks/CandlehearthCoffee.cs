/*
 * Author: Caleb Rosebaugh
 * Class name: CandlehearthCoffee.cs
 * Purpose: Class used to create CandlehearthCoffee object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class CandlehearthCoffee
    {
        /// <summary>
        /// Gets the price of the Drink
        /// </summary>
        public double Price
        {
            get
            {
                if (size == Size.Small)
                {
                    return 0.75;
                }
                else if (size == Size.Medium)
                {
                    return 1.25;
                }
                else
                {
                    return 1.75;
                }
            }
        }

        /// <summary>
        /// Gets the calories of the Drink
        /// </summary>
        public uint Calories
        {
            get
            {
                if (size == Size.Small)
                {
                    return 7;
                }
                else if (size == Size.Medium)
                {
                    return 10;
                }
                else
                {
                    return 20;
                }
            }
        }

        /// <summary>
        /// creates get set of bool of weither you want a Ice or not
        /// </summary>
        public bool Ice { get; set; } = false;

        /// <summary>
        /// creates get set of enum Size
        /// </summary>
        public Size size { get; set; } = Size.Small;

        /// <summary>
        /// gets the special instructions on making the Drink
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (Ice)
                {
                    specialInstructions.Add("Add ice");
                }
                if (RoomForCream)
                {
                    specialInstructions.Add("Add cream");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// creates get set of bool of weither you want a Cream or not
        /// </summary>
        public bool RoomForCream { get; set; } = false;

        /// <summary>
        /// creates get set of bool of weither you want a Decaf or not
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Aretino Apple Juice"</returns>
        public override string ToString()
        {
            if (Decaf)
            {
                return ("{0} Decaf Candlehearth Coffee", size.ToString()).ToString();
            }
            else
            {
                return ("{0} Candlehearth Coffee", size.ToString()).ToString();
            }
        }
    }
}
