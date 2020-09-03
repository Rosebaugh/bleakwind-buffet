/*
 * Author: Caleb Rosebaugh
 * Class name: GardenOrcOmlette.cs
 * Purpose: Class used to create GardenOrcOmlette object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class GardenOrcOmlette
    {
        /// <summary>
        /// Gets the price of the Vegetarian omelette
        /// </summary>
        public static double Price => 4.57;
        /// <summary>
        /// Gets the calories of the Vegetarian omelette
        /// </summary>
        public static uint Calories => 404;
        /// <summary>
        /// gets the special instructions on making the Vegetarian omelette
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (!Broccoli)
                {
                    specialInstructions.Add("Hold broccoli");
                }
                if (!Mushrooms)
                {
                    specialInstructions.Add("Hold mushrooms");
                }
                if (!Tomato)
                {
                    specialInstructions.Add("Hold tomato");
                }
                if (!Cheddar)
                {
                    specialInstructions.Add("Hold cheddar");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// creates get set of bool of weither you want a Broccoli or not
        /// </summary>
        public bool Broccoli { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Mushrooms or not
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Tomato or not
        /// </summary>
        public bool Tomato { get; set; } = true;
        /// <summary>
        /// creates get set of bool of weither you want a Cheddar or not
        /// </summary>
        public bool Cheddar { get; set; } = true;

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Garden Orc Omelette"</returns>
        public override string ToString()
        {
            return "Garden Orc Omelette";
        }
    }
}
