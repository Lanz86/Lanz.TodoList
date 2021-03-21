using Lanz.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanz.TodoList.WebApp.Services
{
    public interface ITodoItemDataService
    {
        Task<IEnumerable<TodoItemModel>> Get();
        Task<TodoItemModel> Get(int id);
        Task<TodoItemModel> Add(TodoItemModel todoItem);
        Task<bool> Delete(TodoItemModel todoItem);
    }
}
