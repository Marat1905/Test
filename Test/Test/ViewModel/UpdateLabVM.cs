using Simplified;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Test.Dto;
using Test.Model;

namespace Test.ViewModel
{
   public class UpdateLabVM:BaseInpc
    {
        // добавленные показатели
        public static Lab Tambur { get; set; }
        //Наша коллекция
        private LabDto _Laborators = new LabDto();
        public LabDto Laborators
        {
            get => _Laborators;
            set => Set(ref _Laborators, value);
        }

        private RelayCommand _UpdateCommand;
        public RelayCommand UpdateCommand => _UpdateCommand
            ?? (_UpdateCommand = new RelayCommand(UpdateExecute, UpdateCanExecute));

        private bool UpdateCanExecute()
        {
            // Здесь проверка правильности всех данных
            // если данные правильные, то возвращается истина

            return true;
        }

        private void UpdateExecute()
        {


            var res = TambModel.UpdateLab(Laborators);

            string caption = "Подтверждение!!!";
            MessageBoxButton buttons = MessageBoxButton.OK;
            string message = res;
            //Displays the MessageBox.
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

        public UpdateLabVM()
        {
            Laborators.Id = Tambur.Id;
            Laborators.BaseWeight = Tambur.BaseWeight;
            Laborators.ProductBrand = Tambur.ProductBrand;
            Laborators.BaseWeightLFace = Tambur.BaseWeightLFace;
            Laborators.BaseWeightLMid = Tambur.BaseWeightLMid;
            Laborators.TamId = Tambur.Id;


        }
    }
}
