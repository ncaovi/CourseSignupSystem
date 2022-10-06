using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("Course")]
    public class CourseModel
    {
        [Key]
        public int CourseId { get; set; }

        [NotMapped]
        public string Course { get; set; }

        [Display(Name = "Mã Khóa")]
        [StringLength(30)]
        public string CourseCode { get; set; }

        [Display(Name = "Tên Khóa")]
        [StringLength(30)]
        public string CourseName { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime CourseStartTime { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public DateTime CourseEndTime { get; set; }

    }
}