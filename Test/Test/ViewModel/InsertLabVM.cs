using Simplified;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Test.Dto;
using Test.Model;

namespace Test.ViewModel
{
   public class InsertLabVM: BaseInpc
    {
        // ID Tamb
        public static int SelectedIDTamb { get; set; } // Внешний ключ к таблице MetsoTambur
        private LabDto _Laborators = new LabDto();
        public LabDto Laborators
        {
            get { return _Laborators; }
            set
            {
                Set(ref _Laborators, value);
            }
        }

        private RelayCommand _addInsertCommand;
        public RelayCommand AddInsertCommand => _addInsertCommand
            ?? (_addInsertCommand = new RelayCommand(AddInsertExecute, AddInsertCanExecute));

        private bool AddInsertCanExecute()
        {       
            // Здесь проверка правильности всех данных
            // если данные правильные, то возвращается истина

            return true;
        }

        private void AddInsertExecute()
        {
            var res = TambModel.CreatLab(Laborators);
            
            string caption = "Подтверждение!!!";
            MessageBoxButton buttons = MessageBoxButton.OK;
            string message = res;
            // Displays the MessageBox.
            var mess = MessageBox.Show(message, caption, buttons,
             MessageBoxImage.Question);
            if (mess == MessageBoxResult.OK)
            {
                // закрытие окошка.
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
            }

        }
        public InsertLabVM()
        {
            // Laborators.CollectionChanged += this.LaboratorsOnCollectionChanged;

                Laborators.TamId = SelectedIDTamb;




        }
    }
}
