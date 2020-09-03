/*
 * Author: Caleb Rosebaugh
 * Class name: WarriorWater.cs
 * Purpose: Class used to create WarriorWater object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class WarriorWater
    {
        /// <summary>
        /// Gets the price of the Drink
        /// </summary>
        public double Price = 0.00;

        /// <summary>
        /// Gets the calories of the Drink
        /// </summary>
        public uint Calories = 0;

        /// <summary>
        /// creates get set of bool of weither you want a Ice or not
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// creates get set of enum Size
        /// </summary>
        public Size Size { get; set; } = Size.Small;

        /// <summary>
        /// gets the special instructions on making the Drink
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (!Ice)
                {
                    specialInstructions.Add("hold ice");
                }
                if (Lemon)
                {
                    specialInstructions.Add("Add lemon");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// creates get set of bool of weither you want a Lemon or not
        /// </summary>
        public bool Lemon { get; set; } = false;

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Warrior Water"</returns>
        public override string ToString()
        {
            return Size.ToString() + " Warrior Water";
        }
    }
}
