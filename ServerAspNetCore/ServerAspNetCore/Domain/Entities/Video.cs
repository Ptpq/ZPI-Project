using System.ComponentModel.DataAnnotations;

namespace ServerAspNetCore.Domain.Entities
{
    public class Video
    {
        [Key]
        public int IdVideo { get; set; }
        [Required,MaxLength(60)]
        public string Title { get; set; }
        public int? Order { get; set; }
        [Required,MaxLength(100)]
        public string Directory { get; set; }
        public int IdCourse { get; set; }
        [Required, MaxLength(2500)]
        public string Description { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
