/*
 * Author: Caleb Rosebaugh
 * Class name: BriarheartBurger.cs
 * Purpose: Class used to create BriarheartBurger object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class BriarheartBurger : Entree
    {
        /// <summary>
        /// Gets the price of the burger
        /// </summary>
        public override double Price => 6.32;

        /// <summary>
        /// Gets the calories of the burger
        /// </summary>
        public override uint Calories => 743;

        /// <summary>
        /// gets the special instructions on making the burger
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (!Bun)
                {
                    specialInstructions.Add("Hold bun");
                }
                if (!Ketchup)
                {
                    specialInstructions.Add("Hold ketchup");
                }
                if (!Mustard)
                {
                    specialInstructions.Add("Hold mustard");
                }
                if (!Pickle)
                {
                    specialInstructions.Add("Hold pickle");
                }
                if (!Cheese)
                {
                    specialInstructions.Add("Hold cheese");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// creates get set of bool of weither you want a bun or not
        /// </summary>
        public bool Bun { get; set; } = true;
        /// <summary>
        /// creates get set of bool of weither you want a Ketchup or not
        /// </summary>
        public bool Ketchup { get; set; } = true;
        /// <summary>
        /// creates get set of bool of weither you want a Mustard or not
        /// </summary>
        public bool Mustard { get; set; } = true;
        /// <summary>
        /// creates get set of bool of weither you want a Pickle or not
        /// </summary>
        public bool Pickle { get; set; } = true;
        /// <summary>
        /// creates get set of bool of weither you want a Cheese or not
        /// </summary>
        private bool Cheese { get; set; } = true;
        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Briarheart Burger"</returns>
        public override string ToString()
        {
            return "Briarheart Burger";
        }

    }
}
