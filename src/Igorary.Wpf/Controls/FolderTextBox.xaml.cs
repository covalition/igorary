using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Igorary.Xaml.Controls
{
    /// <summary>
    /// Interaction logic for FolderTextBox.xaml
    /// </summary>
    public partial class FolderTextBox : UserControl
    {
        public FolderTextBox() {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, RoutedEventArgs e) {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            string startFolderPath = FolderPath;
            if (string.IsNullOrEmpty(startFolderPath))
                startFolderPath = StartFolderPath;
            if (string.IsNullOrEmpty(startFolderPath) && RememberLastFolder)
                startFolderPath = Properties.Settings.Default.LastSelectedFolder;
            dialog.SelectedPath = startFolderPath;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                tbFolderPath.Text = dialog.SelectedPath;
                BindingOperations.GetBindingExpression(tbFolderPath, TextBox.TextProperty).UpdateSource();
                if (RememberLastFolder) {
                    Properties.Settings.Default.LastSelectedFolder = dialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        public string FolderPath {
            get { return (string)GetValue(FolderPathProperty); }
            set { SetValue(FolderPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FolderPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FolderPathProperty =
            DependencyProperty.Register("FolderPath", typeof(string), typeof(FolderTextBox), new PropertyMetadata(null));

        public string StartFolderPath {
            get { return (string)GetValue(StartFolderPathProperty); }
            set { SetValue(StartFolderPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartFolderPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartFolderPathProperty =
            DependencyProperty.Register("StartFolderPath", typeof(string), typeof(FolderTextBox), new PropertyMetadata(null));

        public bool RememberLastFolder {
            get { return (bool)GetValue(RememberLastFolderProperty); }
            set { SetValue(RememberLastFolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RememberLastFolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RememberLastFolderProperty =
            DependencyProperty.Register("RememberLastFolder", typeof(bool), typeof(FolderTextBox), new PropertyMetadata(true));

    }
}
