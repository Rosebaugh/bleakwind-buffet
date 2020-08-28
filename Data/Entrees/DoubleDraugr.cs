﻿/*
 * Author: Caleb Rosebaugh
 * Class name: DoubleDraugr.cs
 * Purpose: Class used to create DoubleDraugr object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entrees
{
    public class DoubleDraugr
    {

        /// <summary>
        /// Gets the price of the burger
        /// </summary>
        public static double Price => 7.32;
        /// <summary>
        /// Gets the calories of the burger
        /// </summary>
        public static uint Calories => 843;
        /// <summary>
        /// gets the special instructions on making the burger
        /// </summary>
        public List<string> SpecialInstructions
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
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Double Draugr" </returns>
        public override string ToString()
        {
            return "Double Draugr";
        }
    }
}
