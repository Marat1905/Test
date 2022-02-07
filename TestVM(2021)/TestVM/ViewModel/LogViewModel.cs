using System;
using System.Collections.Generic;
using System.Text;
using TestVM.Class;
using TestVM.MVVM;

namespace TestVM.ViewModel
{
   public class LogViewModel:BaseInpc
    {

        private FaultDirection _fatality;
        public FaultDirection Fatality { get => _fatality; set => Set(ref _fatality, value); }

        private string _messadge;
        public string Messadge { get => _messadge; set => Set(ref _messadge, value); }

        private string _mesto;
        public string Mesto { get => _mesto; set => Set(ref _mesto, value); }

        private string _comentariy;
        public string Comentariy { get => _comentariy; set => Set(ref _comentariy, value); }

        private DateTime _time;
        public DateTime Time { get => _time; set => Set(ref _time, value); }

        public FaultDirection FDirection { get; private set; }

    }
}
