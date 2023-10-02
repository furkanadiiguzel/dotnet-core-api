using System.Collections.Generic;
using core_api.Models; // Import your models

namespace core_api.Dtos
{
    public class ResultQuizDto
    {
        public bool Success { get; set; }
        
        public List<string> Errors { get; set; }
        
        public Quiz Quiz { get; set; }
    }
}
