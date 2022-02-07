using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Simplified
{
    /// <summary>Базовый класс с реализацией <see cref="INotifyPropertyChanged"/> 
    /// и асинхронным уведомлением слушателей <see cref="PropertyChanged"/>.</summary>
    public abstract class BaseInpcAsync : INotifyPropertyChanged
    {

        // Поле со списком обработчиков
        private readonly List<PropertyChangedEventHandler> propertyChangedHandlers
            = new List<PropertyChangedEventHandler>();

        /// <inheritdoc cref="INotifyPropertyChanged"/>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (value != null)
                    lock (propertyChangedHandlers)
                        propertyChangedHandlers.Add(value);
            }

            remove
            {
                lock (propertyChangedHandlers)
                    propertyChangedHandlers.Remove(value);
            }
        }

        /// <summary>Защищённый метод для создания события <see cref="PropertyChanged"/>.</summary>
        /// <param name="propertyName">Имя изменившегося свойства. 
        /// Если значение не задано, то используется имя метода в котором был вызов.</param>
        /// <remarks>Вызов обработчиков выполняется параллельно - каждый в своей отдельной задаче.</remarks>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            lock (propertyChangedHandlers)
                if (propertyChangedHandlers.Count > 0)
                {
                    PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                    Parallel.ForEach(propertyChangedHandlers, handler => handler(this, args));
                }
        }

        /// <summary>Защищённый метод для присвоения значения полю и
        /// создания события <see cref="PropertyChanged"/>.</summary>
        /// <typeparam name="T">Тип поля и присваиваемого значения.</typeparam>
        /// <param name="propertyFiled">Ссылка на поле.</param>
        /// <param name="newValue">Присваиваемое значение.</param>
        /// <param name="propertyName">Имя изменившегося свойства. 
        /// Если значение не задано, то используется имя метода в котором был вызов.</param>
        /// <remarks>Метод предназначен для использования в сеттере свойства.<br/>
        /// Для проверки на изменение используется метод <see cref="object.Equals(object, object)"/>.
        /// Если присваиваемое значение не эквивалентно значению поля, то оно присваивается полю.<br/>
        /// После присвоения создаётся событие <see cref="PropertyChanged"/> вызовом
        /// метода <see cref="RaisePropertyChanged(string)"/>
        /// с передачей ему параметра <paramref name="propertyName"/>.<br/>
        /// После создания события вызывается метод <see cref="OnPropertyChanged(string, object, object)"/>.</remarks>
        protected void Set<T>(ref T propertyFiled, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(propertyFiled, newValue))
            {
                T oldValue = propertyFiled;
                propertyFiled = newValue;
                RaisePropertyChanged(propertyName);

                OnPropertyChanged(propertyName, oldValue, newValue);
            }
        }

        /// <summary>Защищённый виртуальный метод вызывается после присвоения значения
        /// свойству и после создания события <see cref="PropertyChanged"/>.</summary>
        /// <param name="propertyName">Имя изменившегося свойства.</param>
        /// <param name="oldValue">Старое значение свойства.</param>
        /// <param name="newValue">Новое значение свойства.</param>
        /// <remarks>Переопределяется в производных классах для реализации
        /// реакции на изменение значения свойства.<br/>
        /// Рекомендуется в переопределённом методе первым оператором вызывать базовый метод.<br/>
        /// Если в переопределённом методе не будет вызова базового, то возможно нежелательное изменение логики базового класса.</remarks>
        protected virtual void OnPropertyChanged(string propertyName, object oldValue, object newValue) { }
    }
}
