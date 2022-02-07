using System;
using System.Collections.Generic;
using System.Text;

namespace TestVM.Class
{
    /// <summary> Класс для логов чтоб выбрать цвет </summary>
    public enum FaultDirection
    {
        Error, Info
    }
    /// <summary> Класс для логов чтоб выбрать название</summary>
    public static class FaultDirectionString
    {
        public static string Error = "Error";

        public static string Info = "Info";
    }
}
