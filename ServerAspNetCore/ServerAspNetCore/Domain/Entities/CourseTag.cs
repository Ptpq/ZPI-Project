using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServerAspNetCore.Domain.Entities
{
    public class CourseTag
    {
        [ForeignKey("Course")]
        public int IdCourse {get;set;}
        [ForeignKey("Tag")]
        public int IdTag {get;set;}
        public Course Course {get;set;}
        public Tag Tag {get; set;}

  }
}
