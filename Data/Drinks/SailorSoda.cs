/*
 * Author: Caleb Rosebaugh
 * Class name: SailorSoda.cs
 * Purpose: Class used to create SailorSoda object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;
using Data.Enums;

namespace Data.Entrees
{
    public class SailorSoda
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
                    return 1.42;
                }
                else if (size == Size.Medium)
                {
                    return 1.74;
                }
                else
                {
                    return 2.07;
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
                    return 117;
                }
                else if (size == Size.Medium)
                {
                    return 153;
                }
                else
                {
                    return 205;
                }
            }
        }
        /// <summary>
        /// creates get set of bool of weither you want a Ice or not
        /// </summary>
        public bool Ice { get; set; } = true;
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
                    specialInstructions.Add("Hold ice");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// creates get set of enum SodaFlavor
        /// </summary>
        public SodaFlavor Flavor { get; set; } = SodaFlavor.Cherry;
        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] [Flavor] Sailor Soda"</returns>
        public override string ToString()
        {
            return ("{0} {1} Sailor Soda", size.ToString(), Flavor.ToString()).ToString();
        }
    }
}
