using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BleakwindBuffet.Data;
using System.Collections.Specialized;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;

namespace PointOfSale
{
    public class Order : ObservableCollection<IOrderItem>
    {

        /// <summary>
        /// Adds event listen at start
        /// </summary>
        public Order()
        {
            CollectionChanged += CollectionChangedListener;
        }

        /// <summary>
        /// total calories of all items
        /// </summary>
        public uint Calories
        {
            get
            {
                uint calories = 0;
                foreach (IOrderItem item in this)
                {
                    calories += item.Calories;
                }
                return calories;
            }
        }

        /// <summary>
        /// subtotal of all items
        /// </summary>
        public string Subtotal
        {
            get
            {
                double subtotal = 0;
                foreach (IOrderItem item in this)
                {
                    subtotal += item.Price;
                }
                return string.Format("{0:N2}", subtotal);
            }
        }

        /// <summary>
        /// taxpercent for all items
        /// </summary>
        private double taxPercent = 0.12;

        /// <summary>
        /// gets or sets taxPercent
        /// </summary>
        public double TaxPercent
        {
            get
            {
                return taxPercent;
            }
            set
            {
                taxPercent = value;
            }
        }

        /// <summary>
        /// total Tax for all items
        /// </summary>
        public string Tax
        {
            get
            {
                return string.Format("{0:N2}", Math.Round(Convert.ToDouble(Subtotal) * taxPercent, 2));
            }
        }

        /// <summary>
        /// total for all items
        /// </summary>
        public string Total
        {
            get
            {
                return string.Format("{0:N2}", Convert.ToDouble(Subtotal) + Convert.ToDouble(Tax));
            }
        }

        /// <summary>
        /// list of prices for all items (used earlier but removed recently. might make a comback)
        /// </summary>
        public ObservableCollection<string> Prices
        {
            get
            {
                ObservableCollection<string> price = new ObservableCollection<string>();
                foreach (IOrderItem item in this)
                {
                    if(item is ComboMeal)
                    {
                        price.Add("\n$" + item.Price + "\n");
                    }
                    else
                    {
                        price.Add("$" + item.Price);
                    }
                }
                return price;
            }
        }

        /// <summary>
        /// Adds and removes listener events when items are added to Order
        /// Notifies that properties changed
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">arg</param>
        void CollectionChangedListener(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs("Subtotal"));
            OnPropertyChanged(new PropertyChangedEventArgs("Tax"));
            OnPropertyChanged(new PropertyChangedEventArgs("Total"));
            OnPropertyChanged(new PropertyChangedEventArgs("Calories"));
            OnPropertyChanged(new PropertyChangedEventArgs("Prices"));
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (IOrderItem item in e.NewItems)
                    {
                        if (item is Entree) ((Entree)item).PropertyChanged += CollectionItemChangedListener;
                        if (item is Side) ((Side)item).PropertyChanged += CollectionItemChangedListener;
                        if (item is Drink) ((Drink)item).PropertyChanged += CollectionItemChangedListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (IOrderItem item in e.OldItems)
                    {
                        if (item is Entree) ((Entree)item).PropertyChanged -= CollectionItemChangedListener;
                        if (item is Side) ((Side)item).PropertyChanged -= CollectionItemChangedListener;
                        if (item is Drink) ((Drink)item).PropertyChanged -= CollectionItemChangedListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    throw new NotImplementedException("NotifyCollectionChangedAction.Reset not supported");
            }
        }

        /// <summary>
        /// Notifies that properties changed
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">arg</param>
        void CollectionItemChangedListener(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Price")
            {
                OnPropertyChanged(new PropertyChangedEventArgs("Subtotal"));
                OnPropertyChanged(new PropertyChangedEventArgs("Tax"));
                OnPropertyChanged(new PropertyChangedEventArgs("Total"));
                OnPropertyChanged(new PropertyChangedEventArgs("Calories"));
                OnPropertyChanged(new PropertyChangedEventArgs("Prices"));
            }
        }
    }
}
