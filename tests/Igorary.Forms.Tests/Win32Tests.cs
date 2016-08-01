using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Igorary.Forms.Tests
{
    [TestClass]
    public class Win32Tests
    {
        [TestMethod]
        public void GetFolderIconTest() {
            string fullPath = "c:\\";
            Win32.FileIconSize size = Win32.FileIconSize.Large;
            Icon actual;
            actual = Win32.GetFolderIcon(fullPath, size);
            Assert.AreNotEqual(null, actual);
        }
    }
}
