using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ArtCourseCenter.Models
{
    public class CoursesAndTrainees
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        
    }
}
