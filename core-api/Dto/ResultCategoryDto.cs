using System.Collections.Generic;
using core_api.Models; 

public class ResultCategoryDto
{
    public bool Success { get; set; }
    
    public List<string> Errors { get; set; }
    
    public Category Category { get; set; }
}
