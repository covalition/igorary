using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static Covalition.Igorary.Utils.DateTimeUtils;

namespace Igorary.Utils.Tests
{
    [TestClass]
    public class DateTimeUtilsTests
    {
        [TestMethod]
        public void TestOverlapRange_1() {
            // arrange
            DateTime a = new DateTime(2004, 07, 15);
            DateTime b = new DateTime(2006, 06, 06);
            DateTime c = new DateTime(2014, 01, 25);
            DateTime d = new DateTime(2023, 11, 02);

            // assert
            Assert.IsTrue(OverlapRange(a, c, b, d) == true);
            Assert.IsTrue(OverlapRange(a, b, c, d) == false);
        }

        [TestMethod]
        public void TestOverlapRange_2() {
            // arrange
            DateTime from1_1 = new DateTime(1999, 12, 1);
            DateTime to1_1 = new DateTime(2000, 1, 2);
            DateTime from1_2 = new DateTime(2000, 1, 2);
            DateTime to1_2 = new DateTime(2000, 1, 3);
            DateTime from1_3 = new DateTime(2001, 1, 2);
            DateTime to1_3 = new DateTime(2001, 1, 3);

            DateTime? from2_1 = new DateTime(2000, 1, 1);
            DateTime? to2_1 = new DateTime(2000, 1, 4);

            // assert
            Assert.IsTrue(OverlapRange(from1_1, to1_1, from2_1, to2_1));
            Assert.IsTrue(OverlapRange(from1_1, to1_1, null, to2_1));
            Assert.IsTrue(OverlapRange(from1_1, to1_1, from2_1, null));

            Assert.IsTrue(OverlapRange(from1_2, to1_2, from2_1, to2_1));
            Assert.IsTrue(OverlapRange(from1_2, to1_2, null, null));

            Assert.IsFalse(OverlapRange(from1_3, to1_3, from2_1, to2_1));
        }

        [TestMethod]
        public void TestGetTotalHours_0() {
            // arrange
            DateTime a = new DateTime(2004, 07, 15);
            DateTime b = new DateTime(2004, 07, 15);

            // assert
            Assert.AreEqual(0, GetTotalHours(a, b, null, null));
        }

        [TestMethod]
        public void TestGetTotalHours_1() {
            // arrange
            DateTime from1_1 = new DateTime(1999, 12, 1);
            DateTime to1_1 = new DateTime(2000, 1, 2);

            // assert
            Assert.AreEqual((to1_1 - from1_1).TotalHours, GetTotalHours(from1_1, to1_1, null, null));
        }

        [TestMethod]
        public void TestGetFraction() {
            // arrange
            DateTime from1_1 = new DateTime(2000, 1, 2);
            DateTime to1_1 = new DateTime(2000, 1, 4);
            DateTime? from2_1 = new DateTime(2000, 1, 1);
            DateTime? to2_1 = new DateTime(2000, 1, 5);
            DateTime? from2_2 = new DateTime(2000, 1, 3);
            DateTime? to2_2 = new DateTime(2000, 1, 5);

            // assert
            Assert.AreEqual(1, GetFraction(from1_1, to1_1, from2_1, to2_1));
            Assert.AreEqual(1, GetFraction(from1_1, to1_1, null, null));
            Assert.AreEqual(.5, GetFraction(from1_1, to1_1, from2_2, to2_2));
        }
    }
}
