using Lanz.TodoList.Models;
using Lanz.TodoList.WebApp.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanz.TodoList.WebApp.Pages
{
    public partial class Todo
    {
        [Inject]
        private ITodoItemDataService todoItemDataService { get; set; }

        private List<TodoItemModel> todos = null;

        private string newTodoTitle;
        private bool showAll { get; set; } = false;

        protected async override Task OnInitializedAsync()
        {
            todos = (await todoItemDataService.Get()).ToList();
        }

        private async void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(newTodoTitle))
            {
                var todoItem = new TodoItemModel() { Title = newTodoTitle };
                var responseTodoItem = await todoItemDataService.Add(todoItem);


                if (responseTodoItem != null)
                {
                    todos.Add(responseTodoItem);
                }

                newTodoTitle = string.Empty;

                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
        }

        private async void DeleteTodo(TodoItemModel todoItemModel)
        {
            if (todoItemModel != null)
            {
                var result = await todoItemDataService.Delete(todoItemModel);

                if(result)
                {
                    todos.Remove(todos.FirstOrDefault(x => x.Id == todoItemModel.Id));

                    await InvokeAsync(() =>
                    {
                        StateHasChanged();
                    });
                }
            }
        }

        private void showAllItem()
        {
            showAll = !showAll;
        }
    }
}
