/*
 * Author: Caleb Rosebaugh
 * Class name: PhillyPoacher.cs
 * Purpose: Class used to create PhillyPoacher object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entrees
{
    public class PhillyPoacher
    {
        /// <summary>
        /// Gets the price of the Philly cheesesteak sandwich
        /// </summary>
        public static double Price => 7.32;
        /// <summary>
        /// Gets the calories of the Philly cheesesteak sandwich
        /// </summary>
        public static uint Calories => 784;
        /// <summary>
        /// gets the special instructions on making the Philly cheesesteak sandwich
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (!Sirloin)
                {
                    specialInstructions.Add("Hold sirloin");
                }
                if (!Onion)
                {
                    specialInstructions.Add("Hold onions");
                }
                if (!Roll)
                {
                    specialInstructions.Add("Hold roll");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// creates get set of bool of weither you want a Sirloin or not
        /// </summary>
        public bool Sirloin { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Onion or not
        /// </summary>
        public bool Onion { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Roll or not
        /// </summary>
        public bool Roll { get; set; } = true;

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Philly Poacher"</returns>
        public override string ToString()
        {
            return "Philly Poacher";
        }
    }
}
