using System.Collections.Generic;
using core_api.Models; 

namespace core_api.Dtos
{
    public class ResultQuestionDto
    {
        public bool Success { get; set; }
        
        public List<string> Errors { get; set; }
        
        public Question Question { get; set; }
    }
}
