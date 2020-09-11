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
    public class WarriorWater : Drink
    {
        /// <summary>
        /// Gets the price of the Drink
        /// </summary>
        public override double Price => 0.00;

        /// <summary>
        /// Gets the calories of the Drink
        /// </summary>
        public override uint Calories => 0;

        /// <summary>
        /// creates get set of bool of weither you want a Ice or not
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// gets the special instructions on making the Drink
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (!Ice)
                {
                    specialInstructions.Add("Hold ice");
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
