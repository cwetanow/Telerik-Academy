using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Tests
{
    [TestFixture]
    public class TestSchool
    {
        [TestCase]
        public void School_InitialisesCorrectly()
        {
            var school = new School();
            Assert.IsNotNull(school);
        }
    }
}
