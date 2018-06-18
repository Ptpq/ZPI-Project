using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerAspNetCore.Domain.Entities
{
    public class Tag
    {
        [Key]
        public int IdTag { get; set; }
        [Required,MaxLength(25)]
        public string Name { get; set; }
        public virtual ICollection<CourseTag> CoursesTag { get; set; }
    }
}
