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

        [Test]
        public void TestIfNull_PassValidValue_ShouldDoNothing()
        {
            Assert.DoesNotThrow(() => Validator.CheckIfNull(null));
        }
    }
}
