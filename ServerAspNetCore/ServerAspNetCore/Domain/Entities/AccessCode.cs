using System.ComponentModel.DataAnnotations;

namespace ServerAspNetCore.Domain.Entities
{
    public class AccessCode
    {
        [Key]
        public int IdCode { get; set; }
        public int IdCourse { get; set; }
        public int Key { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
