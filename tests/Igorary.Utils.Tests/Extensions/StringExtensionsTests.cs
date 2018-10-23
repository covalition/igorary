using Covalition.Igorary.Utils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void IsEmpty() {
            string s1 = null, s2 = "", s3 = " ", s4 = "a";

            Assert.AreEqual(true, s1.IsEmpty());
            Assert.AreEqual(true, s2.IsEmpty());
            Assert.AreEqual(true, s3.IsEmpty());
            Assert.AreEqual(false, s4.IsEmpty());
        }
     }
}
