using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Covalition.Igorary.Mvc.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Covalition.Igorary.Mvc.Tests.Extensions
{
    [TestClass]
    public class DictionaryExtensionsTests
    {
        [TestMethod]
        public void ToSelectListItemsTest() {
            // arrange
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "val1");
            dict.Add(2, "val2");

            // act
            List<SelectListItem> items = dict.ToSelectListItems().ToList();

            // assert
            Assert.AreEqual(2, items.Count());
            Assert.AreEqual("val1", items[0].Text);
            Assert.AreEqual("val2", items[1].Text);
            Assert.AreEqual("1", items[0].Value);
            Assert.AreEqual("2", items[1].Value);
        }
    }
}
