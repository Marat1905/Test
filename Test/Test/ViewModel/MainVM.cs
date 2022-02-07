using Simplified;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Test.Class;
using Test.Model;

namespace Test.ViewModel
{
    public class MainVM : BaseInpc
    {
        // для создания лабораторных показателей
        public ICommand InsertLabCommand { get; set; }
        public ICommand UpdateLabCommand { get; set; }
        private readonly Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        public MainVM()
        {
            var rez = TambModel.NewCreatTamp();
            TambAllAsync();
            InsertLabCommand = new DelegateCommand(InsertLabOpen);
            UpdateLabCommand = new DelegateCommand(UpdateLab);
        }
        //// за текущую смену
        //private List<Tamb> _AllTambSource=new List<Tamb>();
        public ObservableCollection<Tamb> AllTambSource { get; } /*{ get => _AllTambSource; set => Set(ref _AllTambSource, value); }*/
            = new ObservableCollection<Tamb>();
        // читаем 
        private async void TambAllAsync()
        {
            try
            {
                var TambAll = await TambModel.GetAllTambAsync();
                AllTambSource.Clear();
                var result = dispatcher.BeginInvoke(new Action(() =>
                {
                    foreach (var labAll in TambAll)
                        AllTambSource.Add(labAll);
                }));
                await result.Task;
            }
            catch (Exception)
            {
                // Здесь вывод об ошибке
            }
        }
        // для создания  показателей
        public void InsertLabOpen(object o)
        {
            var order = (Tamb)o;
            OpenInsertLabaratorWindowMethod(order);
        }
        public void UpdateLab(object o)
        {
            var order = (Lab)o;
            var d = order.Id;

            OpenUpdateLabaratorWindowMethod(order);
        }
        // мет
        // од для добавления показателей
        private async void OpenInsertLabaratorWindowMethod(Tamb laborator)
        {
            InsertLab labInsert = new InsertLab(laborator);
            labInsert.DataContext = new InsertLabVM();
            SetCenterPositionAndOpen(labInsert);
            TambAllAsync();
            //SmenaMetsoTamburs = await TamburModel.GetAllMetsoTambursAsync(Accounts[0].StartSmena, Accounts[0].EndSmena);

        }

        private async void OpenUpdateLabaratorWindowMethod(Lab laborator)
        {

            UpdateLab tamburUpdate = new UpdateLab(laborator);
            tamburUpdate.DataContext = new UpdateLabVM();
            SetCenterPositionAndOpen(tamburUpdate);
            //SmenaMetsoTamburs = await TamburModel.GetAllMetsoTambursAsync(Accounts[0].StartSmena, Accounts[0].EndSmena);
        }
        // Для экранов чтоб открывать по центру
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();

        }
    }
}
