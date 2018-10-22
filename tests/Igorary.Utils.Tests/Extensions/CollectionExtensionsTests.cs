using Igorary.Utils.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Tests.Extensions
{
    [TestClass]
    public class CollectionExtensionsTests
    {
        [TestMethod]
        public void Register() {
            // arrange
            int n = 3;
            ICollection<int> collection = new Collection<int>();

            // act
            int res = collection.Register(n);

            // assert
            Assert.AreEqual(3, res);
        }
    }
}
