﻿using Lanz.TodoList.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lanz.TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        public static IList<TodoItemModel> TodoItems { get; set; } = new List<TodoItemModel> { new TodoItemModel { Id  = 1, Title = "Title 1" }, new TodoItemModel { Id = 2, Title = "Title 2" } };

        // GET: api/<TodoItemController>
        [HttpGet]
        public IEnumerable<TodoItemModel> Get()
        {
            return TodoItems;
        }

        // GET api/<TodoItemController>/5
        [HttpGet("{id}")]
        public TodoItemModel Get(int id)
        {
            return TodoItems.FirstOrDefault(x => x.Id == id);
        }

        // POST api/<TodoItemController>
        [HttpPost]
        public TodoItemModel Post([FromBody] TodoItemModel todoItem)
        {
            todoItem.Id = TodoItems.Max(x => x.Id) + 1;
            TodoItems.Add(todoItem);
            return todoItem;
        }

        // PUT api/<TodoItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TodoItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
