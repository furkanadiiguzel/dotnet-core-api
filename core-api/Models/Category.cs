using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_api.Models
{
    public class Category
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long CId { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public virtual ICollection<Quiz> Quizzes { get; set; }
    }
}
