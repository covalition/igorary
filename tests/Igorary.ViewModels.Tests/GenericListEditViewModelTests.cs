using System;
using Igorary.ViewModels.Tests.TestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Igorary.ViewModels.Tests
{
    [TestClass]
    public class GenericListEditViewModelTests
    {
        [TestMethod]
        public void ShouldBeInValidStateWhenEmpty() {
            // arrange
            TestEmptyListEditViewModel viewModel = new TestEmptyListEditViewModel();

            // act

            // assert
            Assert.IsNull(viewModel.Fields, "The 'Fields' property should empty at start");
        }

        [TestMethod]
        public void ShouldThrowException() {
            // arrange
            TestExceptionListEditViewModel viewModel = new TestExceptionListEditViewModel();

            //assert
            Assert.IsTrue(viewModel.ExceptionThrown);
        }
    }
}
