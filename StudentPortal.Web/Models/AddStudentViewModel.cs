﻿using System.ComponentModel.DataAnnotations;

namespace StudentPortal.Web.Models
{
    public class AddStudentViewModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public required string Firstname { get; set; }
        [MaxLength(25)]
        public required string Lastname { get; set; }
        public string? Middlename { get; set; }
    }
}
