/*
 * Author: Caleb Rosebaugh
 * Class name: PhillyPoacher.cs
 * Purpose: Class used to create PhillyPoacher object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class PhillyPoacher : Entree
    {
        /// <summary>
        /// Gets the price of the Philly cheesesteak sandwich
        /// </summary>
        public override double Price => 7.23;
        /// <summary>
        /// Gets the calories of the Philly cheesesteak sandwich
        /// </summary>
        public override uint Calories => 784;
        /// <summary>
        /// gets the special instructions on making the Philly cheesesteak sandwich
        /// </summary>
        public override List<string> SpecialInstructions
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
        /// if user wants Sirloin
        /// </summary>
        /// <value>Sirloin</value>
        private bool sirloin = true;

        /// <summary>
        /// creates get set of bool of whether you want a Sirloin or not
        /// </summary>
        public bool Sirloin
        {
            get
            {
                return sirloin;
            }
            set
            {
                sirloin = value;
                NotifyPropertyChanged("Sirloin");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Onion
        /// </summary>
        /// <value>Onion</value>
        private bool onion = true;

        /// <summary>
        /// creates get set of bool of whether you want a Onion or not
        /// </summary>
        public bool Onion
        {
            get
            {
                return onion;
            }
            set
            {
                onion = value;
                NotifyPropertyChanged("Onion");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Roll
        /// </summary>
        /// <value>Roll</value>
        private bool roll = true;

        /// <summary>
        /// creates get set of bool of whether you want a Roll or not
        /// </summary>
        public bool Roll
        {
            get
            {
                return roll;
            }
            set
            {
                roll = value;
                NotifyPropertyChanged("Roll");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// return ToString
        /// </summary>
        /// <returns>string "[Size] Aretino Apple Juice"</returns>
        public string Name
        {
            get => ToString();
        }

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
