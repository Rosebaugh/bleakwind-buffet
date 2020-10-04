/*
 * Author: Caleb Rosebaugh
 * Class: Drink.cs
 * Purpose: Create abstract class for Entrees
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace BleakwindBuffet.Data.Entrees
{
    /// <summary>
    /// A base class representing common properties of Entrees
    /// </summary>
    public abstract class Entree : IOrderItem, INotifyPropertyChanged
    {
        /// <summary>
        /// INotifyPropertyChanged implementation 
        /// </summary>
        /// <event>Property Changed</event>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Property Changed 
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void NotifyPropertyChanged(String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// The price of an Entree
        /// </summary>
        /// <value>
        /// In US Dollars
        /// </value>
        public abstract double Price { get; }

        /// <summary>
        /// The Calories of the Entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// The special instructions to prepare the Entree
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }


    }
}
