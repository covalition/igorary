using Igorary.Utils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Tests.Extensions
{
    [TestClass]
    public class IDictionaryExtensionsTests
    {
        [TestMethod]
        public void Find()
        {
            // arrange
            string s1 = "text";
            string k1 = "key1";
            string k2 = "key2";
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary[k1] = s1;

            // act
            string ret1 = dictionary.Find(k1);
            string ret2 = dictionary.Find(k2);

            // assert
            Assert.AreEqual(s1, ret1);
            Assert.AreEqual(null, ret2);

        }
    }
}
