using System.ComponentModel.DataAnnotations;

namespace TechnicalAssessment.Models.Entities
{
    public class School
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address1 { get; set; }
        public string Address2 { get; set; } = string.Empty;
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; } 

    }
    
}