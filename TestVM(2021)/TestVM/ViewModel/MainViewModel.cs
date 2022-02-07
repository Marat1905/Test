using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using TestVM.Class;
using TestVM.MVVM;

namespace TestVM.ViewModel
{
   public class MainViewModel: BaseInpc
    {
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        private readonly DispatcherTimer Timer_ReadConnecting = new DispatcherTimer();// Для подключения

        public MainViewModel()
        {
            Logs = new ObservableCollection<LogViewModel>();
            // Запускаем таймер 
            Timer_ReadConnecting.Start();
            Timer_ReadConnecting.Interval = TimeSpan.FromSeconds(10);
            Timer_ReadConnecting.Tick += Timer_ReadConnecting_Tick;
            // торостепенная модель
            SecondVM = new SecondViewModel();
        }

        //для ЛОГОВ
        private ObservableCollection<LogViewModel> _logs;
        public ObservableCollection<LogViewModel> Logs { get => _logs; set => Set(ref _logs, value); }
        public void AddLogs(LogViewModel log)
        {
            Logs.Add(log);
            Logs.OrderByDescending(o => o.Time);
        }

        private SecondViewModel _secondVM;
        public SecondViewModel SecondVM { get => _secondVM; set => Set(ref _secondVM, value); }

        private void Timer_ReadConnecting_Tick(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                AddLogs(new LogViewModel()
                {
                    Time = DateTime.Now,
                    Fatality = FaultDirection.Info,
                    Messadge = $"Пишем из основной модели",
                    Mesto = "Main",
                });
            });
        }
    }
}
