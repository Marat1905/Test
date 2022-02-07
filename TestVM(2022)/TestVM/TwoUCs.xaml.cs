using System.Windows;
using System.Windows.Controls;

namespace TestVM
{
    /// <summary>
    /// Логика взаимодействия для TwoUCs.xaml
    /// </summary>
    public partial class TwoUCs : Window
    {
        public TwoUCs()
        {
            InitializeComponent();
        }

        private void OnSwap(object sender, RoutedEventArgs e)
        {
            UserControl one = (UserControl)FindResource(nameof(one));
            UserControl two = (UserControl)FindResource(nameof(two));
            if (presenter.Content != one)
            {
                presenter.Content = one;
            }
            else
            {
                presenter.Content = two;
            }
        }
    }
}
