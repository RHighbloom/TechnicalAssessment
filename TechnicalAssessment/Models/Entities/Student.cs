using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Models.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string FullName() {
            return $"{LastName}, {FirstName}";
        }

        public required string Major { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }
        public required int School { get; set; }
    }
}