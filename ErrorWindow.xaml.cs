using System.Windows;

namespace Weather_Checker
{
    public partial class ErrorWindow : Window
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void OK_ButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}