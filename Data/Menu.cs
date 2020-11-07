/*
 * Author: Caleb Rosebaugh
 * Class: Menu.cs
 * Purpose: Create Menu for entree, side, and drink
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Enums;

namespace BleakwindBuffet.Data
{
    public static class Menu
    {
        /// <summary>
        /// Returns all Entrees, Drinks, and sides
        /// </summary>
        /// <returns>list entree, sides then drink in a list</returns>
        public static IEnumerable<IOrderItem> FullMenu()
        {
            return Entrees().Concat(Sides().Concat(Drinks())).ToList();
        }

        /// <summary>
        /// Makes instances of all entrees, and puts into a list
        /// </summary>
        /// <returns>list of all entree</returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            List<IOrderItem> entrees = new List<IOrderItem>();
            entrees.Add(new BriarheartBurger());
            entrees.Add(new DoubleDraugr());
            entrees.Add(new GardenOrcOmelette());
            entrees.Add(new PhillyPoacher());
            entrees.Add(new SmokehouseSkeleton());
            entrees.Add(new ThalmorTriple());
            entrees.Add(new ThugsTBone());
            return entrees;
        }

        /// <summary>
        /// Makes instances of all Sides, and puts into a list
        /// </summary>
        /// <returns>list of all Sides</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            List<IOrderItem> sides = new List<IOrderItem>();
            for(int i = 0; i < 4; i++)
            {
                foreach(Size s in Enum.GetValues(typeof(Size)))
                {
                    switch (i)
                    {
                        case 0:
                            sides.Add(new DragonbornWaffleFries()
                            {
                                Size = s
                            });
                            break;
                        case 1:
                            sides.Add(new FriedMiraak()
                            {
                                Size = s
                            });
                            break;
                        case 2:
                            sides.Add(new MadOtarGrits()
                            {
                                Size = s
                            });
                            break;
                        case 3:
                            sides.Add(new VokunSalad()
                            {
                                Size = s
                            });
                            break;
                    }
                }

            }
            return sides;

        }

        /// <summary>
        /// Makes instances of all Drinks, and puts into a list
        /// </summary>
        /// <returns>list of all Drinks</returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            int k = 0;
            int j = 5;
            SodaFlavor last = Enum.GetValues(typeof(SodaFlavor)).Cast<SodaFlavor>().Max();
            foreach (SodaFlavor f in Enum.GetValues(typeof(SodaFlavor)))
            {
                if (f == last)
                {
                    k = 4;
                    j = 6;
                }
                for (int i = k; i < j; i++)
                {
                    foreach (Size s in Enum.GetValues(typeof(Size)))
                    {
                        switch (i)
                        {
                            case 0:
                                drinks.Add(new AretinoAppleJuice()
                                {
                                    Size = s
                                });
                                break;
                            case 1:
                                drinks.Add(new CandlehearthCoffee()
                                {
                                    Size = s,
                                    Decaf = false
                                });
                                break;
                            case 2:
                                drinks.Add(new CandlehearthCoffee()
                                {
                                    Size = s,
                                    Decaf = true
                                });
                                break;
                            case 3:
                                drinks.Add(new MarkarthMilk()
                                {
                                    Size = s
                                });
                                break;
                            case 4:
                                drinks.Add(new SailorSoda()
                                {
                                    Size = s,
                                    Flavor = f
                                });
                                break;
                            case 5:
                                drinks.Add(new WarriorWater()
                                {
                                    Size = s
                                });
                            break;
                        }
                    }
                }
                k = 4;
                j = 5;
            }
            return drinks;
        }

        /// <summary>
        /// Searches list for IOrderItems that include the Phase as its ToString()
        /// </summary>
        /// <param name="List">List Of IOrderItems</param>
        /// <param name="phrase">Phrase to search for</param>
        /// <returns>List of IOrderItems that contain the phrase</returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> List, string phrase)
        {
            if (phrase == null) return List;

            List<IOrderItem> menu = new List<IOrderItem>();
            foreach (IOrderItem item in List)
            {
                if (item.ToString().Contains(phrase))
                {
                    menu.Add(item);
                }
            }
            return menu;
        }

        /// <summary>
        /// Searches list for IOrderItems that include one of the Categories
        /// </summary>
        /// <param name="List">List Of IOrderItems</param>
        /// <param name="Categories">List Of Categories</param>
        /// <returns>List of IOrderItems that contain a Categorie</returns>
        public static IEnumerable<IOrderItem> FilterByCategory(IEnumerable<IOrderItem> List, IEnumerable<string> Categories)
        {
            if (Categories.Count() == 0) return List;

            List<IOrderItem> menu = new List<IOrderItem>();
            foreach (IOrderItem item in List)
            {
                if (Categories.Contains("Entree"))
                {
                    if (item is Entree)
                    {
                        menu.Add(item);
                    }
                }
                if (Categories.Contains("Side"))
                {
                    if (item is Side)
                    {
                        menu.Add(item);
                    }
                }
                if (Categories.Contains("Drink"))
                {
                    if (item is Drink)
                    {
                        menu.Add(item);
                    }
                }
            }
            return menu;
        }

        /// <summary>
        /// Searches list for IOrderItems that Calories falls between min and max
        /// </summary>
        /// <param name="List">List Of IOrderItems</param>
        /// <param name="min">lower limit of the Calories</param>
        /// <param name="max">upper limit of the Calories</param>
        /// <returns>List of IOrderItems that Calories is between min and max</returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> List, int? min, int? max)
        {
            if (min == null && max == null) return List;

            else if (min == null)
            {
                List<IOrderItem> menu = new List<IOrderItem>();
                foreach (IOrderItem item in List)
                {
                    if (item.Calories <= max)
                    {
                        menu.Add(item);
                    }
                }
                return menu;
            }

            else if (max == null)
            {
                List<IOrderItem> menu = new List<IOrderItem>();
                foreach (IOrderItem item in List)
                {
                    if (item.Calories >= min)
                    {
                        menu.Add(item);
                    }
                }
                return menu;
            }

            else
            {
                List<IOrderItem> menu = new List<IOrderItem>();
                foreach (IOrderItem item in List)
                {
                    if (item.Calories >= min && item.Calories <= max)
                    {
                        menu.Add(item);
                    }
                }
                return menu;
            }
        }

        /// <summary>
        /// Searches list for IOrderItems that price falls between min and max
        /// </summary>
        /// <param name="List">List Of IOrderItems</param>
        /// <param name="min">lower limit of the price</param>
        /// <param name="max">upper limit of the price</param>
        /// <returns>List of IOrderItems that price is between min and max</returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> List, double? min, double? max)
        {
            if (min == null && max == null) return List;

            else if (min == null)
            {
                List<IOrderItem> menu = new List<IOrderItem>();
                foreach (IOrderItem item in List)
                {
                    if(item.Price <= max)
                    {
                        menu.Add(item);
                    }
                }
                return menu;
            }

            else if (max == null)
            {
                List<IOrderItem> menu = new List<IOrderItem>();
                foreach (IOrderItem item in List)
                {
                    if (item.Price >= min)
                    {
                        menu.Add(item);
                    }
                }
                return menu;
            }

            else
            {
                List<IOrderItem> menu = new List<IOrderItem>();
                foreach (IOrderItem item in List)
                {
                    if (item.Price >= min && item.Price <= max)
                    {
                        menu.Add(item);
                    }
                }
                return menu;
            }
        }
    }
}
