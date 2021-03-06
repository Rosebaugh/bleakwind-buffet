﻿/*
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
        /// if user wants bun
        /// </summary>
        /// <value>Bun</value>
        private bool bun = true;

        /// <summary>
        /// creates get set of bool of whether you want a Ice or not
        /// </summary>
        public bool Bun
        {
            get
            {
                return bun;
            }
            set
            {
                bun = value;
                NotifyPropertyChanged("Bun");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Ketchup
        /// </summary>
        /// <value>Ketchup</value>
        private bool ketchup = true;

        /// <summary>
        /// creates get set of bool of whether you want a Ketchup or not
        /// </summary>
        public bool Ketchup
        {
            get
            {
                return ketchup;
            }
            set
            {
                ketchup = value;
                NotifyPropertyChanged("Ketchup");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Mustard
        /// </summary>
        /// <value>Mustard</value>
        private bool mustard = true;

        /// <summary>
        /// creates get set of bool of whether you want a Mustard or not
        /// </summary>
        public bool Mustard
        {
            get
            {
                return mustard;
            }
            set
            {
                mustard = value;
                NotifyPropertyChanged("Mustard");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Pickle
        /// </summary>
        /// <value>Pickle</value>
        private bool pickle = true;

        /// <summary>
        /// creates get set of bool of whether you want a Pickle or not
        /// </summary>
        public bool Pickle
        {
            get
            {
                return pickle;
            }
            set
            {
                pickle = value;
                NotifyPropertyChanged("Pickle");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Cheese
        /// </summary>
        /// <value>Cheese</value>
        private bool cheese = true;

        /// <summary>
        /// creates get set of bool of whether you want a Cheese or not
        /// </summary>
        public bool Cheese
        {
            get
            {
                return cheese;
            }
            set
            {
                cheese = value;
                NotifyPropertyChanged("Cheese");
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
        /// <returns>string "Briarheart Burger"</returns>
        public override string ToString()
        {
            return "Briarheart Burger";
        }

        /// <summary>
        /// overrides default returned desciption
        /// </summary>
        /// <returns>string "Single patty burger on a brioche bun. Comes with ketchup, mustard, pickle, and cheese."</returns>
        public override string Description
        {
            get
            {
                return "Single patty burger on a brioche bun. Comes with ketchup, mustard, pickle, and cheese.";
            }
        }
    }
}
