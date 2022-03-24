using System;

namespace ToDoList.Models
{
    public class Liststruct : ICloneable
    {
        private string title = "";
        private string description = "";
        private DateTimeOffset? date;
        public Liststruct(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.date = DateTime.Now;
        }
        public string Title
        {
            get => title;
            set
            {
                if (value != null)
                {
                    title = value;
                }
            }
        }
        public string Description
        {
            get => description;
            set
            {
                if (value != null)
                {
                    description = value;
                }
            }
        }
        public DateTimeOffset? Date
        {
            get => date;
            set
            {
                date = value;
            }
        }
        public object Clone()
        {
            return new Liststruct(title, description);
        }
    }

}