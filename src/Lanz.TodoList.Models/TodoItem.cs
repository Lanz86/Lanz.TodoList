using System;
using System.Collections.Generic;
using System.Text;

namespace Lanz.TodoList.Models
{
    public class TodoItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
