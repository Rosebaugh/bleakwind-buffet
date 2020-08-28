/*
 * Author: Caleb Rosebaugh
 * Class name: DragonbornWaffleFries.cs
 * Purpose: Class used to create DragonbornWaffleFries object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;
using Data.Enums;

namespace Data.Entrees
{
    public class DragonbornWaffleFries
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
                    return 0.42;
                }
                else if (size == Size.Medium)
                {
                    return 0.76;
                }
                else
                {
                    return 0.96;
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
                    return 77;
                }
                else if (size == Size.Medium)
                {
                    return 89;
                }
                else
                {
                    return 100;
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
        /// <returns>string "[Size] Aretino Apple Juice"</returns>
        public override string ToString()
        {
            return ("{0} Dragonborn Waffle Fries", size.ToString()).ToString();
        }
    }
}
