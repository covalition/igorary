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

        [TestMethod]
        public void ShouldBeInValidStateAfterSelectItem() {
            // arrange
            TestOneListEditViewModel viewModel = new TestOneListEditViewModel();

            // act
            viewModel.SelectedItemIndex = 0;

            // assert
            Assert.IsFalse(viewModel.SaveCommand.CanExecute(null));
            Assert.IsFalse(viewModel.CancelCommand.CanExecute(null));
            Assert.IsTrue(viewModel.NewCommand.CanExecute(null));
            Assert.IsTrue(viewModel.DeleteCommand.CanExecute(null));
        }

        [TestMethod]
        public void ShouldBeInValidStateAfterModified() {
            // arrange
            TestOneListEditViewModel viewModel = new TestOneListEditViewModel();

            // act
            viewModel.SelectedItemIndex = 0;
            viewModel.Modified = true;

            // assert
            Assert.IsTrue(viewModel.SaveCommand.CanExecute(null));
            Assert.IsTrue(viewModel.CancelCommand.CanExecute(null));
            Assert.IsFalse(viewModel.NewCommand.CanExecute(null));
            Assert.IsFalse(viewModel.DeleteCommand.CanExecute(null));
        }
    }
}
