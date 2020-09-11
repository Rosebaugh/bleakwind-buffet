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
        public static IEnumerable<IOrderItem> FullMenu()
        {
            return Entrees().Concat(Sides().Concat(Drinks())).ToList();
        }
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
        public static IEnumerable<IOrderItem> Sides()
        {
            List<IOrderItem> sides = new List<IOrderItem>();
            
            foreach(Size s in Enum.GetValues(typeof(Size)))
            {
                sides.Add(new DragonbornWaffleFries()
                {
                    Size = s
                });
                sides.Add(new FriedMiraak()
                {
                    Size = s
                });
                sides.Add(new MadOtarGrits()
                {
                    Size = s
                });
                sides.Add(new VokunSalad()
                {
                    Size = s
                });
            }

            return sides;

        }
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            foreach (Size s in Enum.GetValues(typeof(Size)))
            {
                drinks.Add(new AretinoAppleJuice()
                {
                    Size = s
                });
                drinks.Add(new CandlehearthCoffee()
                {
                    Size = s,
                    Decaf = false
                });
                drinks.Add(new CandlehearthCoffee()
                {
                    Size = s,
                    Decaf = true
                });
                drinks.Add(new MarkarthMilk()
                {
                    Size = s
                });
                foreach(SodaFlavor f in Enum.GetValues(typeof(SodaFlavor)))
                {
                    drinks.Add(new SailorSoda()
                    {
                        Size = s,
                        Flavor = f
                    });
                }
                drinks.Add(new WarriorWater()
                {
                    Size = s
                });
            }

            return drinks;
        }
    }
}
