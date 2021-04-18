using System;
using System.Data.Common;

namespace HyejinMarichal.Todolists.Database
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

    }
}