using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Model
{
   public class Tamb
    {
        /// <summary>ID тамбура</summary>
        public int Id { get; set; }
        /// <summary>Заданный базовый вес</summary>
        public double? WeightMainRef { get; set; }
        /// <summary>Измеренный базовый вес</summary>
        public double? WeightMainAct { get; set; }
        /// <summary>Заданный сухой вес</summary>
        public double? WeightDryRef { get; set; }
        /// <summary>Измеренный сухой вес</summary>
        public double? WeightDryAct { get; set; }

        public List<Lab> Lab { get; set; }

    }
}
