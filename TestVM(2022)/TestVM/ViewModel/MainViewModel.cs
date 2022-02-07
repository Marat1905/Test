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
        public OneViewModel OneVM { get; } = new OneViewModel();
        public SecondViewModel SecondVM { get; } = new SecondViewModel();
        public MainViewModel()
        {
 
            
        }

        public IReadOnlyList<string> StrategSource { get; }
         = new List<string>
         {
                "Стратегия №1",
                "Стратегия №2",
         }
         .AsReadOnly();
        public IReadOnlyList<string> SymbolSource { get; }
        = new List<string>
        {
                "Символ №1",
                "Символ №2",
        }
        .AsReadOnly();
    }
}
