using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TestVM.MVVM;

namespace TestVM.ViewModel
{
    public class OneViewModel : BaseInpc, IDataErrorInfo
    {
        private string _symbolAutoPare;
        private string _chosenStrategy;
        private int _count_error;
        /// <summary> Выбор пары  </summary>
        public string SymbolPare { get => _symbolAutoPare; set => Set(ref _symbolAutoPare, value); }

        /// <summary>  Выбор стратегии</summary>
        public string ChosenStrateg { get => _chosenStrategy; set => Set(ref _chosenStrategy, value); }

        /// <summary> Кол-во ошибок</summary>
        public int Count_error { get => _count_error; set => Set(ref _count_error, value); }


        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case nameof(SymbolPare):

                        if (string.IsNullOrEmpty(SymbolPare))
                            error = "Не выбранна пара";

                        break;


                    case nameof(ChosenStrateg):
                        if (string.IsNullOrEmpty(ChosenStrateg))
                            error = "Не выбранна стратегия";
                        break;
                    default:
                        break;
                }

                if (string.IsNullOrWhiteSpace(error))
                {
                    if (errors.ContainsKey(columnName))
                        errors.Remove(columnName);
                }
                else
                    errors[columnName] = error;
                Count_error = errors.Count;

                return error;
            }
        }
        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();
        public string Error => string.Join(Environment.NewLine, errors
                                     .Where(pair => !string.IsNullOrWhiteSpace(pair.Value))
                                     .Select(pair => $"{pair.Key}: \"{pair.Value}\""));

    }
}
