using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace core_api.Models
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long QId { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public string MaxMax { get; set; }

        public string NumberOfQuestion { get; set; }

        public bool Active { get; set; }

        public long CategoryId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<Question> Questions { get; set; } = new HashSet<Question>();
    }
}
