using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestVM.View
{
    /// <summary>
    /// Логика взаимодействия для OneView.xaml
    /// </summary>
    public partial class OneView : UserControl
    {
        public OneView()
        {
            InitializeComponent();
            //Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var bindExpr = cBox1.GetBindingExpression(ComboBox.TextProperty);
            bindExpr.UpdateTarget();
            bindExpr = cBox2.GetBindingExpression(ComboBox.TextProperty);
            bindExpr.UpdateTarget();
       }
    }
}
