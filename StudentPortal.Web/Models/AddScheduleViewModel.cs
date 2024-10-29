using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddScheduleViewModel
    {
        [Key]
        public required string Days { get; set; }
        public required int StartTime { get; set; }
        public required int EndTime { get; set; }
        public required int Room { get; set; }
        public required char Section { get; set; }
        public required int SchoolYear { get; set; }
    }
}
