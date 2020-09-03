/*
 * Author: Caleb Rosebaugh
 * Class name: AretineAppleJuice.cs
 * Purpose: Class used to create AretineAppleJuice object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Entrees
{
    public class AretineAppleJuice
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
                    return 0.62;
                }
                else if (size == Size.Medium)
                {
                    return 0.87;
                }
                else
                {
                    return 1.01;
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
                    return 44;
                }
                else if (size == Size.Medium)
                {
                    return 88;
                }
                else
                {
                    return 132;
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
                return specialInstructions;
            }
        }

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Aretino Apple Juice"</returns>
        public override string ToString()
        {
            return ("{0} Aretino Apple Juice", size.ToString()).ToString();
        }
    }
}
