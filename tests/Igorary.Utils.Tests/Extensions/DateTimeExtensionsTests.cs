using System;
using System.Linq;

using Igorary.Utils.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Igorary.Utils.Tests.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void Max()
        {
            // arrange
            DateTime? @null = null;
            DateTime? empty = default(DateTime);
            DateTime? a = new DateTime(2004, 07, 15);
            DateTime? b = new DateTime(2016, 06, 06);

            // assert
            Assert.AreEqual(a, empty.Max(a));
            Assert.AreEqual(a, a.Max(empty));

            Assert.AreEqual(b, b.Max(a));
            Assert.AreEqual(b, a.Max(b));

            Assert.AreEqual(a, @null.Max(a));
            Assert.AreEqual(a, a.Max(@null));
        }

        [TestMethod]
        public void Min()
        {
            // arrange
            DateTime? @null = null;
            DateTime? empty = default(DateTime);
            DateTime? a = new DateTime(2004, 07, 15);
            DateTime? b = new DateTime(2016, 06, 06);

            // assert
            Assert.AreEqual(a, empty.Min(a));
            Assert.AreEqual(a, a.Min(empty));

            Assert.AreEqual(a, @null.Min(a));
            Assert.AreEqual(a, a.Min(@null));

            Assert.AreEqual(a, b.Min(a));
            Assert.AreEqual(a, a.Min(b));
        }

        [TestMethod]
        public void LastDayOfMonth()
        {
            // arrange
            DateTime dateTime = new DateTime(2015, 05, 14);

            // act
            DateTime lastDay = dateTime.LastDayOfMonth();

            // assert
            Assert.AreEqual(new DateTime(2015, 05, 31), lastDay);

        }

        [TestMethod]
        public void FirstDayOfMonth()
        {
            // arrange
            DateTime dateTime = new DateTime(2015, 05, 14);

            // act
            DateTime firstDay = dateTime.FirstDayOfMonth();

            // assert
            Assert.AreEqual(new DateTime(2015, 05, 1), firstDay);

        }

        [TestMethod]
        public void RoundSeconds()
        {
            // arrange
            DateTime dateTime1 = new DateTime(2015, 05, 14, 1, 15, 33, 211);
            DateTime dateTime2 = new DateTime(2015, 05, 14, 1, 15, 33, 0);

            // act
            DateTime res1 = dateTime1.RoundSeconds();
            DateTime res2 = dateTime2.RoundSeconds();

            // assert
            DateTime res = new DateTime(2015, 05, 14, 1, 15, 33, 0);
            Assert.AreEqual(res, res1);
            Assert.AreEqual(res, res2);
        }
    }
}
