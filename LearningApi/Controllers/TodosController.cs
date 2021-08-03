using LearningApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningApi.Controllers
{
    public class TodosController: ControllerBase
    {
        private readonly LearningDataContext _context;

        public TodosController(LearningDataContext context)
        {
            _context = context;
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
}
