/*
 * Author: Caleb Rosebaugh
 * Class: ComboMealTest.cs
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

namespace BleakwindBuffet.DataTests.UnitTests
{
    public class ComboMealTest
    {

        [Fact]
        public void ImplementsINotifyPropertyChangedInterface()
        {
            var combo = new ComboMeal();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(combo);
        }

        [Fact]
        public void CanGetEntree()
        {
            var combo = new ComboMeal();

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
                combo.Entree = iItem;
                Assert.Equal(iItem, combo.Entree);
            }
        }

        [Fact]
        public void CanGetSide()
        {
            var combo = new ComboMeal();

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
                    combo.Side = jItem;
                    Assert.Equal(jItem, combo.Side);
                }
            }
        }

        [Fact]
        public void CanGetDrink()
        {
            var combo = new ComboMeal();

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

                            combo.Drink = kItem;
                            Assert.Equal(kItem, combo.Drink);
                        }
                    }
                    else
                    {
                        combo.Drink = kItem;
                        Assert.Equal(kItem, combo.Drink);
                    }
                }
            }
        }

        [Fact]
        public void ChangingEntreeNotifiesCaloriesProperty()
        {
            var combo = new ComboMeal();

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

                Assert.PropertyChanged(combo, "Calories", () =>
                {
                    combo.Entree = iItem;
                });
            }
        }

        [Fact]
        public void ChangingEntreeNotifiesPriceProperty()
        {
            var combo = new ComboMeal();

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

                Assert.PropertyChanged(combo, "Price", () =>
                {
                    combo.Entree = iItem;
                });
            }
        }

        [Fact]
        public void ChangingEntreeNotifiesSpecialInstructionsProperty()
        {
            var combo = new ComboMeal();

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

                Assert.PropertyChanged(combo, "SpecialInstructions", () =>
                {
                    combo.Entree = iItem;
                });
            }
        }

        [Fact]
        public void ChangingEntreeNotifiesEntreeProperty()
        {
            var combo = new ComboMeal();

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

                Assert.PropertyChanged(combo, "Entree", () =>
                {
                    combo.Entree = iItem;
                });
            }
        }


        [Fact]
        public void ChangingSideNotifiesCaloriesProperty()
        {
            var combo = new ComboMeal();

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

                    Assert.PropertyChanged(combo, "Calories", () =>
                    {
                        combo.Side = jItem;
                    });
                }
            }
        }

        [Fact]
        public void ChangingSideNotifiesPriceProperty()
        {
            var combo = new ComboMeal();

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

                    Assert.PropertyChanged(combo, "Price", () =>
                    {
                        combo.Side = jItem;
                    });
                }
            }
        }

        [Fact]
        public void ChangingSideNotifiesSpecialInstructionsProperty()
        {
            var combo = new ComboMeal();

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

                    Assert.PropertyChanged(combo, "SpecialInstructions", () =>
                    {
                        combo.Side = jItem;
                    });
                }
            }
        }

        [Fact]
        public void ChangingSideNotifiesSideProperty()
        {
            var combo = new ComboMeal();

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

                    Assert.PropertyChanged(combo, "Side", () =>
                    {
                        combo.Side = jItem;
                    });
                }
            }
        }


        [Fact]
        public void ChangingDrinkNotifiesCaloriesProperty()
        {
            var combo = new ComboMeal();

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

                            Assert.PropertyChanged(combo, "Calories", () =>
                            {
                                combo.Drink = kItem;
                            });
                        }
                    }
                    else
                    {
                        Assert.PropertyChanged(combo, "Calories", () =>
                        {
                            combo.Drink = kItem;
                        });
                    }
                }
            }
        }

        [Fact]
        public void ChangingDrinkNotifiesPriceProperty()
        {
            var combo = new ComboMeal();

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

                            Assert.PropertyChanged(combo, "Price", () =>
                            {
                                combo.Drink = kItem;
                            });
                        }
                    }
                    else
                    {
                        Assert.PropertyChanged(combo, "Price", () =>
                        {
                            combo.Drink = kItem;
                        });
                    }
                }
            }
        }

        [Fact]
        public void ChangingDrinkNotifiesSpecialInstructionsProperty()
        {
            var combo = new ComboMeal();

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

                            Assert.PropertyChanged(combo, "SpecialInstructions", () =>
                            {
                                combo.Drink = kItem;
                            });
                        }
                    }
                    else
                    {
                        Assert.PropertyChanged(combo, "SpecialInstructions", () =>
                        {
                            combo.Drink = kItem;
                        });
                    }
                }
            }
        }

        [Fact]
        public void ChangingDrinkNotifiesDrinkProperty()
        {
            var combo = new ComboMeal();

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

                            Assert.PropertyChanged(combo, "Drink", () =>
                            {
                                combo.Drink = kItem;
                            });
                        }
                    }
                    else
                    {
                        Assert.PropertyChanged(combo, "Drink", () =>
                        {
                            combo.Drink = kItem;
                        });
                    }
                }
            }
        }


        [Fact]
        public void ReturnsRightPriceCaloriesToStringAndInstructions()
        {
            ComboMeal CM = new ComboMeal();

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

                for(int j = 0; j < 4; j++)
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
                    foreach(Size s in (Size[]) Enum.GetValues(typeof(Size))){
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
                                if(kItem is SailorSoda)
                                {
                                    foreach (SodaFlavor f in (SodaFlavor[])Enum.GetValues(typeof(SodaFlavor)))
                                    {
                                        ((SailorSoda)kItem).Flavor = f;

                                        List<string> e = new List<string>();
                                        e.Add(iItem.ToString());
                                        List<string> sid = new List<string>();
                                        sid.Add(jItem.ToString());
                                        List<string> d = new List<string>();
                                        d.Add(kItem.ToString());

                                        CM.Entree = iItem;
                                        CM.Side = jItem;
                                        CM.Drink = kItem;

                                        Assert.Equal(iItem.Price + jItem.Price + kItem.Price - 1, CM.Price);
                                        Assert.Equal(iItem.Calories + jItem.Calories + kItem.Calories, CM.Calories);

                                        List<string> SpecialInstructions = (iItem.SpecialInstructions).Concat((jItem.SpecialInstructions).Concat((kItem.SpecialInstructions))).ToList();
                                        Assert.Equal(SpecialInstructions, CM.SpecialInstructions);
                                        Assert.Equal(iItem.ToString() + "\n" + jItem.ToString() + "\n" + kItem.ToString(), CM.ToString());
                                    }
                                }
                                else
                                {

                                    List<string> e = new List<string>();
                                    e.Add(iItem.ToString());
                                    List<string> sid = new List<string>();
                                    sid.Add(jItem.ToString());
                                    List<string> d = new List<string>();
                                    d.Add(kItem.ToString());

                                    CM.Entree = iItem;
                                    CM.Side = jItem;
                                    CM.Drink = kItem;

                                    Assert.Equal(iItem.Price + jItem.Price + kItem.Price - 1, CM.Price);
                                    Assert.Equal(iItem.Calories + jItem.Calories + kItem.Calories, CM.Calories);

                                    List<string> SpecialInstructions = (iItem.SpecialInstructions).Concat((jItem.SpecialInstructions).Concat((kItem.SpecialInstructions))).ToList();
                                    Assert.Equal(SpecialInstructions, CM.SpecialInstructions);
                                    Assert.Equal(iItem.ToString() + "\n" + jItem.ToString() + "\n" + kItem.ToString(), CM.ToString());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
