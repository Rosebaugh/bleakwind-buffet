﻿/*
 * Author: Caleb Rosebaugh
 * Class name: ThugsTBone.cs
 * Purpose: Class used to create ThugsTBone object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entrees
{
    public class ThugsTBone
    {
        /// <summary>
        /// Gets the price of the T-Bone
        /// </summary>
        public static double Price => 6.44;
        /// <summary>
        /// Gets the calories of the T-Bone
        /// </summary>
        public static uint Calories => 982;

        /// <summary>
        /// gets the special instructions on making the T-Bone
        /// </summary>
        public List<string> SpecialInstructions => new List<string>();

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
