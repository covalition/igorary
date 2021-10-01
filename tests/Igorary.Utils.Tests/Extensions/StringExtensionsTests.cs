using Igorary.Utils.Extensions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Igorary.Utils.Tests.Extensions
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void IsEmpty()
        {
            string s1 = null, s2 = "", s3 = " ", s4 = "a";

            Assert.AreEqual(true, s1.IsEmpty());
            Assert.AreEqual(true, s2.IsEmpty());
            Assert.AreEqual(true, s3.IsEmpty());
            Assert.AreEqual(false, s4.IsEmpty());
        }

        [DataTestMethod]
        [DataRow("test string", "string", "new", "test new")]
        [DataRow("teststring", "string", "", "test")]
        [DataRow("test string", "", "new", "test string")]
        [DataRow("test test test test", "test", "new", "test test test new")]
        [DataRow("test test test test", "test2", "new", "test test test test")]
        [DataRow("test test test new", "test", "new", "test test new new")]
        [DataRow("", "", "new", "new")]
        [DataRow("", "test", "new", "")]
        [DataRow("test", "test", "new", "new")]
        public void ReplaceLast(string input, string oldValue, string newValue, string output)
        {
            Assert.AreEqual(output, input.ReplaceLast(oldValue, newValue));
        }

        [DataTestMethod]
        [DataRow("testString", "Test String")]
        [DataRow("TestString", "Test String")]
        [DataRow("", "")]
        [DataRow("TodayILiveInTheUSAWithSimon", "Today I Live In The USA With Simon")]
        [DataRow("String", "String")]
        [DataRow("string", "String")]
        [DataRow("S", "S")]
        public void ToTile(string input, string output)
        {
            Assert.AreEqual(output, input.ToTitle());
        }

        [DataTestMethod]
        [DataRow("testString", "test-string")]
        [DataRow("TestString", "test-string")]
        [DataRow("TestStringX", "test-string-x")]
        [DataRow("", "")]
        // [DataRow("TodayILiveInTheUSAWithSimon", "Today I Live In The USA With Simon")]
        [DataRow("String", "string")]
        [DataRow("string", "string")]
        [DataRow("S", "s")]
        public void ToIdentifierWithHyphens(string input, string output)
        {
            Assert.AreEqual(output, input.ToIdentifierWithHyphens());
        }

        [DataTestMethod]
        [DataRow("testString", 100, null, "testString")]
        [DataRow("testString", 4, "...", "test...")]
        [DataRow(null, 100, null, null)]
        [DataRow("testString", 4, null, "test")]
        public void Truncate(string input, int maxLenght, string ending, string output)
        {
            Assert.AreEqual(output, input.Truncate(maxLenght, ending));
        }

    }
}
