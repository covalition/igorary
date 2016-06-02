using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Igorary.ViewModels
{
    public class LabeledFieldViewModel: ViewModelBase
    {
        public LabeledFieldViewModel(string label) {
            _label = label;
        }

        private string _label;

        public string Label {
            get {
                return _label;
            }
            private set {
                if (value != _label) {
                    _label = value;
                    RaisePropertyChanged(() => Label);
                }
            }
        }
    }
}
