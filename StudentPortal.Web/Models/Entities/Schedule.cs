using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentPortal.Web.Models.Entities
{
    public class Schedule
    {
        [Key]
        public required string Days { get; set; }
        public required string StartTime { get; set; }
        public required string EndTime { get; set; }
        public required int Room { get; set; }
        public required string Section { get; set; }
        public required int SchoolYear { get; set; }
    }
}
