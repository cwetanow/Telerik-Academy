using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Models.Batteries;
using NUnit.Framework;

namespace Computers.Tests.ModelsTests
{
    [TestFixture]
    public class LaptopBatteryTests
    {
        [TestCase(-150)]
        [TestCase(-1250)]
        [TestCase(-70)]
        public void TestCharge_PassLowerValues_ShouldSetBatteryPercentageZero(int lowerPercentage)
        {
            var battery = new LaptopBattery();

            battery.Charge(lowerPercentage);

            Assert.AreEqual(battery.PercentagePowerLeft, 0);
        }

        [TestCase(150)]
        [TestCase(1250)]
        [TestCase(70)]
        public void TestCharge_PassHigherValues_ShouldSetBatteryPercentageHundred(int higherPercentage)
        {
            var battery = new LaptopBattery();

            battery.Charge(higherPercentage);

            Assert.AreEqual(battery.PercentagePowerLeft, 100);
        }

        [TestCase(50)]
        [TestCase(25)]
        [TestCase(7)]
        [TestCase(-17)]
        [TestCase(-41)]
        [TestCase(-50)]
        public void TestCharge_PassValuesInRange_ShouldSetBatteryPercentageCorrectly(int percentage)
        {
            var battery = new LaptopBattery();
            var currentPercentage = battery.PercentagePowerLeft;

            battery.Charge(percentage);
            var expected = percentage + currentPercentage;

            Assert.AreEqual(battery.PercentagePowerLeft, expected);
        }
    }
}
