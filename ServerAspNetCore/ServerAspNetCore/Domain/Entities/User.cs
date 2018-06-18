
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerAspNetCore.Domain.Entities
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required,MaxLength(30)]
        public string Login { get; set; }
        [Required,MaxLength(60)]
        public string Email { get; set; }
        [Required,MaxLength(30)]
        public string Password { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required,MaxLength(30)]
        public string Surname { get; set; }
        public virtual ICollection<Raiting> Raitings {get;set;}
        public virtual ICollection<Access> Accesses {get;set;}
    }
}
