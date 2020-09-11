/*
 * Author: Caleb Rosebaugh
 * Class name: ThugsTBone.cs
 * Purpose: Class used to create ThugsTBone object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class ThugsTBone : Entree
    {
        /// <summary>
        /// Gets the price of the T-Bone
        /// </summary>
        public override double Price => 6.44;
        /// <summary>
        /// Gets the calories of the T-Bone
        /// </summary>
        public override uint Calories => 982;

        /// <summary>
        /// gets the special instructions on making the T-Bone
        /// </summary>
        public override List<string> SpecialInstructions => new List<string>();

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Thugs T-Bone"</returns>
        public override string ToString()
        {
            return "Thugs T-Bone";
        }
    }
}
