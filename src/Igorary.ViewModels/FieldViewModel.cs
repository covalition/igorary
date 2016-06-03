using System;
using GalaSoft.MvvmLight;

namespace Igorary.ViewModels
{
    public class FieldViewModel<TValue> : LabeledFieldViewModel 
        where TValue : IComparable 
    {
        ModifiableViewModel _parent;

        public FieldViewModel(string label, ModifiableViewModel parent): base(label) {
            _parent = parent;
        }

        private TValue _value;

        public TValue Value {
            get {
                return _value;
            }
            set {
                if (value.CompareTo(_value) != 0) {
                    _value = value;
                    RaisePropertyChanged(() => Value);
                    _parent.Modified = true;
                }
            }
        }
    }
}