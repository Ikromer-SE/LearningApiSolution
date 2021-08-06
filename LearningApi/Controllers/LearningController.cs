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
    public class LearningController : ControllerBase
    {
        private readonly LearningDataContext _context;
        public LearningController(LearningDataContext context)
        {
            _context = context;
        }

        [HttpGet("learningitems")]
        public async Task<ActionResult> GetAllItems()
        {
            var response = await _context.LearningItems
                .Select(item => new LearningItemSummary(item.Id, item.Topic, item.Competency, item.Notes))
                .ToListAsync();

            return Ok(new { data = response });
        }
        [HttpPost("learningitems")]
        public async Task<ActionResult> AddItem([FromBody] LearningCreateItem request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var itemToAdd = new LearningItem
                {
                    Topic = request.Topic,
                    Competency = request.Competency,
                    Notes = request.Notes
                };
                _context.LearningItems.Add(itemToAdd);
                await _context.SaveChangesAsync();

                var response = new LearningItemSummary(
                itemToAdd.Id, itemToAdd.Topic, itemToAdd.Competency, itemToAdd.Notes);

                return StatusCode(201, response);
            }
        }
    }

    public record LearningItemSummary(int Id, string Topic, string Competency, string Notes);
    public record LearningCreateItem
    {
        [Required]
        public string Topic { get; init; }
        [Required]
        public string Competency { get; init; }
        public string Notes { get; init; }
    }
}
