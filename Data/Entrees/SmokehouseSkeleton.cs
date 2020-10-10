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
    public class SmokehouseSkeleton : Entree
    {/// <summary>
     /// Gets the price of the breakfast
     /// </summary>
        public override double Price => 5.62;
        /// <summary>
        /// Gets the calories of the breakfast
        /// </summary>
        public override uint Calories => 602;
        /// <summary>
        /// gets the special instructions on making the breakfast
        /// </summary>
        public override List<string> SpecialInstructions
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
        /// if user wants Sausage Link
        /// </summary>
        /// <value>Sausage Link</value>
        private bool sausageLink = true;

        /// <summary>
        /// creates get set of bool of whether you want a Sausage Link or not
        /// </summary>
        public bool SausageLink
        {
            get
            {
                return sausageLink;
            }
            set
            {
                sausageLink = value;
                NotifyPropertyChanged("SausageLink");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Egg
        /// </summary>
        /// <value>Egg</value>
        private bool egg = true;

        /// <summary>
        /// creates get set of bool of whether you want a Egg or not
        /// </summary>
        public bool Egg
        {
            get
            {
                return egg;
            }
            set
            {
                egg = value;
                NotifyPropertyChanged("Egg");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants HashBrowns
        /// </summary>
        /// <value>HashBrowns</value>
        private bool hashBrowns = true;

        /// <summary>
        /// creates get set of bool of whether you want a HashBrowns or not
        /// </summary>
        public bool HashBrowns
        {
            get
            {
                return hashBrowns;
            }
            set
            {
                hashBrowns = value;
                NotifyPropertyChanged("HashBrowns");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Pancake
        /// </summary>
        /// <value>Pancake</value>
        private bool pancake = true;

        /// <summary>
        /// creates get set of bool of whether you want a Pancake or not
        /// </summary>
        public bool Pancake
        {
            get
            {
                return pancake;
            }
            set
            {
                pancake = value;
                NotifyPropertyChanged("Pancake");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

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
