using Igorary.Utils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Tests.Extensions
{
    [TestClass]
    public class EnumExtensionsTests
    {
        const string ATestName = "ATestName";
        const string BTestName = "BTestName";

        enum Test
        {
            [Display(Name = ATestName)]
            A,

            [Display(Name = BTestName)]
            B,

            C
        }

        [TestMethod]
        public void GetDisplayName()
        {
            // assert
            Assert.AreEqual(ATestName, Test.A.GetDisplayName());
            Assert.AreEqual(BTestName, Test.B.GetDisplayName());
        }

        [TestMethod]
        public void GetDisplayNameForInvalidEnum()
        {
            // assert
            Assert.AreEqual("5", ((Test)5).GetDisplayName());
        }

        [TestMethod]
        public void In()
        {
            Assert.IsTrue(Test.A.In(Test.A, Test.B));
            Assert.IsFalse(Test.C.In(Test.A, Test.B));
        }
    }
}
