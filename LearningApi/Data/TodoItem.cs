using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningApi.Data
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime WhenAdded { get; set; }
    }

}
