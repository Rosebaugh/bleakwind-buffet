﻿/*
 * Author: Caleb Rosebaugh
 * Class name: DragonbornWaffleFries.cs
 * Purpose: Class used to create DragonbornWaffleFries object
 */
using System;
using System.Collections.Generic;
using System.Text;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data.Sides
{
    public class DragonbornWaffleFries : Side
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
                    return 0.42;
                }
                else if (Size == Size.Medium)
                {
                    return 0.76;
                }
                else
                {
                    return 0.96;
                }
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
                    return 77;
                }
                else if (Size == Size.Medium)
                {
                    return 89;
                }
                else
                {
                    return 100;
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
        /// gets the special instructions on making the Dragonborn Waffle Fries
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
        /// <returns>string "[Size] Aretino Apple Juice"</returns>
        public override string ToString()
        {
            return Size.ToString() + " Dragonborn Waffle Fries";
        }

        /// <summary>
        /// overrides default returned desciption
        /// </summary>
        /// <returns>string "Crispy fried potato waffle fries."</returns>
        public override string Description
        {
            get
            {
                return "Crispy fried potato waffle fries.";
            }
        }
    }
}
