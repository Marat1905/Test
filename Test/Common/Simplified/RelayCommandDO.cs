using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using System.Windows.Threading;

namespace Simplified
{

    public class RelayCommandDO : ICommand
    {
        private readonly CanExecuteHandler canExecute;
        private readonly ExecuteHandler execute;
        private readonly EventHandler requerySuggested;

        /// <summary>Событие извещающее об изменении состояния команды.</summary>
        private readonly object lockCanExecuteChanged = new object();
        private event EventHandler PrivateCanExecuteChanged;
        private readonly Dictionary<Dispatcher, EventHandlerItem> doCanExecuteHandlers
            = new Dictionary<Dispatcher, EventHandlerItem>();
        public event EventHandler CanExecuteChanged
        {
            add
            {
                lock (lockCanExecuteChanged)
                {
                    DispatcherObject dObj = GetDispatcherObject(value);
                    if (dObj != null)
                    {
                        Dispatcher dispatcher = dObj.Dispatcher;
                        if (!doCanExecuteHandlers.TryGetValue(dispatcher, out EventHandlerItem item))
                        {
                            item = new EventHandlerItem();
                            doCanExecuteHandlers.Add(dispatcher, item);
                        }
                        item.EventsField += value;
                    }
                    else
                    {
                        PrivateCanExecuteChanged += value;
                    }
                }
            }
            remove
            {
                lock (lockCanExecuteChanged)
                {
                    DispatcherObject dObj = GetDispatcherObject(value);

                    if (dObj != null)
                    {
                        Dispatcher dispatcher = dObj.Dispatcher;
                        if (doCanExecuteHandlers.TryGetValue(dispatcher, out EventHandlerItem item))
                        {
                            item.EventsField -= value;
                        }
                    }
                    else
                    {
                        PrivateCanExecuteChanged -= value;
                    }
                }
            }
        }

        private class EventHandlerItem
        {
            public EventHandler EventsField;
        }

        /// <summary>Конструктор команды.</summary>
        /// <param name="execute">Выполняемый метод команды.</param>
        /// <param name="canExecute">Метод, возвращающий состояние команды.</param>
        public RelayCommandDO(ExecuteHandler execute, CanExecuteHandler canExecute = null)
            : this()
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;

            requerySuggested = (o, e) => RaiseCanExecuteChanged();
            CommandManager.RequerySuggested += requerySuggested;
        }

        /// <inheritdoc cref="RelayCommand(ExecuteHandler, CanExecuteHandler)"/>
        public RelayCommandDO(Action execute, Func<bool> canExecute = null)
                : this
                (
                      p => execute(),
                      p => canExecute?.Invoke() ?? true
                )
        { }

        protected RelayCommandDO()
            => actionInvalidate = handler => handler?.Invoke(this, EventArgs.Empty);

        /// <summary>Метод, подымающий событие <see cref="CanExecuteChanged"/>.</summary>
        public void RaiseCanExecuteChanged()
        {
            PrivateCanExecuteChanged?.Invoke(this, EventArgs.Empty);
            KeyValuePair<Dispatcher, EventHandlerItem>[] handlers;
            lock (lockCanExecuteChanged)
            {
                handlers = doCanExecuteHandlers.ToArray();
            }
            foreach (KeyValuePair<Dispatcher, EventHandlerItem> pair in handlers)
            {
                if (pair.Value.EventsField == null)
                    continue;
                if (pair.Key.CheckAccess())
                {
                    pair.Value.EventsField?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    _ = pair.Key.BeginInvoke(actionInvalidate, pair.Value.EventsField);
                }
            }
        }
        private readonly Action<EventHandler> actionInvalidate;

        /// <summary>Вызов метода, возвращающего состояние команды.</summary>
        /// <param name="parameter">Параметр команды.</param>
        /// <returns><see langword="true"/> - если выполнение команды разрешено.</returns>
        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        /// <summary>Вызов выполняющего метода команды.</summary>
        /// <param name="parameter">Параметр команды.</param>
        public void Execute(object parameter) => execute?.Invoke(parameter);

        private static readonly Type typeHandlerSink = typeof(CanExecuteChangedEventManager)
            .GetNestedType("HandlerSink", BindingFlags.NonPublic);

        private static readonly FieldInfo field_originalHandler = typeHandlerSink
            .GetField("_originalHandler", BindingFlags.Instance | BindingFlags.NonPublic);
        private static DispatcherObject GetDispatcherObject(EventHandler handler)
        {
            Debug.WriteLine("");
            for (int i = 0; i < 10; i++)
            {
                StackFrame frame = new StackFrame(i);
                Debug.Write(frame);
                Debug.WriteLine(frame.GetILOffset());
            }

            object target = handler.Target;
            if (target is DispatcherObject dObj)
            {
                return dObj;
            }

            if (handler.Target == null
                || !typeHandlerSink.IsAssignableFrom(target.GetType()))
            {
                return null;
            }
            else
            {
                EventHandler<EventArgs> origHand = (EventHandler<EventArgs>)((WeakReference)field_originalHandler.GetValue(target)).Target;
                return origHand?.Target as DispatcherObject;
            }
        }
    }

}
