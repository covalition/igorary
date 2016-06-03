using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Igorary.ViewModels
{
    public abstract class ModifiableViewModel: ViewModelBase
    {
        private bool _modified = false;

        public bool Modified {
            get {
                return _modified;
            }
            set {
                if (value != _modified) {
                    _modified = value;
                    RaisePropertyChanged(() => Modified);
                    OnModifiedChange();
                }
            }
        }

        protected virtual void OnModifiedChange() {
        }
    }
}
