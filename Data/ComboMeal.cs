/*
 * Author: Caleb Rosebaugh
 * Class: ComboMeal.cs
 * Purpose: Create item for a saled item pack
 */
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;

namespace BleakwindBuffet.Data
{
    public class ComboMeal : IOrderItem, INotifyPropertyChanged
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
        /// initializes comboMeal
        /// </summary>
        public ComboMeal()
        {
            entree.PropertyChanged += eventListener;
            side.PropertyChanged += eventListener;
            drink.PropertyChanged += eventListener;
        }

        /// <summary>
        /// Entree in combo
        /// </summary>
        private Entree entree = new BriarheartBurger();

        /// <summary>
        /// Side in combo
        /// </summary>
        private Side side = new DragonbornWaffleFries();

        /// <summary>
        /// Drink in combo
        /// </summary>
        private Drink drink = new SailorSoda();

        /// <summary>
        /// event listener for Changing names, calories, special instruction, and prices
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void eventListener(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Price")
            {
                NotifyPropertyChanged("Price");
            }
            if (e.PropertyName == "Calories")
            {
                NotifyPropertyChanged("Calories");
            }
            if (e.PropertyName == "SpecialInstructions")
            {
                NotifyPropertyChanged("SpecialInstructions");
            }
            if (e.PropertyName == "Name")
            {
                NotifyPropertyChanged("Name");
            }
        }

        /// <summary>
        /// gets and sets Entree
        /// </summary>
        public Entree Entree
        {
            get
            {
                return entree;
            }
            set
            {
                entree.PropertyChanged -= eventListener;
                entree = value;
                entree.PropertyChanged += eventListener;
                NotifyPropertyChanged("Entree");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
                NotifyPropertyChanged("SpecialInstructions");
                NotifyPropertyChanged("Name");
            }
        }

        /// <summary>
        /// gets and sets Side
        /// </summary>
        public Side Side
        {
            get
            {
                return side;
            }
            set
            {
                side.PropertyChanged -= eventListener;
                side = value;
                side.PropertyChanged += eventListener;
                NotifyPropertyChanged("Entree");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
                NotifyPropertyChanged("SpecialInstructions");
                NotifyPropertyChanged("Name");
            }
        }

        /// <summary>
        /// gets and sets Drink
        /// </summary>
        public Drink Drink
        {
            get
            {
                return drink;
            }
            set
            {
                drink.PropertyChanged -= eventListener;
                drink = value;
                drink.PropertyChanged += eventListener;
                NotifyPropertyChanged("Entree");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
                NotifyPropertyChanged("SpecialInstructions");
                NotifyPropertyChanged("Name");
            }
        }

        /// <summary>
        /// gets the price of the 3 items and gives sale of $1
        /// </summary>
        public double Price
        {
            get
            {
                return entree.Price + side.Price + drink.Price - 1;
            }
        }

        /// <summary>
        /// gets the Calories of the 3 items
        /// </summary>
        public uint Calories
        {
            get
            {
                return entree.Calories + side.Calories + drink.Calories;
            }
        }

        /// <summary>
        /// Gets the special instructions of the 3 items
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                return (entree.SpecialInstructions).Concat((side.SpecialInstructions).Concat((drink.SpecialInstructions))).ToList();
                //List<string> e = new List<string>();
                //e.Add(entree.ToString());
                //List<string> s = new List<string>();
                //s.Add(side.ToString());
                //List<string> d = new List<string>();
                //d.Add(drink.ToString());
                //return e.Concat((entree.SpecialInstructions).Concat(s.Concat((side.SpecialInstructions).Concat(d.Concat((drink.SpecialInstructions)))))).ToList();
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
        /// gives string of 3 entrees seperated by a "enter"
        /// </summary>
        /// <returns>entree side and drink</returns>
        public override string ToString()
        {
            return entree.ToString() + "\n" + side.ToString() + "\n" + drink.ToString();
        }

        /// <summary>
        /// returns nothing
        /// </summary>
        /// <returns>returns ""</returns>
        public string Description
        {
            get
            {
                return "";
            }
        }
    }
}
