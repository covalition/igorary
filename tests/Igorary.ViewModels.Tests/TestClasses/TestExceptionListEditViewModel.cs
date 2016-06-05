using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.ViewModels.Tests.TestClasses
{
    class TestExceptionListEditViewModel : GenericListEditViewModel<TestListItemViewModel>
    {

        public bool ExceptionThrown = false;

        protected override void OnException(Exception ex) {
            ExceptionThrown = true;
        }

        protected override Task Delete() {
            throw new NotImplementedException();
        }

        protected override Task<List<LabeledFieldViewModel>> LoadFields() {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<TestListItemViewModel>> LoadItems() {
            throw new NotImplementedException();
        }

        protected override Task<int> Save() {
            throw new NotImplementedException();
        }
    }
}
