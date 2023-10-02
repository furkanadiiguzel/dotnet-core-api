using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace core_api.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long QuesId { get; set; }
        
        public string Content { get; set; }
        
        public string Image { get; set; }
        
        public string Option1 { get; set; }
        
        public string Option2 { get; set; }
        
        public string Option3 { get; set; }
        
        public string Option4 { get; set; }
        
        [JsonIgnore]
        public string Answer { get; set; }

        [NotMapped]
        public string GivenAnswer { get; set; }

        public long QuizId { get; set; }
        
        [JsonIgnore]
        public virtual Quiz Quiz { get; set; }
    }
}
