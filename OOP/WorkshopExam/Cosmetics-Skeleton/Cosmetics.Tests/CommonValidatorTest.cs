using Cosmetics.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CommonValidatorTest
    {
        [Test]
        public void TestIfNull_PassNull_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(()=>Validator.CheckIfNull(null));
        }

        [TestCase(3)]
        [TestCase("string")]
        public void TestIfNull_PassValidValue_ShouldNotThrow(object obj)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void TestCheckIfStringIsNullOrEmpty_PassNull_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null));
        }

        [Test]
        public void TestCheckIfStringIsNullOrEmpty_PassEmptyString_ShouldThrowNullReference()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(string.Empty));
        }

        [TestCase("string")]
        public void TestCheckIfStringIsNullOrEmpty_PassValidString_ShouldNotThrow(string text)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [TestCase(10,4,"two")]
        public void TestCheckIfStringLengthIsValid_PassStringWithLengthBelowMin_ShouldThrowIndexOutOFRange(int max, int min, string text)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text,max,min));
        }

        [TestCase(10, 4, "four hundred seventy three")]
        public void TestCheckIfStringLengthIsValid_PassStringWithLengthAboveMax_ShouldThrowIndexOutOFRange(int max, int min, string text)
        {
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [TestCase(10, 4, "sixty")]
        public void TestCheckIfStringLengthIsValid_PassValidString_ShouldNotThrow(int max, int min, string text)
        {
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
