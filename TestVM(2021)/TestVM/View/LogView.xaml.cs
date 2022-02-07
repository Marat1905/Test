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
using TestVM.ViewModel;

namespace TestVM.View
{
    /// <summary>
    /// Логика взаимодействия для LogView.xaml
    /// </summary>
    public partial class LogView : UserControl
    {
        public LogView()
        {
            InitializeComponent();
        }

        private void CollectionViewSource_FilterLogs(object sender, FilterEventArgs e)
        {

            var obj = e.Item as LogViewModel;
            e.Accepted = true;
            //if (obj != null)
            //{
            //    //Text_all.Content = null;
            //    if (Text_filterLogs != null)
            //    {
            //        if (obj.Mesto.ToString() == Text_filterLogs)
            //        {
            //            if (obj.Comentariy != null)
            //            {
            //                e.Accepted = true;
            //                Text_count = text_count + 1;
            //                Text_decimal = Text_decimal + Convert.ToDecimal(obj.Comentariy);
            //                Text_all.Content = "Кол-во: " + text_count + "; Счет: " + Math.Round(text_decimal, 2);
            //            }
            //        }
            //        else
            //        {
            //            e.Accepted = false;
            //            ////Text_all.Content = null;
            //        }



            //    }
            //    else
            //    {
            //        e.Accepted = true;
            //        Text_all.Content = "";
            //    }



        }
    }
}
