using ReactiveUI;
using System.Reactive;
using ToDoList.Models;

namespace ToDoList.ViewModels
{
    public class AddViewModel : ViewModelBase
    {
        private string title;
        private string description;
        private Liststruct lastItem = new Liststruct("", "");
        public Liststruct Item = new Liststruct("", "");
        public AddViewModel(Liststruct item) : this()
        {
            Item = item;
            lastItem = (Liststruct)item.Clone();
            Title = Item.Title;
            Description = Item.Description;
        }
        public AddViewModel()
        {
            var msgEnabled = this.WhenAnyValue(
                msg => msg.Title,
                msg => !string.IsNullOrWhiteSpace(msg)
            );

            Send = ReactiveCommand.Create(() => new Liststruct(Title, Description), msgEnabled);
            Cancel = ReactiveCommand.Create(() => {
                Item.Title = lastItem.Title;
                Item.Description = lastItem.Description;
            });
        }
        public ReactiveCommand<Unit, Liststruct> Send { get; set; }
        public ReactiveCommand<Unit, Unit> Cancel { get; set; }

        public string Title
        {
            get => title;
            set
            {
                Item.Title = value;
                this.RaiseAndSetIfChanged(ref title, value);
            }
        }
        public string Description
        {
            get => description;
            set
            {
                Item.Description = value;
                this.RaiseAndSetIfChanged(ref description, value);
            }
        }

    }
}