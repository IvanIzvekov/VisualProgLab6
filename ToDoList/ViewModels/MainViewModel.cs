using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDoList.Models;
using ReactiveUI;

namespace ToDoList.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Liststruct newTitle;
        private DateTimeOffset? currentDate = DateTime.Today;
        private List<Liststruct> allItems = new List<Liststruct>();
        private List<Liststruct> currentItems = new List<Liststruct>();
        private ObservableCollection<Liststruct> items;
        public MainViewModel()
        {
            Items = new ObservableCollection<Liststruct>(allItems);
        }
        public ObservableCollection<Liststruct> Items
        {
            get => items;
            set
            {
                this.RaiseAndSetIfChanged(ref items, value);
            }
        }
        public Liststruct NewItem
        {
            get { return newTitle; }
            set
            {
                value.Date = currentDate;
                allItems.Add(value);
            }
        }
        public Liststruct DeleteItem
        {
            set
            {
                Items.Remove(value);
            }
        }
        public DateTimeOffset? CurrentDate
        {
            get { return currentDate; }
            set
            {
                currentDate = value;
                currentItems.Clear();
                foreach (var item in allItems)
                {
                    if (item.Date == currentDate)
                    {
                        currentItems.Add(item);
                    }
                }
                this.RaiseAndSetIfChanged(ref currentDate, value);
                Items = new ObservableCollection<Liststruct>(currentItems);
            }
        }
        private Liststruct[] BuildArray()
        {
            return new Liststruct[]
            {
                new Liststruct("1", "2"),
                new Liststruct("2", "2")
            };
        }
    }
}