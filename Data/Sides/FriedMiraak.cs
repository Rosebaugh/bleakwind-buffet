/*
 * Author: Caleb Rosebaugh
 * Class name: FriedMiraak.cs
 * Purpose: Class used to create FriedMiraak object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    public class FriedMiraak : Side
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
                    return 1.78;
                }
                else if (Size == Size.Medium)
                {
                    return 2.01;
                }
                else
                {
                    return 2.88;
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
                    return 151;
                }
                else if (Size == Size.Medium)
                {
                    return 236;
                }
                else
                {
                    return 306;
                }
            }
        }

        /// <summary>
        /// gets the special instructions on making the Fried Miraak
        /// </summary>
        public override List<string> SpecialInstructions => new List<string>();

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
        /// <returns>string "[Size] Fried Miraak"</returns>
        public override string ToString()
        {
            return Size.ToString() + " Fried Miraak";
        }
    }
}
