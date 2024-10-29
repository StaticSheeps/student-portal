using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models.Entities
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectCode { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public required int Units { get; set; }
        public required int CourseCode { get; set; }
        public required string CurriculumYear { get; set; }
        public required int Offering { get; set; }
    }
}
