using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#if WINDOWS_UWP
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Popups;
using Windows.UI.Xaml.Input;
#else
using System.Windows.Controls;
#endif

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

#if WINDOWS_UWP

        protected override async void OnTapped(TappedRoutedEventArgs e) {
            if (ConfirmationMessage == null || await confirmed())
                base.OnTapped(e);
        }

        private async Task<bool> confirmed() {
            MessageDialog dlg = new MessageDialog(ConfirmationMessage);
            dlg.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dlg.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            IUICommand res = await dlg.ShowAsync();
            return (int)res.Id == 0;
        }

#else

        protected override void OnClick() {
            if(ConfirmationMessage == null || MessageBox.Show(ConfirmationMessage, Application.Current?.MainWindow?.Title, MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                base.OnClick();
        }

#endif
    }
}
