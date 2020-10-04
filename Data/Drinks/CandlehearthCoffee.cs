/*
 * Author: Caleb Rosebaugh
 * Class name: CandlehearthCoffee.cs
 * Purpose: Class used to create CandlehearthCoffee object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class CandlehearthCoffee : Drink
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
                    return 0.75;
                }
                else if (Size == Size.Medium)
                {
                    return 1.25;
                }
                else
                {
                    return 1.75;
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
                    return 7;
                }
                else if (Size == Size.Medium)
                {
                    return 10;
                }
                else
                {
                    return 20;
                }
            }
        }

        /// <summary>
        /// if user wants ice
        /// </summary>
        /// <value>ice</value>
        private bool ice = false;

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
                if (Ice)
                {
                    specialInstructions.Add("Add ice");
                }
                if (RoomForCream)
                {
                    specialInstructions.Add("Add cream");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// if user wants Cream
        /// </summary>
        /// <value>Cream</value>
        private bool roomForCream = false;

        /// <summary>
        /// creates get set of bool of whether you want a Cream or not
        /// </summary>
        public bool RoomForCream
        {
            get
            {
                return roomForCream;
            }
            set
            {
                roomForCream = value;
                NotifyPropertyChanged("RoomForCream");
            }
        }

        /// <summary>
        /// if user wants Lemon
        /// </summary>
        /// <value>Decaf</value>
        private bool decaf = false;

        /// <summary>
        /// creates get set of bool of whether you want a Decaf or not
        /// </summary>
        public bool Decaf
        {
            get
            {
                return decaf;
            }
            set
            {
                decaf = value;
                NotifyPropertyChanged("Decaf");
            }
        }

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Aretino Apple Juice"</returns>
        public override string ToString()
        {
            if (Decaf)
            {
                return Size.ToString() + " Decaf Candlehearth Coffee";
            }
            else
            {
                return Size.ToString() + " Candlehearth Coffee";
            }
        }
    }
}
