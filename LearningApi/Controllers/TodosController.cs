using LearningApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningApi.Controllers
{
    public class TodosController : ControllerBase
    {
        private readonly LearningDataContext _context;

        public TodosController(LearningDataContext context)
        {
            _context = context;
        }

        [HttpPost("todos")]
        public async Task<ActionResult> AddATodo([FromBody] PostTodoItemRequest request)
        {
            //validate the thing
            if (ModelState.IsValid)
            {
                //mapping!
                var todoItem = new TodoItem
                {
                    Description = request.description,
                    IsRemoved = false,
                    WhenAdded = DateTime.Now
                };
                _context.TodoItems.Add(todoItem);
                await _context.SaveChangesAsync();
                var response = new TodoItemModel(todoItem.Id, todoItem.Description);
                return StatusCode(201, response);
            } else
            {
                return BadRequest(ModelState);
            }
        }

        // GET /todos
        [HttpGet("todos")]
        public async Task<ActionResult> GetAllTodos()
        {
            var todos = await _context.TodoItems
                .Where(t => t.IsRemoved == false)
                .Select(t => new TodoItemModel(t.Id, t.Description))
                .ToListAsync();

            return Ok(new { data = todos });
        }
    }

    public record TodoItemModel(int Id, string Description);

    public class PostTodoItemRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(500)]
        public string description { get; set; }
    }
}
