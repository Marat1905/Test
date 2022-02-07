using Simplified;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace Test.Dto
{
    public class LabDto : BaseInpc, IDataErrorInfo
    {
        /// <summary>ID записи</summary>
        public int Id { get; set; }
        /// <summary>Вес заданной продукции</summary>
        public double? BaseWeight { get; set; }
        /// <summary>Марка</summary>
        public string ProductBrand { get; set; }
        /// <summary>Измеренный вес лицо</summary>
        public double? BaseWeightLFace { get; set; }
        /// <summary>Измеренный вес середина</summary>
        public double? BaseWeightLMid { get; set; }

        public int TamId { get; set; }

        // для предупреждений
        public string Error => string.Join(Environment.NewLine,
           errors
           .Where(pair => !string.IsNullOrWhiteSpace(pair.Value))
           .Select(pair => $"{pair.Key}: \"{pair.Value}\""));

        public string this[string columnName]
        {
            get
            {

                string error = null;

                // Вес по ширине
                if (columnName == nameof(BaseWeight))
                {
                    if (BaseWeight != null )
                    {
                        if (20 < BaseWeight)
                        {
                            error = "Базовый вес выше нормы: 20 г/м2";
                        }
                        else if (10 > BaseWeight)
                        {
                            error = "Базовый вес ниже нормы: 10 г/м2";
                        }
                    }
                }



                if (string.IsNullOrWhiteSpace(error))
                {
                    if (errors.ContainsKey(columnName))
                        errors.Remove(columnName);
                }
                else
                    errors[columnName] = error;

                return error;
            }
        }

        private readonly Dictionary<string, string> errors = new Dictionary<string, string>();
        // для подсчета кол-ва не забитых данных для валидации
        public void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                ((Control)sender).ToolTip = e.Error.ErrorContent.ToString();
                //_errors++;
            }
            else
            {
                if (!((BindingExpressionBase)e.Error.BindingInError).HasError)
                {
                    ((Control)sender).ToolTip = "";
                    //_errors--;
                }

            }
        }
    }
}
