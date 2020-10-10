/*
 * Author: Caleb Rosebaugh
 * Class name: AretineAppleJuice.cs
 * Purpose: Class used to create AretineAppleJuice object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Drinks
{
    public class AretinoAppleJuice : Drink
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
                    return 0.62;
                }
                else if (Size == Size.Medium)
                {
                    return 0.87;
                }
                else
                {
                    return 1.01;
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
                    return 44;
                }
                else if (Size == Size.Medium)
                {
                    return 88;
                }
                else
                {
                    return 132;
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
        public bool Ice {
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
                if (Ice)
                {
                    specialInstructions.Add("Add ice");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Aretino Apple Juice"</returns>
        public override string ToString()
        {
            return Size.ToString() + " Aretino Apple Juice";
        }
    }
}
