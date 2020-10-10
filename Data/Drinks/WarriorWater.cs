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
        /// size of drink
        /// </summary>
        /// <value>size</value>
        private Size size = Size.Small;

        /// <summary>
        /// Gets the price of the Drink
        /// </summary>
        public override Size Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                NotifyPropertyChanged("Size");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
            }
        }

        /// <summary>
        /// if user wants ice
        /// </summary>
        /// <value>ice</value>
        private bool ice = true;

        /// <summary>
        /// creates get set of bool of whether you want a Ice or not
        /// </summary>
        public bool Ice
        {
            get
            {
                return ice;
            }
            set
            {
                ice = value;
                NotifyPropertyChanged("Ice");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

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
        /// if user wants Lemon
        /// </summary>
        /// <value>Lemon</value>
        private bool lemon = false;

        /// <summary>
        /// creates get set of bool of whether you want a Lemon or not
        /// </summary>
        public bool Lemon
        {
            get
            {
                return lemon;
            }
            set
            {
                lemon = value;
                NotifyPropertyChanged("Lemon");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

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
