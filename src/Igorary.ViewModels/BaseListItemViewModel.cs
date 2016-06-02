using System;
using GalaSoft.MvvmLight;

namespace Igorary.ViewModels
{
    public class BaseListItemViewModel: ViewModelBase {

        private string _caption;

        public string Caption {
            get {
                return _caption;
            }
            set {
                if (value != _caption) {
                    _caption = value;
                    RaisePropertyChanged(() => Caption);
                }
            }
        }

    }
}