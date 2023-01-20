using System.ComponentModel.DataAnnotations;

namespace ArtCourseCenter.Models
{
    public class Trainee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;

        public int Age { get; set; }
        public bool HasPaidTheFee { get; set; }

        public DateTime RegisterDate { get; set; }

        [StringLength(11)]
        public string TRIdentityNumber { get; set; } = String.Empty;
    }
}
