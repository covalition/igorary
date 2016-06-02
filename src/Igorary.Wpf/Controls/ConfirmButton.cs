using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Igorary.Xaml.Controls
{
    public class ConfirmButton: Button
    {
        public string ConfirmationMessage {
            get { return (string)GetValue(ConfirmationMessageProperty); }
            set { SetValue(ConfirmationMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ConfirmationMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConfirmationMessageProperty =
            DependencyProperty.Register("ConfirmationMessage", typeof(string), typeof(ConfirmButton), new PropertyMetadata(null));

        protected override void OnClick() {
            if(ConfirmationMessage == null || MessageBox.Show(ConfirmationMessage, Application.Current?.MainWindow?.Title, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                base.OnClick();
        }
    }
}
