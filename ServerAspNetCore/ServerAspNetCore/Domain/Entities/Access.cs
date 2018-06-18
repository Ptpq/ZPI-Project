using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServerAspNetCore.Domain.Entities
{
    public class Access
    {
        [ForeignKey("User")]
        public int IdUser { get; set; }
        [ForeignKey("Course")]
        public int IdCourse { get; set; }
        public bool IsOwner { get; set; }
    
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}
