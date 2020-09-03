/*
 * Author: Caleb Rosebaugh
 * Class name: MadOtarGrits.cs
 * Purpose: Class used to create MadOtarGrits object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    public class MadOtarGrits
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
                    return 1.22;
                }
                else if (size == Size.Medium)
                {
                    return 1.58;
                }
                else
                {
                    return 1.93;
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
                    return 105;
                }
                else if (size == Size.Medium)
                {
                    return 142;
                }
                else
                {
                    return 179;
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
        /// <returns>string "[Size] Mad Otar Grits"</returns>
        public override string ToString()
        {
            return ("{0} Mad Otar Grits", size.ToString()).ToString();
        }
    }
}
