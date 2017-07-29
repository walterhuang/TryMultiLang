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

namespace TryMultiLang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Application.Current.FindResource("AuthenticationSuccessful").ToString());
        }

        private void LanguageSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedText = ((ComboBoxItem)LanguageSelector.SelectedItem).Content.ToString();
            var selectedLanguage = Application.Current.Resources.MergedDictionaries
                .Where(d => d.Source.OriginalString.Contains(selectedText)).SingleOrDefault();

            if (selectedLanguage == null) return;

            Application.Current.Resources.MergedDictionaries.Remove(selectedLanguage);
            Application.Current.Resources.MergedDictionaries.Add(selectedLanguage);
        }
    }
}