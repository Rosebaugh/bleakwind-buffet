/*
 * Author: Caleb Rosebaugh
 * Class name: GardenOrcOmlette.cs
 * Purpose: Class used to create GardenOrcOmlette object
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace BleakwindBuffet.Data.Entrees
{
    public class GardenOrcOmelette : Entree
    {
        /// <summary>
        /// Gets the price of the Vegetarian omelette
        /// </summary>
        public override double Price => 4.57;
        /// <summary>
        /// Gets the calories of the Vegetarian omelette
        /// </summary>
        public override uint Calories => 404;
        /// <summary>
        /// gets the special instructions on making the Vegetarian omelette
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<String> specialInstructions = new List<string>();
                if (!Broccoli)
                {
                    specialInstructions.Add("Hold broccoli");
                }
                if (!Mushrooms)
                {
                    specialInstructions.Add("Hold mushrooms");
                }
                if (!Tomato)
                {
                    specialInstructions.Add("Hold tomato");
                }
                if (!Cheddar)
                {
                    specialInstructions.Add("Hold cheddar");
                }
                return specialInstructions;
            }
        }

        /// <summary>
        /// if user wants Broccoli
        /// </summary>
        /// <value>Broccoli</value>
        private bool broccoli = true;

        /// <summary>
        /// creates get set of bool of whether you want a Broccoli or not
        /// </summary>
        public bool Broccoli
        {
            get
            {
                return broccoli;
            }
            set
            {
                broccoli = value;
                NotifyPropertyChanged("Broccoli");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Mushrooms
        /// </summary>
        /// <value>Mushrooms</value>
        private bool mushrooms = true;

        /// <summary>
        /// creates get set of bool of whether you want a Mushrooms or not
        /// </summary>
        public bool Mushrooms
        {
            get
            {
                return mushrooms;
            }
            set
            {
                mushrooms = value;
                NotifyPropertyChanged("Mushrooms");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Tomato
        /// </summary>
        /// <value>Tomato</value>
        private bool tomato = true;

        /// <summary>
        /// creates get set of bool of whether you want a Tomato or not
        /// </summary>
        public bool Tomato
        {
            get
            {
                return tomato;
            }
            set
            {
                tomato = value;
                NotifyPropertyChanged("Tomato");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }

        /// <summary>
        /// if user wants Cheddar
        /// </summary>
        /// <value>Cheddar</value>
        private bool cheddar = true;

        /// <summary>
        /// creates get set of bool of whether you want a Cheddar or not
        /// </summary>
        public bool Cheddar
        {
            get
            {
                return cheddar;
            }
            set
            {
                cheddar = value;
                NotifyPropertyChanged("Cheddar");
                NotifyPropertyChanged("SpecialInstructions");
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
        /// overrides default returned string
        /// </summary>
        /// <returns>string "Garden Orc Omelette"</returns>
        public override string ToString()
        {
            return "Garden Orc Omelette";
        }

        /// <summary>
        /// overrides default returned desciption
        /// </summary>
        /// <returns>string "Vegetarian. Two egg omelette packed with a mix of broccoli, mushrooms, and tomatoes. Topped with cheddar cheese."</returns>
        public override string Description
        {
            get
            {
                return "Vegetarian. Two egg omelette packed with a mix of broccoli, mushrooms, and tomatoes. Topped with cheddar cheese.";
            }
        }
    }
}
