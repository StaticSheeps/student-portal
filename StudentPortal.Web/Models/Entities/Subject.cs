using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class Subject
    {
        [Key]
        public int SubjectCode { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required int Units { get; set; }
        public required string CourseCode { get; set; }
        public required string CuricculumYear { get; set; }
        public required string Offering { get; set; }
    }
}
