using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerAspNetCore.Domain.Entities
{
    public class Raiting
    {
        [ForeignKey("Course")]
        public int IdCourse { get; set; }
        [ForeignKey("User")]
        public int IdUser { get; set; }
        public int Value { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual User User { get; set; }
    }
}
