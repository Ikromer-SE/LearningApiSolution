using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningApi.Data
{
    public class LearningItem
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Competency { get; set; }
        public string Notes { get; set; }
    }
}
