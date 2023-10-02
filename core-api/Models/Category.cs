using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_api.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
