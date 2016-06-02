using System;
using GalaSoft.MvvmLight;

namespace Igorary.ViewModels
{
    public class FieldViewModel<T>: LabeledFieldViewModel where T : IComparable
    {
        private T _value;

        public T Value {
            get {
                return _value;
            }
            set {
                if (value.CompareTo(_value) != 0) {
                    _value = value;
                    RaisePropertyChanged(() => Value);
                }
            }
        }
    }
}