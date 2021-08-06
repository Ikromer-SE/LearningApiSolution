using LearningApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningApi.Controllers
{
    public class LearningController: ControllerBase
    {
        private readonly LearningDataContext _context;
        public LearningController(LearningDataContext context) {
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
    }
    public record LearningItemSummary(int Id, string Topic, string Competency, string Notes);
}
