/*
 * Author: Caleb Rosebaugh
 * Class: MenuTests.cs
 * Purpose: Test the MenuTests.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;
using System;

namespace BleakwindBuffet.DataTests.UnitTests
{
    public class MenuTests
    {
        [Fact]
        public void FullMenu()
        {
            int NumberOfEntreeClasses = 7;
            int NumberOfSideClasses = 4;
            int NumberOfDrinkClasses = 5;

            int NumberOfDrinksWithFlavors = 1;
            int NumberOfDrinksThatCanBeDecaf = 1;

            int SizeCount = Enum.GetValues(typeof(Size)).Length;
            int FlavorCount = Enum.GetValues(typeof(SodaFlavor)).Length;
            int NumberOfExpectedItems = (NumberOfEntreeClasses + (NumberOfSideClasses * SizeCount) + ((NumberOfDrinkClasses - NumberOfDrinksThatCanBeDecaf
                - NumberOfDrinksWithFlavors) * SizeCount) +
                (NumberOfDrinksWithFlavors * SizeCount * FlavorCount) + (NumberOfDrinksThatCanBeDecaf * SizeCount * 2));

            List<IOrderItem> full = (List<IOrderItem>)Menu.FullMenu();
            Assert.Equal(NumberOfExpectedItems, full.Count);
        }

        [Fact]
        public void EntreeReturnsAllItems()
        {
            bool includesBriarHeartBurger = false;
            bool includesDoubleDraugr = false;
            bool includesGardenOrcOmlette = false;
            bool includesPhillyPoacher = false;
            bool includesSmokeHouseSkeleton = false;
            bool includesThalmorTripple = false;
            bool includesThugsTbone = false;
            bool EntreesOnlyAppearOnce = true;

            List<IOrderItem> entrees = (List<IOrderItem>)Menu.Entrees();
            foreach (IOrderItem i in entrees)
            {
                if (i is BriarheartBurger && !includesBriarHeartBurger) includesBriarHeartBurger = true;
                else if (i is DoubleDraugr && !includesDoubleDraugr) includesDoubleDraugr = true;
                else if (i is GardenOrcOmelette && !includesGardenOrcOmlette) includesGardenOrcOmlette = true;
                else if (i is PhillyPoacher && !includesPhillyPoacher) includesPhillyPoacher = true;
                else if (i is SmokehouseSkeleton && !includesSmokeHouseSkeleton) includesSmokeHouseSkeleton = true;
                else if (i is ThalmorTriple && !includesThalmorTripple) includesThalmorTripple = true;
                else if (i is ThugsTBone && !includesThugsTbone) includesThugsTbone = true;
                else EntreesOnlyAppearOnce = false;
            }
            Assert.True(includesBriarHeartBurger);
            Assert.True(includesDoubleDraugr);
            Assert.True(includesGardenOrcOmlette);
            Assert.True(includesPhillyPoacher);
            Assert.True(includesSmokeHouseSkeleton);
            Assert.True(includesThalmorTripple);
            Assert.True(includesThugsTbone);
            Assert.True(EntreesOnlyAppearOnce);
        }

        [Fact]
        public void SidesReturnsAllItems()
        {
            bool includesSmallDragonBornWaffleFries = false;
            bool includesMediumDragonBornWaffleFries = false;
            bool includesLargeDragonBornWaffleFries = false;
            bool includesSmallFriedMiraak = false;
            bool includesMediumFriedMiraak = false;
            bool includesLargeFriedMiraak = false;
            bool includesSmallMadOtarGrits = false;
            bool includesMediumMadOtarGrits = false;
            bool includesLargeMadOtarGrits = false;
            bool includesSmallVokunSalad = false;
            bool includesMediumVokunSalad = false;
            bool includesLargeVokunSalad = false;
            bool SidesOnlyAppearOnce = true;
            bool OnlySidesAppear = true;

            List<IOrderItem> entrees = (List<IOrderItem>)Menu.Sides();
            foreach (IOrderItem i in entrees)
            {
                if (i is DragonbornWaffleFries)
                {
                    DragonbornWaffleFries db = (DragonbornWaffleFries)i;
                    Size s = db.Size;
                    if (s == Size.Small && !includesSmallDragonBornWaffleFries) includesSmallDragonBornWaffleFries = true;
                    else if (s == Size.Medium && !includesMediumDragonBornWaffleFries) includesMediumDragonBornWaffleFries = true;
                    else if (s == Size.Large && !includesLargeDragonBornWaffleFries) includesLargeDragonBornWaffleFries = true;
                    else SidesOnlyAppearOnce = false;

                }
                else if (i is FriedMiraak)
                {
                    FriedMiraak fm = (FriedMiraak)i;
                    Size s = fm.Size;
                    if (s == Size.Small && !includesSmallFriedMiraak) includesSmallFriedMiraak = true;
                    else if (s == Size.Medium && !includesMediumFriedMiraak) includesMediumFriedMiraak = true;
                    else if (s == Size.Large && !includesLargeFriedMiraak) includesLargeFriedMiraak = true;
                    else SidesOnlyAppearOnce = false;
                }
                else if (i is MadOtarGrits)
                {
                    MadOtarGrits mog = (MadOtarGrits)i;
                    Size s = mog.Size;
                    if (s == Size.Small && !includesSmallMadOtarGrits) includesSmallMadOtarGrits = true;
                    else if (s == Size.Medium && !includesMediumMadOtarGrits) includesMediumMadOtarGrits = true;
                    else if (s == Size.Large && !includesLargeMadOtarGrits) includesLargeMadOtarGrits = true;
                    else SidesOnlyAppearOnce = false;
                }
                else if (i is VokunSalad)
                {
                    VokunSalad vs = (VokunSalad)i;
                    Size s = vs.Size;
                    if (s == Size.Small && !includesSmallVokunSalad) includesSmallVokunSalad = true;
                    else if (s == Size.Medium && !includesMediumVokunSalad) includesMediumVokunSalad = true;
                    else if (s == Size.Large && !includesLargeVokunSalad) includesLargeVokunSalad = true;
                    else SidesOnlyAppearOnce = false;
                }
                else OnlySidesAppear = false;
            }
            Assert.True(includesSmallDragonBornWaffleFries);
            Assert.True(includesMediumDragonBornWaffleFries);
            Assert.True(includesLargeDragonBornWaffleFries);
            Assert.True(includesSmallFriedMiraak);
            Assert.True(includesMediumFriedMiraak);
            Assert.True(includesLargeFriedMiraak);
            Assert.True(includesSmallMadOtarGrits);
            Assert.True(includesMediumMadOtarGrits);
            Assert.True(includesLargeMadOtarGrits);
            Assert.True(includesSmallVokunSalad);
            Assert.True(includesMediumVokunSalad);
            Assert.True(includesLargeVokunSalad);
            Assert.True(SidesOnlyAppearOnce);
            Assert.True(OnlySidesAppear);
        }

        [Fact]
        public void DrinksReturnsAllItems()
        {
            bool includesSmallArentinoApplejuice = false;
            bool includesMediumArentinoApplejuice = false;
            bool includesLargeArentinoApplejuice = false;
            bool includesSmallCandleHearthCoffee = false;
            bool includesMediumCandleHearthCoffee = false;
            bool includesLargeCandleHearthCoffee = false;
            bool includesSmallDecafCandleHearthCoffee = false;
            bool includesMediumDecafCandleHearthCoffee = false;
            bool includesLargeDecafCandleHearthCoffee = false;
            bool includesSmallMarkarthMilk = false;
            bool includesMediumMarkarthMilk = false;
            bool includesLargeMarkarthMilk = false;
            bool includesSmallWarriorWater = false;
            bool includesMediumWarriorWater = false;
            bool includesLargeWarriorWater = false;
            bool includesSmallBlackberrySailorSoda = false;
            bool includesMediumBlackberrySailorSoda = false;
            bool includesLargeBlackberrySailorSoda = false;
            bool includesSmallCherrySailorSoda = false;
            bool includesMediumCherrySailorSoda = false;
            bool includesLargeCherrySailorSoda = false;
            bool includesSmallGrapefruitSailorSoda = false;
            bool includesMediumGrapefruitSailorSoda = false;
            bool includesLargeGrapefruitSailorSoda = false;
            bool includesSmallLemonSailorSoda = false;
            bool includesMediumLemonSailorSoda = false;
            bool includesLargeLemonSailorSoda = false;
            bool includesSmallPeachSailorSoda = false;
            bool includesMediumPeachSailorSoda = false;
            bool includesLargePeachSailorSoda = false;
            bool includesSmallWatermelonSailorSoda = false;
            bool includesMediumWatermelonSailorSoda = false;
            bool includesLargeWatermelonSailorSoda = false;

            bool DrinksOnlyAppearOnce = true;
            bool DrinkFlavorsOnlyAppearOnce = true;
            bool OnlyDrinksAppear = true;

            List<IOrderItem> entrees = (List<IOrderItem>)Menu.Drinks();
            foreach (IOrderItem i in entrees)
            {
                if (i is AretinoAppleJuice)
                {
                    AretinoAppleJuice aj = (AretinoAppleJuice)i;
                    Size s = aj.Size;
                    if (s == Size.Small && !includesSmallArentinoApplejuice) includesSmallArentinoApplejuice = true;
                    else if (s == Size.Medium && !includesMediumArentinoApplejuice) includesMediumArentinoApplejuice = true;
                    else if (s == Size.Large && !includesLargeArentinoApplejuice) includesLargeArentinoApplejuice = true;
                    else DrinksOnlyAppearOnce = false;

                }
                else if (i is CandlehearthCoffee)
                {
                    CandlehearthCoffee cc = (CandlehearthCoffee)i;
                    Size s = cc.Size;
                    bool Decaf = cc.Decaf;
                    if (s == Size.Small && !Decaf && !includesSmallCandleHearthCoffee) includesSmallCandleHearthCoffee = true;
                    else if (s == Size.Medium && !Decaf && !includesMediumCandleHearthCoffee) includesMediumCandleHearthCoffee = true;
                    else if (s == Size.Large && !Decaf && !includesLargeCandleHearthCoffee) includesLargeCandleHearthCoffee = true;
                    else if (s == Size.Small && Decaf && !includesSmallDecafCandleHearthCoffee) includesSmallDecafCandleHearthCoffee = true;
                    else if (s == Size.Medium && Decaf && !includesMediumDecafCandleHearthCoffee) includesMediumDecafCandleHearthCoffee = true;
                    else if (s == Size.Large && Decaf && !includesLargeDecafCandleHearthCoffee) includesLargeDecafCandleHearthCoffee = true;
                    else DrinksOnlyAppearOnce = false;

                }
                else if (i is MarkarthMilk)
                {
                    MarkarthMilk mm = (MarkarthMilk)i;
                    Size s = mm.Size;
                    if (s == Size.Small && !includesSmallMarkarthMilk) includesSmallMarkarthMilk = true;
                    else if (s == Size.Medium && !includesMediumMarkarthMilk) includesMediumMarkarthMilk = true;
                    else if (s == Size.Large && !includesLargeMarkarthMilk) includesLargeMarkarthMilk = true;
                    else DrinksOnlyAppearOnce = false;

                }
                else if (i is SailorSoda)
                {
                    SailorSoda ss = (SailorSoda)i;
                    Size s = ss.Size;
                    SodaFlavor f = ss.Flavor;
                    if (s == Size.Small)
                    {
                        if (f == SodaFlavor.Blackberry && !includesSmallBlackberrySailorSoda) includesSmallBlackberrySailorSoda = true;
                        else if (f == SodaFlavor.Cherry && !includesSmallCherrySailorSoda) includesSmallCherrySailorSoda = true;
                        else if (f == SodaFlavor.Grapefruit && !includesSmallGrapefruitSailorSoda) includesSmallGrapefruitSailorSoda = true;
                        else if (f == SodaFlavor.Lemon && !includesSmallLemonSailorSoda) includesSmallLemonSailorSoda = true;
                        else if (f == SodaFlavor.Peach && !includesSmallPeachSailorSoda) includesSmallPeachSailorSoda = true;
                        else if (f == SodaFlavor.Watermelon && !includesSmallWatermelonSailorSoda) includesSmallWatermelonSailorSoda = true;
                        else DrinkFlavorsOnlyAppearOnce = false;
                    }
                    else if (s == Size.Medium)
                    {
                        if (f == SodaFlavor.Blackberry && !includesMediumBlackberrySailorSoda) includesMediumBlackberrySailorSoda = true;
                        else if (f == SodaFlavor.Cherry && !includesMediumCherrySailorSoda) includesMediumCherrySailorSoda = true;
                        else if (f == SodaFlavor.Grapefruit && !includesMediumGrapefruitSailorSoda) includesMediumGrapefruitSailorSoda = true;
                        else if (f == SodaFlavor.Lemon && !includesMediumLemonSailorSoda) includesMediumLemonSailorSoda = true;
                        else if (f == SodaFlavor.Peach && !includesMediumPeachSailorSoda) includesMediumPeachSailorSoda = true;
                        else if (f == SodaFlavor.Watermelon && !includesMediumWatermelonSailorSoda) includesMediumWatermelonSailorSoda = true;
                        else DrinkFlavorsOnlyAppearOnce = false;
                    }
                    else if (s == Size.Large)
                    {
                        if (f == SodaFlavor.Blackberry && !includesLargeBlackberrySailorSoda) includesLargeBlackberrySailorSoda = true;
                        else if (f == SodaFlavor.Cherry && !includesLargeCherrySailorSoda) includesLargeCherrySailorSoda = true;
                        else if (f == SodaFlavor.Grapefruit && !includesLargeGrapefruitSailorSoda) includesLargeGrapefruitSailorSoda = true;
                        else if (f == SodaFlavor.Lemon && !includesLargeLemonSailorSoda) includesLargeLemonSailorSoda = true;
                        else if (f == SodaFlavor.Peach && !includesLargePeachSailorSoda) includesLargePeachSailorSoda = true;
                        else if (f == SodaFlavor.Watermelon && !includesLargeWatermelonSailorSoda) includesLargeWatermelonSailorSoda = true;
                        else DrinkFlavorsOnlyAppearOnce = false;
                    }
                    else DrinksOnlyAppearOnce = false;

                }
                else if (i is WarriorWater)
                {
                    WarriorWater ww = (WarriorWater)i;
                    Size s = ww.Size;
                    if (s == Size.Small && !includesSmallWarriorWater) includesSmallWarriorWater = true;
                    else if (s == Size.Medium && !includesMediumWarriorWater) includesMediumWarriorWater = true;
                    else if (s == Size.Large && !includesLargeWarriorWater) includesLargeWarriorWater = true;
                    else DrinksOnlyAppearOnce = false;

                }
                else OnlyDrinksAppear = false;
            }

            Assert.True(includesSmallArentinoApplejuice);
            Assert.True(includesMediumArentinoApplejuice);
            Assert.True(includesLargeArentinoApplejuice);
            Assert.True(includesSmallCandleHearthCoffee);
            Assert.True(includesMediumCandleHearthCoffee);
            Assert.True(includesLargeCandleHearthCoffee);
            Assert.True(includesSmallDecafCandleHearthCoffee);
            Assert.True(includesMediumDecafCandleHearthCoffee);
            Assert.True(includesLargeDecafCandleHearthCoffee);
            Assert.True(includesSmallMarkarthMilk);
            Assert.True(includesMediumMarkarthMilk);
            Assert.True(includesLargeMarkarthMilk);
            Assert.True(includesSmallWarriorWater);
            Assert.True(includesMediumWarriorWater);
            Assert.True(includesLargeWarriorWater);
            Assert.True(includesSmallBlackberrySailorSoda);
            Assert.True(includesMediumBlackberrySailorSoda);
            Assert.True(includesLargeBlackberrySailorSoda);
            Assert.True(includesSmallCherrySailorSoda);
            Assert.True(includesMediumCherrySailorSoda);
            Assert.True(includesLargeCherrySailorSoda);
            Assert.True(includesSmallGrapefruitSailorSoda);
            Assert.True(includesMediumGrapefruitSailorSoda);
            Assert.True(includesLargeGrapefruitSailorSoda);
            Assert.True(includesSmallLemonSailorSoda);
            Assert.True(includesMediumLemonSailorSoda);
            Assert.True(includesLargeLemonSailorSoda);
            Assert.True(includesSmallPeachSailorSoda);
            Assert.True(includesMediumPeachSailorSoda);
            Assert.True(includesLargePeachSailorSoda);
            Assert.True(includesSmallWatermelonSailorSoda);
            Assert.True(includesMediumWatermelonSailorSoda);
            Assert.True(includesLargeWatermelonSailorSoda);
            Assert.True(DrinksOnlyAppearOnce);
            Assert.True(DrinkFlavorsOnlyAppearOnce);
            Assert.True(OnlyDrinksAppear);
        }

        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, null, null)]
        [InlineData(3, null, null)]
        [InlineData(1, 100, null)]
        [InlineData(2, 50, null)]
        [InlineData(3, 50, null)]
        [InlineData(1, null, 200)]
        [InlineData(2, null, 300)]
        [InlineData(3, null, 200)]
        [InlineData(1, 100, 200)]
        [InlineData(2, 50, 300)]
        [InlineData(3, 50, 200)]
        public void MenuFilteredByCalories(int itemtype, int? min, int? max)
        {
            IEnumerable<IOrderItem> Menu = new List<IOrderItem>();
            switch (itemtype)
            {
                case 1:
                    Menu = Data.Menu.Entrees();
                    break;
                case 2:
                    Menu = Data.Menu.Sides();
                    break;
                case 3:
                    Menu = Data.Menu.Drinks();
                    break;
            }

            Menu = Data.Menu.FilterByCalories(Menu, min, max);

            if (min == null && max == null)
            {
                List<IOrderItem> basecase;
                int count = 0;
                switch (itemtype)
                {
                    case 1:
                        basecase = (List<IOrderItem>)Data.Menu.Entrees();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                    case 2:
                        basecase = (List<IOrderItem>)Data.Menu.Sides();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                    case 3:
                        basecase = (List<IOrderItem>)Data.Menu.Drinks();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                }
            }
            else if (min == null)
            {
                foreach (IOrderItem item in Menu)
                {
                    Assert.True(item.Calories <= max);
                }
            }
            else if (max == null)
            {
                foreach (IOrderItem item in Menu)
                {
                    Assert.True(item.Calories >= min);
                }
            }
            else
            {
                foreach (IOrderItem item in Menu)
                {
                    Assert.True(item.Calories >= min);
                    Assert.True(item.Calories <= max);
                }
            }
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        [InlineData(3, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        public void MenuFilteredByCategory(int itemtype, int CAT)
        {
            IEnumerable<IOrderItem> Menu = new List<IOrderItem>();
            List<IOrderItem> basecase = (List<IOrderItem>)Data.Menu.Entrees();
            switch (itemtype)
            {
                case 1:
                    Menu = Data.Menu.Entrees();
                    basecase = (List<IOrderItem>)Data.Menu.Entrees();
                    break;
                case 2:
                    Menu = Data.Menu.Sides();
                    basecase = (List<IOrderItem>)Data.Menu.Sides();
                    break;
                case 3:
                    Menu = Data.Menu.Drinks();
                    basecase = (List<IOrderItem>)Data.Menu.Drinks();
                    break;
            }
            List<string> cat = new List<string>();
            switch (CAT)
            {
                case 1:
                    cat.Add("Entree");
                    break;
                case 2:
                    cat.Add("Side");
                    break;
                case 3:
                    cat.Add("Drink");
                    break;
            }


            Menu = Data.Menu.FilterByCategory(Menu, cat);

            int count = 0;
            foreach (IOrderItem item in Menu)
            {
                switch (CAT)
                {
                    case 1:
                        Assert.True(item is Entree);
                        break;
                    case 2:
                        Assert.True(item is Side);
                        break;
                    case 3:
                        Assert.True(item is Drink);
                        break;
                    case 4:
                        Assert.Equal(basecase[count].GetType(), item.GetType());
                        count++;
                        break;
                }
            }
        }


        [Theory]
        [InlineData(1, null, null)]
        [InlineData(2, null, null)]
        [InlineData(3, null, null)]
        [InlineData(1, 3.2, null)]
        [InlineData(2, 2, null)]
        [InlineData(3, 1, null)]
        [InlineData(1, null, 6.99)]
        [InlineData(2, null, 2.99)]
        [InlineData(3, null, 3)]
        [InlineData(1, 3.20, 6.99)]
        [InlineData(2, 2, 2.99)]
        [InlineData(3, 1, 3)]
        public void MenuFilteredByPrice(int itemtype, double? min, double? max)
        {
            IEnumerable<IOrderItem> Menu = new List<IOrderItem>();
            switch (itemtype)
            {
                case 1:
                    Menu = Data.Menu.Entrees();
                    break;
                case 2:
                    Menu = Data.Menu.Sides();
                    break;
                case 3:
                    Menu = Data.Menu.Drinks();
                    break;
            }

            Menu = Data.Menu.FilterByPrice(Menu, min, max);

            if (min == null && max == null)
            {
                List<IOrderItem> basecase;
                int count = 0;
                switch (itemtype)
                {
                    case 1:
                        basecase = (List<IOrderItem>)Data.Menu.Entrees();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                    case 2:
                        basecase = (List<IOrderItem>)Data.Menu.Sides();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                    case 3:
                        basecase = (List<IOrderItem>)Data.Menu.Drinks();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                }
            }
            else if (min == null)
            {
                foreach (IOrderItem item in Menu)
                {
                    Assert.True(item.Price <= max);
                }
            }
            else if (max == null)
            {
                foreach (IOrderItem item in Menu)
                {
                    Assert.True(item.Price >= min);
                }
            }
            else
            {
                foreach (IOrderItem item in Menu)
                {
                    Assert.True(item.Price >= min);
                    Assert.True(item.Price <= max);
                }
            }
        }

        [Theory]
        [InlineData(1, null)]
        [InlineData(2, null)]
        [InlineData(3, null)]
        [InlineData(1, "")]
        [InlineData(2, "")]
        [InlineData(3, "")]
        [InlineData(1, "peanut")]
        [InlineData(2, "peanut")]
        [InlineData(3, "peanut")]
        [InlineData(1, "soda")]
        [InlineData(3, "soda")]
        [InlineData(2, "soda")]
        [InlineData(1, "p")]
        [InlineData(3, "p")]
        [InlineData(2, "p")]
        [InlineData(1, "skeleton")]
        [InlineData(3, "oar")]
        [InlineData(2, "warrior")]
        public void MenuFilteredBySearch(int itemtype, string search)
        {
            IEnumerable<IOrderItem> Menu = new List<IOrderItem>();
            switch (itemtype)
            {
                case 1:
                    Menu = Data.Menu.Entrees();
                    break;
                case 2:
                    Menu = Data.Menu.Sides();
                    break;
                case 3:
                    Menu = Data.Menu.Drinks();
                    break;
            }

            Menu = Data.Menu.Search(Menu, search);

            if(search == "" || search == null)
            {
                List<IOrderItem> basecase;
                int count = 0;
                switch (itemtype)
                {
                    case 1:
                        basecase = (List<IOrderItem>)Data.Menu.Entrees();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                    case 2:
                        basecase = (List<IOrderItem>)Data.Menu.Sides();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                    case 3:
                        basecase = (List<IOrderItem>)Data.Menu.Drinks();
                        foreach (IOrderItem item in Menu)
                        {
                            Assert.Equal(basecase[count].GetType(), item.GetType());
                            count++;
                        }
                        break;
                }
            }
            else
            {
                foreach(IOrderItem item in Menu)
                {
                    Assert.True(item.ToString().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0);
                }
            }
        }
    }
}
