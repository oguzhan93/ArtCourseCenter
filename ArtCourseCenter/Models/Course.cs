using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtCourseCenter.Models
{

    public class Course
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public int Fee { get; set; }
        public int Quota { get; set; }
        public bool IsAvailable { get; set; }
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; } 
    }


}
