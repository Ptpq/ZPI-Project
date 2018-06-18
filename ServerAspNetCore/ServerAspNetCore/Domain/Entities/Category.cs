

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerAspNetCore.Domain.Entities
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }
        [Required, MaxLength(60)]
        public string CategoryName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
