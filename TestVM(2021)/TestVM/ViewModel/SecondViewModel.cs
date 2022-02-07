using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace TestVM.ViewModel
{
   public class SecondViewModel
    {
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        private readonly DispatcherTimer Timer_ReadConnecting = new DispatcherTimer();// Для подключения

        public SecondViewModel()
        {
            // Запускаем таймер 
            Timer_ReadConnecting.Start();
            Timer_ReadConnecting.Interval = TimeSpan.FromSeconds(10);
            Timer_ReadConnecting.Tick += Timer_ReadConnecting_Tick;
        }
       
        private void Timer_ReadConnecting_Tick(object sender, EventArgs e)
        {
            // Как Отсюда отправить запись в лог на основную VM?





            //Application.Current.Dispatcher.Invoke(() =>
            //{
            //    AddLogs(new LogViewModel()
            //    {
            //        Time = DateTime.Now,
            //        Fatality = FaultDirection.Info,
            //        Messadge = $"Пишем из второстепенной модели",
            //        Mesto = "Second",
            //    });
            //});
        }
    }
}
