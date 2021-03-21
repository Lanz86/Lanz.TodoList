using Lanz.TodoList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Lanz.TodoList.WebApp.Services
{
    public class TodoItemDataService : ITodoItemDataService
    {
        private readonly HttpClient _httpClient;
        private const string TODO_ITEM_ENDPOINT = "/api/todoitems";

        public TodoItemDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<IEnumerable<TodoItemModel>> Get()
        {
            return _httpClient.GetFromJsonAsync<IEnumerable<TodoItemModel>>(TODO_ITEM_ENDPOINT);
        }

        public Task<TodoItemModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoItemModel> Add(TodoItemModel todoItem)
        {
            try
            {
                if (todoItem == null) return null;
                
                var response = await _httpClient.PostAsJsonAsync<TodoItemModel>(TODO_ITEM_ENDPOINT, todoItem);

                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TodoItemModel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            return null;
        }

        public async Task<bool> Delete(TodoItemModel todoItem)
        {
            if (todoItem == null) return false;

            try
            {
                var response = await _httpClient.DeleteAsync($"{TODO_ITEM_ENDPOINT}/{todoItem.Id}");

                return response.IsSuccessStatusCode;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
