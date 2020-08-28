/*
 * Author: Caleb Rosebaugh
 * Class name: VokunSalad.cs
 * Purpose: Class used to create VokunSalad object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;
using Data.Enums;

namespace Data.Entrees
{
    public class VokunSalad
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
                    return 0.93;
                }
                else if (size == Size.Medium)
                {
                    return 1.28;
                }
                else
                {
                    return 1.82;
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
                    return 41;
                }
                else if (size == Size.Medium)
                {
                    return 52;
                }
                else
                {
                    return 73;
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
        /// <returns>string "[Size] Vokun Salad"</returns>
        public override string ToString()
        {
            return ("{0} Vokun Salad", size.ToString()).ToString();
        }
    }
}
