using System.ComponentModel.DataAnnotations;

namespace ArtCourseCenter.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public int Salary { get; set; }
        [MaxLength(50)]
        public string CourseName { get; set; } = String.Empty;
        [StringLength(11)]
        public string TRIdentityNumber { get; set; } = String.Empty;
    }
}
