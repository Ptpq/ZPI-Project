using ServerAspNetCore.Domain.Entities;

namespace ServerAspNetCore.Domain.ViewModel
{
    public class CourseViewModel
    {
        public int IdCourse { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdCategory { get; set; }
        public string Tags { get; set; }
    }
}
