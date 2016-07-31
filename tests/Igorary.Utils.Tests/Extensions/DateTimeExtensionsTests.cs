using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Igorary.Utils.Extensions;

namespace Igorary.Utils.Tests.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void Max() {
            // arrange
            DateTime empty = default(DateTime);
            DateTime a = new DateTime(2004, 07, 15);
            DateTime b = new DateTime(2016, 06, 06);

            // assert
            Assert.AreEqual(a, empty.Max(a));
            Assert.AreEqual(a, a.Max(empty));

            Assert.AreEqual(b, b.Max(a));
            Assert.AreEqual(b, a.Max(b));
        }

        [TestMethod]
        public void Min() {
            // arrange
            DateTime empty = default(DateTime);
            DateTime a = new DateTime(2004, 07, 15);
            DateTime b = new DateTime(2016, 06, 06);

            // assert
            Assert.AreEqual(a, empty.Min(a));
            Assert.AreEqual(a, a.Min(empty));

            Assert.AreEqual(a, b.Min(a));
            Assert.AreEqual(a, a.Min(b));
        }

        [TestMethod]
        public void LastDayOfMonth() {
            // arrange
            DateTime dateTime = new DateTime(2015, 05, 14);

            // act
            DateTime lastDay = dateTime.LastDayOfMonth();

            // assert
            Assert.AreEqual(new DateTime(2015, 05, 31), lastDay);

        }

        [TestMethod]
        public void FirstDayOfMonth() {
            // arrange
            DateTime dateTime = new DateTime(2015, 05, 14);

            // act
            DateTime lastDay = dateTime.FirstDayOfMonth();

            // assert
            Assert.AreEqual(new DateTime(2015, 05, 1), lastDay);

        }
    }
}
