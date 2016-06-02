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
        private string _label;

        public string Label {
            get {
                return _label;
            }
            set {
                if (value != _label) {
                    _label = value;
                    RaisePropertyChanged(() => Label);
                }
            }
        }
    }
}
