using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Model
{
    public class Lab
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

        public int TambId { get; set; }
        public Tamb Tamb{ get; set; }

    }
}
