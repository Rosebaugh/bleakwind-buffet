/*
 * Author: Caleb Rosebaugh
 * Class name: SmokehouseSkeleton.cs
 * Purpose: Class used to create SmokehouseSkeleton object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class SmokehouseSkeleton
    {/// <summary>
     /// Gets the price of the breakfast
     /// </summary>
        public double Price => 5.62;
        /// <summary>
        /// Gets the calories of the breakfast
        /// </summary>
        public uint Calories => 602;
        /// <summary>
        /// gets the special instructions on making the breakfast
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (!SausageLink)
                {
                    specialInstructions.Add("Hold sausage");
                }
                if (!Egg)
                {
                    specialInstructions.Add("Hold eggs");
                }
                if (!HashBrowns)
                {
                    specialInstructions.Add("Hold hash browns");
                }
                if (!Pancake)
                {
                    specialInstructions.Add("Hold pancakes");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// creates get set of bool of weither you want a Sausage Link or not
        /// </summary>
        public bool SausageLink { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want an Egg or not
        /// </summary>
        public bool Egg { get; set; } = true;

        /// <summary>
        /// creates get set of bool of weither you want HashBrowns or not
        /// </summary>
        public bool HashBrowns { get; set; } = true;
        /// <summary>
        /// creates get set of bool of weither you want a Pancake or not
        /// </summary>
        public bool Pancake { get; set; } = true;

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Smokehouse Skeleton" </returns>
        public override string ToString()
        {
            return "Smokehouse Skeleton";
        }
    }
}
