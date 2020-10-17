/*
 * Author: Caleb Rosebaugh
 * Class name: VokunSalad.cs
 * Purpose: Class used to create VokunSalad object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    public class VokunSalad : Side
    {

        /// <summary>
        /// Gets the price of the Side
        /// </summary>
        public override double Price
        {
            get
            {
                if (Size == Size.Small)
                {
                    return 0.93;
                }
                else if (Size == Size.Medium)
                {
                    return 1.28;
                }
                else
                {
                    return 1.82;
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
                NotifyPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets the calories of the Side
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == Size.Small)
                {
                    return 41;
                }
                else if (Size == Size.Medium)
                {
                    return 52;
                }
                else
                {
                    return 73;
                }
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
        /// gets the special instructions on making the Vokun Salad
        /// </summary>
        public override List<string> SpecialInstructions => new List<string>();

        /// <summary>
        /// overrides default returned string
        /// </summary>
        /// <returns>string "[Size] Vokun Salad"</returns>
        public override string ToString()
        {
            return Size.ToString() + " Vokun Salad";
        }
    }
}
