/*
 * Author: Caleb Rosebaugh
 * Class: ChangeTests.cs
 * Purpose: Test the ChangeTests.cs class in PointOfSale
 */
using Xunit;

using BleakwindBuffet.Data;
using BleakwindBuffet.Data.Entrees;
using BleakwindBuffet.Data.Sides;
using BleakwindBuffet.Data.Drinks;
using BleakwindBuffet.Data.Enums;
using System.Collections.Generic;
using PointOfSale;
using System;
using System.Windows.Media;

namespace BleakwindBuffet.DataTests.UnitTests
{
    public class ChangeTests
    {
        [Fact]
        public void DoesNothingForWater()
        {
            Change cash = new Change();
            cash.Total = 0;

            cash.ChangeCalculator();

            foreach(int i in cash.GiveBackChange)
            {
                Assert.Equal(0, i);
            }
        }

        [Fact]
        public void OweStillReturnsRightValue()
        {
            Change cash = new Change();
            cash.Total = 0;
            cash.givenAmount = 0;
            Assert.Equal(0, cash.OwedStill);
            cash.givenAmount = 10;
            Assert.Equal(0, cash.OwedStill);
            cash.Total = 10;
            cash.givenAmount = 0;
            Assert.Equal(10, cash.OwedStill);
            cash.Total = 10;
            cash.givenAmount = 10;
            Assert.Equal(0, cash.OwedStill);
        }

        [Fact]
        public void CustomerGiveReturnsRightValue()
        {
            Change cash = new Change();
            cash.Total = 0;
            cash.givenAmount = 0;
            Assert.Equal(0, cash.CustomerGive);
            cash.givenAmount = 10;
            Assert.Equal(10, cash.CustomerGive);
            cash.Total = 10;
            cash.givenAmount = 0;
            Assert.Equal(0, cash.CustomerGive);
            cash.Total = 10;
            cash.givenAmount = 10;
            Assert.Equal(0, cash.CustomerGive);
        }

        [Theory]
        [InlineData(24, 54, 30)]
        [InlineData(75, 84, 9)]
        [InlineData(.95, 1, .05)]
        [InlineData(1.97, 14, 12.03)]
        [InlineData(2.98, 10, 7.02)]
        [InlineData(9.70, 184, 174.30)]
        public void GivesCorrectChange(double total, double given, double giveBack)
        {
            Change cash = new Change();
            cash.Total = total;
            cash.givenAmount = given;
            Assert.True(cash.CustomerGive == giveBack);

            cash.ChangeCalculator();
            double[] numbers = new double[] { 100, 50, 20, 10, 5, 2, 1, 1, .5, .25, .1, .05, .01 };
            double final = 0;
            int count = 0;
            foreach(int i in cash.GiveBackChange)
            {
                final += Math.Round(numbers[count] * i, 2);
                count++;
            }
            Assert.True(Math.Round(final, 2) == giveBack);
            RoundRegister.CashDrawer.ResetDrawer();
        }
    }
}
