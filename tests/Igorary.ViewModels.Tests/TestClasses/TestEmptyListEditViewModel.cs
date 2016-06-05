using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Igorary.ViewModels;

namespace Igorary.ViewModels.Tests.TestClasses
{
    class TestEmptyListEditViewModel : GenericListEditViewModel<TestListItemViewModel>
    {
        protected override Task Delete() {
            throw new NotImplementedException();
        }

        protected override async Task<List<LabeledFieldViewModel>> LoadFields() {
            return new List<LabeledFieldViewModel>();
        }

        protected override async Task<IEnumerable<TestListItemViewModel>> LoadItems() {
            return new List<TestListItemViewModel>();
        }

        protected override Task<int> Save() {
            throw new NotImplementedException();
        }

        protected override void OnException(Exception ex) {
            throw new NotImplementedException();
        }
    }
}
