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
                if (size == Size.Small)
                {
                    return 1.78;
                }
                else if (size == Size.Medium)
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
                if (size == Size.Small)
                {
                    return 151;
                }
                else if (size == Size.Medium)
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
        public Size size { get; set; } = Size.Small;

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Fried Miraak"</returns>
        public override string ToString()
        {
            return ("{0} Fried Miraak", size.ToString()).ToString();
        }
    }
}
