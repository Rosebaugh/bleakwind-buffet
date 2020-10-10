using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                entree = value;
                NotifyPropertyChanged("Entree");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
                NotifyPropertyChanged("SpecialInstructions");
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
                side = value;
                NotifyPropertyChanged("Side");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
                NotifyPropertyChanged("SpecialInstructions");
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
                drink = value;
                NotifyPropertyChanged("Drink");
                NotifyPropertyChanged("Price");
                NotifyPropertyChanged("Calories");
                NotifyPropertyChanged("SpecialInstructions");
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
                List<string> e = new List<string>();
                //e.Add(entree.ToString());
                List<string> s = new List<string>();
                //s.Add(side.ToString());
                List<string> d = new List<string>();
                //d.Add(drink.ToString());
                return e.Concat((entree.SpecialInstructions).Concat(s.Concat((side.SpecialInstructions).Concat(d.Concat((drink.SpecialInstructions)))))).ToList();
            }
        }

        /// <summary>
        /// gives string of 3 entrees seperated by a "enter"
        /// </summary>
        /// <returns>entree side and drink</returns>
        public override string ToString()
        {
            return entree.ToString() + "\n" + side.ToString() + "\n" + drink.ToString();
        }
    }
}
