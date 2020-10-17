/*
 * Author: Caleb Rosebaugh
 * Class: OrderTests.cs
 * Purpose: Test the ComboMealTest.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;
using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace BleakwindBuffet.DataTests.UnitTests
{
    public class OrderTests
    {
        [Fact]
        public void ImplementsObservableCollectionInterface()
        {
            var order = new Order();
            Assert.IsAssignableFrom<ObservableCollection<IOrderItem>>(order);
        }

        [Fact]
        public void ReturnsCorrectCalories()
        {
            for (int i = 0; i < 7; i++)
            {
                Entree iItem = new BriarheartBurger();
                switch (i)
                {
                    case 0:
                        iItem = new BriarheartBurger();
                        break;
                    case 1:
                        iItem = new DoubleDraugr();
                        break;
                    case 2:
                        iItem = new GardenOrcOmelette();
                        break;
                    case 3:
                        iItem = new PhillyPoacher();
                        break;
                    case 4:
                        iItem = new SmokehouseSkeleton();
                        break;
                    case 5:
                        iItem = new ThalmorTriple();
                        break;
                    case 6:
                        iItem = new ThugsTBone();
                        break;
                }

                for (int j = 0; j < 4; j++)
                {
                    Side jItem = new DragonbornWaffleFries();
                    switch (j)
                    {
                        case 0:
                            jItem = new DragonbornWaffleFries();
                            break;
                        case 1:
                            jItem = new FriedMiraak();
                            break;
                        case 2:
                            jItem = new MadOtarGrits();
                            break;
                        case 3:
                            jItem = new VokunSalad();
                            break;

                    }
                    foreach (Size s in (Size[])Enum.GetValues(typeof(Size)))
                    {
                        jItem.Size = s;

                        for (int k = 0; k < 5; k++)
                        {
                            Drink kItem = new SailorSoda();
                            switch (k)
                            {
                                case 0:
                                    kItem = new AretinoAppleJuice();
                                    break;
                                case 1:
                                    kItem = new CandlehearthCoffee();
                                    break;
                                case 2:
                                    kItem = new MarkarthMilk();
                                    break;
                                case 3:
                                    kItem = new SailorSoda();
                                    break;
                                case 4:
                                    kItem = new WarriorWater();
                                    break;
                            }

                            foreach (Size ss in (Size[])Enum.GetValues(typeof(Size)))
                            {
                                kItem.Size = ss;
                                if (kItem is SailorSoda)
                                {
                                    foreach (SodaFlavor f in (SodaFlavor[])Enum.GetValues(typeof(SodaFlavor)))
                                    {
                                        ((SailorSoda)kItem).Flavor = f;

                                        Order order = new Order();
                                        uint CalCount = 0;
                                        order.Add(iItem);
                                        order.Add(jItem);
                                        order.Add(kItem);
                                        order.Add(new ComboMeal());
                                        CalCount += iItem.Calories;
                                        CalCount += jItem.Calories;
                                        CalCount += kItem.Calories;
                                        CalCount += new ComboMeal().Calories;

                                        Assert.Equal(CalCount, order.Calories);
                                    }
                                }
                                else
                                {
                                    Order order = new Order();
                                    uint CalCount = 0;
                                    order.Add(iItem);
                                    order.Add(jItem);
                                    order.Add(kItem);
                                    order.Add(new ComboMeal());
                                    CalCount += iItem.Calories;
                                    CalCount += jItem.Calories;
                                    CalCount += kItem.Calories;
                                    CalCount += new ComboMeal().Calories;

                                    Assert.Equal(CalCount, order.Calories);
                                }
                            }
                        }
                    }
                }
            }
        }
        [Fact]
        public void ReturnsCorrectTotals()
        {
            for (int i = 0; i < 7; i++)
            {
                Entree iItem = new BriarheartBurger();
                switch (i)
                {
                    case 0:
                        iItem = new BriarheartBurger();
                        break;
                    case 1:
                        iItem = new DoubleDraugr();
                        break;
                    case 2:
                        iItem = new GardenOrcOmelette();
                        break;
                    case 3:
                        iItem = new PhillyPoacher();
                        break;
                    case 4:
                        iItem = new SmokehouseSkeleton();
                        break;
                    case 5:
                        iItem = new ThalmorTriple();
                        break;
                    case 6:
                        iItem = new ThugsTBone();
                        break;
                }

                for (int j = 0; j < 4; j++)
                {
                    Side jItem = new DragonbornWaffleFries();
                    switch (j)
                    {
                        case 0:
                            jItem = new DragonbornWaffleFries();
                            break;
                        case 1:
                            jItem = new FriedMiraak();
                            break;
                        case 2:
                            jItem = new MadOtarGrits();
                            break;
                        case 3:
                            jItem = new VokunSalad();
                            break;

                    }
                    foreach (Size s in (Size[])Enum.GetValues(typeof(Size)))
                    {
                        jItem.Size = s;

                        for (int k = 0; k < 5; k++)
                        {
                            Drink kItem = new SailorSoda();
                            switch (k)
                            {
                                case 0:
                                    kItem = new AretinoAppleJuice();
                                    break;
                                case 1:
                                    kItem = new CandlehearthCoffee();
                                    break;
                                case 2:
                                    kItem = new MarkarthMilk();
                                    break;
                                case 3:
                                    kItem = new SailorSoda();
                                    break;
                                case 4:
                                    kItem = new WarriorWater();
                                    break;
                            }

                            foreach (Size ss in (Size[])Enum.GetValues(typeof(Size)))
                            {
                                kItem.Size = ss;
                                if (kItem is SailorSoda)
                                {
                                    foreach (SodaFlavor f in (SodaFlavor[])Enum.GetValues(typeof(SodaFlavor)))
                                    {
                                        ((SailorSoda)kItem).Flavor = f;

                                        Order order = new Order();
                                        double Price = 0;
                                        order.Add(iItem);
                                        order.Add(jItem);
                                        order.Add(kItem);
                                        order.Add(new ComboMeal());
                                        Price += iItem.Price;
                                        Price += jItem.Price;
                                        Price += kItem.Price;
                                        Price += new ComboMeal().Price;

                                        Assert.Equal(string.Format("{0:N2}", Math.Round(Price, 2)), order.Subtotal);
                                        Assert.Equal(string.Format("{0:N2}", Math.Round(order.TaxPercent * Price, 2)), order.Tax);
                                        Assert.Equal(string.Format("{0:N2}", Math.Round(order.TaxPercent * Price + Price, 2)), order.Total);
                                    }
                                }
                                else
                                {
                                    Order order = new Order();
                                    double Price = 0;
                                    order.Add(iItem);
                                    order.Add(jItem);
                                    order.Add(kItem);
                                    order.Add(new ComboMeal());
                                    Price += iItem.Price;
                                    Price += jItem.Price;
                                    Price += kItem.Price;
                                    Price += new ComboMeal().Price;

                                    Assert.Equal(string.Format("{0:N2}", Math.Round(Price, 2)), order.Subtotal);
                                    Assert.Equal(string.Format("{0:N2}", Math.Round(order.TaxPercent * Price, 2)), order.Tax);
                                    Assert.Equal(string.Format("{0:N2}", Math.Round(order.TaxPercent * Price + Price, 2)), order.Total);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
