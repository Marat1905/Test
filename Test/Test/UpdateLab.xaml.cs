using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Test.Model;
using Test.ViewModel;

namespace Test
{
    /// <summary>
    /// Логика взаимодействия для UpdateLab.xaml
    /// </summary>
    public partial class UpdateLab : Window
    {
        public UpdateLab(Lab laborators)
        {
            InitializeComponent();
            UpdateLabVM.Tambur = laborators;
            DataContextChanged += (s, e) => viewModels = (UpdateLabVM)e.NewValue;
        }
        private UpdateLabVM viewModels;
        // для фильтрации Double
        private void PreviewTextdoubleInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            ((Control)sender).InvalidateVisual();
        }
    }
}
