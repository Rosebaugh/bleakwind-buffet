/*
 * Author: Caleb Rosebaugh
 * Class name: FriedMiraak.cs
 * Purpose: Class used to create FriedMiraak object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    public class FriedMiraak
    {
        /// <summary>
        /// Gets the price of the Side
        /// </summary>
        public double Price
        {
            get
            {
                if (Size == Size.Small)
                {
                    return 1.78;
                }
                else if (Size == Size.Medium)
                {
                    return 2.01;
                }
                else
                {
                    return 2.88;
                }
            }
        }

        /// <summary>
        /// Gets the calories of the Side
        /// </summary>
        public uint Calories
        {
            get
            {
                if (Size == Size.Small)
                {
                    return 151;
                }
                else if (Size == Size.Medium)
                {
                    return 236;
                }
                else
                {
                    return 306;
                }
            }
        }

        /// <summary>
        /// creates get set of enum Size
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// gets the special instructions on making the Fried Miraak
        /// </summary>
        public List<string> SpecialInstructions => new List<string>();

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Fried Miraak"</returns>
        public override string ToString()
        {
            return Size.ToString() + " Fried Miraak";
        }
    }
}
