using System;
using ToDoList.Models;
using ReactiveUI;
using System.Reactive.Linq;

namespace ToDoList.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase currentView;
        public MainWindowViewModel()
        {
            CurrentView = Fv = new MainViewModel();

        }
        public ViewModelBase CurrentView
        {
            get => currentView;
            set => this.RaiseAndSetIfChanged(ref currentView, value);
        }
        public MainViewModel Fv
        {
            get;
        }
        public void DeleteItem(Liststruct item)
        {
            Fv.DeleteItem = item;
        }
        public void ChangeViewOnItem(Liststruct item)
        {
            if (currentView is MainViewModel)
            {
                var vm = new AddViewModel(item);

                Observable.Merge(vm.Send, vm.Cancel.Select(_ => (Liststruct)null))
                    .Take(1)
                    .Subscribe(msg =>
                    {
                        CurrentView = Fv;
                    }
                );
                CurrentView = vm;
            }
            else if (currentView is AddViewModel)
            {
                CurrentView = new MainViewModel();
            }
        }
        public void ChangeView()
        {
            if (currentView is MainViewModel)
            {
                var vm = new AddViewModel();

                Observable.Merge(vm.Send, vm.Cancel.Select(_ => (Liststruct)null))
                    .Take(1)
                    .Subscribe(msg =>
                    {
                        if (msg != null)
                        {
                            Fv.NewItem = msg;
                        }
                        CurrentView = Fv;
                    }
                );
                CurrentView = vm;
            }
            else if (currentView is AddViewModel)
            {
                CurrentView = new MainViewModel();
            }
        }
    }
}