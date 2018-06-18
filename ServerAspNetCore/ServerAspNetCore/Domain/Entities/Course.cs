using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ServerAspNetCore.Domain.Entities
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }
        [Required, MaxLength(60)]
        public string Title { get; set; }
        [Required, MaxLength(5000)]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        public virtual Category Category {get;set;}
    }
}
