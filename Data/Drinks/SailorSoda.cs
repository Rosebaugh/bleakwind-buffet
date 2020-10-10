/*
 * Author: Caleb Rosebaugh
 * Class name: SailorSoda.cs
 * Purpose: Class used to create SailorSoda object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class SailorSoda : Drink
    {
        /// <summary>
        /// Gets the price of the Drink
        /// </summary>
        public override double Price
        {
            get
            {
                if (Size == Size.Small)
                {
                    return 1.42;
                }
                else if (Size == Size.Medium)
                {
                    return 1.74;
                }
                else
                {
                    return 2.07;
                }
            }
        }

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
        /// Gets the calories of the Drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small)
                {
                    return 117;
                }
                else if (Size == Size.Medium)
                {
                    return 153;
                }
                else
                {
                    return 205;
                }
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
                return specialInstructions;
            }
        }

        /// <summary>
        /// what Flavor
        /// </summary>
        /// <value>Flavor</value>
        private SodaFlavor flavor = SodaFlavor.Cherry;

        /// <summary>
        /// creates get set enum of what Flavor is wanted
        /// </summary>
        public SodaFlavor Flavor
        {
            get
            {
                return flavor;
            }
            set
            {
                flavor = value;
                NotifyPropertyChanged("Flavor");
            }
        }

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] [Flavor] Sailor Soda"</returns>
        public override string ToString()
        {
            return Size.ToString() + " " + Flavor.ToString() + " Sailor Soda";
        }
    }
}
