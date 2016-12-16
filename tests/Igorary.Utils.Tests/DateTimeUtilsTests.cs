using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covalition.Igorary.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Igorary.Utils.Tests
{
    [TestClass]
    public class DateTimeUtilsTests
    {
        [TestMethod]
        public void OverlapRange() {

            // arrange
            DateTime a = new DateTime(2004, 07, 15);
            DateTime b = new DateTime(2006, 06, 06);
            DateTime c = new DateTime(2014, 01, 25);
            DateTime d = new DateTime(2023, 11, 02);

            // assert
            Assert.IsTrue(DateTimeUtils.OverlapRange(a, c, b, d) == true);
            Assert.IsTrue(DateTimeUtils.OverlapRange(a, b, c, d) == false);
        }

        [TestMethod]
        public void GetTotalHours() {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void GetFraction() {
            Assert.Inconclusive();
        }
    }
}
