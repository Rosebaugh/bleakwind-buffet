/*
 * Author: Zachery Brunner
 * Class: DragonbornWaffleFriesTests.cs
 * Purpose: Test the DragonbornWaffleFries.cs class in the Data library
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Enums;
using BleakwindBuffet.Data.Sides;
using System.ComponentModel;

namespace BleakwindBuffet.DataTests.UnitTests.SideTests
{
    public class DragonbornWaffleFriesTests
    {
        [Fact]
        public void ShouldBeAnIOrderItem()
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            Assert.IsAssignableFrom<IOrderItem>(db);
        }

        [Fact]
        public void ShouldBeADrink()
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            Assert.IsAssignableFrom<Side>(db);
        }

        [Fact]
        public void ShouldBeSmallByDefault()
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            Assert.Equal(Size.Small, db.Size);
        }

        [Fact]
        public void ShouldBeAbleToSetSize()
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            db.Size = Size.Large;
            Assert.Equal(Size.Large, db.Size);
            db.Size = Size.Medium;
            Assert.Equal(Size.Medium, db.Size);
            db.Size = Size.Small;
            Assert.Equal(Size.Small, db.Size);
        }

        [Fact]
        public void ShouldReturnCorrectSpecialInstructions()
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            Assert.Empty(db.SpecialInstructions);
        }

        [Theory]
        [InlineData(Size.Small, 0.42)]
        [InlineData(Size.Medium, 0.76)]
        [InlineData(Size.Large, 0.96)]
        public void ShouldReturnCorrectPriceBasedOnSize(Size size, double price)
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            db.Size = size;
            Assert.Equal(price, db.Price);
        }

        [Theory]
        [InlineData(Size.Small, 77)]
        [InlineData(Size.Medium, 89)]
        [InlineData(Size.Large, 100)]
        public void ShouldReturnCorrectCaloriesBasedOnSize(Size size, uint calories)
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            db.Size = size;
            Assert.Equal(calories, db.Calories);
        }

        [Theory]
        [InlineData(Size.Small, "Small Dragonborn Waffle Fries")]
        [InlineData(Size.Medium, "Medium Dragonborn Waffle Fries")]
        [InlineData(Size.Large, "Large Dragonborn Waffle Fries")]
        public void ShouldReturnCorrectToStringBasedOnSize(Size size, string name)
        {
            DragonbornWaffleFries db = new DragonbornWaffleFries();
            db.Size = size;
            Assert.Equal(name, db.ToString());
        }

        [Fact]
        public void ChangingSizeNotifiesSizeProperty()
        {
            var db = new DragonbornWaffleFries();

            Assert.PropertyChanged(db, "Size", () =>
            {
                db.Size = Size.Medium;
            });

            Assert.PropertyChanged(db, "Size", () =>
            {
                db.Size = Size.Large;
            });

            Assert.PropertyChanged(db, "Size", () =>
            {
                db.Size = Size.Small;
            });
        }

        [Fact]
        public void ChangingPriceNotifiesPriceProperty()
        {
            var db = new DragonbornWaffleFries();

            Assert.PropertyChanged(db, "Price", () =>
            {
                db.Size = Size.Medium;
            });

            Assert.PropertyChanged(db, "Price", () =>
            {
                db.Size = Size.Large;
            });

            Assert.PropertyChanged(db, "Price", () =>
            {
                db.Size = Size.Small;
            });
        }

        [Fact]
        public void ChangingCaloriesNotifiesCaloriesProperty()
        {
            var db = new DragonbornWaffleFries();

            Assert.PropertyChanged(db, "Calories", () =>
            {
                db.Size = Size.Medium;
            });

            Assert.PropertyChanged(db, "Calories", () =>
            {
                db.Size = Size.Large;
            });

            Assert.PropertyChanged(db, "Calories", () =>
            {
                db.Size = Size.Small;
            });
        }

        [Fact]
        public void ImplementsINotifyPropertyChangedInterface()
        {
            var db = new DragonbornWaffleFries();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(db);
        }

        [Fact]
        public void ReturnsCorrectDescription()
        {
            var db = new DragonbornWaffleFries();
            string description = "Crispy fried potato waffle fries.";
            Assert.Equal(description, db.Description);
        }
    }
}