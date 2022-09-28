using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("Department")]
    public class DepartmentModel
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Tổ Bộ Môn")]
        public string DepartmentName { get; set; }
    }
}