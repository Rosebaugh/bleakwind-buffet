/*
 * Author: Caleb Rosebaugh
 * Class name: ThalmorTriple.cs
 * Purpose: Class used to create ThalmorTriple object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class ThalmorTriple : Entree
    {

        /// <summary>
        /// Gets the price of the burger
        /// </summary>
        public override double Price => 8.32;
        /// <summary>
        /// Gets the calories of the burger
        /// </summary>
        public override uint Calories => 943;
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
                if (!Tomato)
                {
                    specialInstructions.Add("Hold tomato");
                }
                if (!Lettuce)
                {
                    specialInstructions.Add("Hold lettuce");
                }
                if (!Mayo)
                {
                    specialInstructions.Add("Hold mayo");
                }
                if (!Bacon)
                {
                    specialInstructions.Add("Hold bacon");
                }
                if (!Egg)
                {
                    specialInstructions.Add("Hold egg");
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
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Tomato or not
        /// </summary>
        public bool Tomato { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Lettuce or not
        /// </summary>
        public bool Lettuce { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Mayo or not
        /// </summary>
        public bool Mayo { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want a Bacon or not
        /// </summary>
        public bool Bacon { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want an Egg or not
        /// </summary>
        public bool Egg { get; set; } = true;

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Thalmor Triple" </returns>
        public override string ToString()
        {
            return "Thalmor Triple";
        }
    }
}
