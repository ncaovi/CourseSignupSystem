using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("Turnover")]
    public class TurnoverModel
    {
        [Key]
        public int TurnoverId { get; set; }

        public int TurnoverStudent { get; set; }

        [Display(Name = "Mã Sinh Viên")]
        [StringLength(50)]
        public string TurnoverStudentCode { get; set; }

        [Display(Name = "Lớp học")]
        [StringLength(50)]
        public string TurnoverStudentClass { get; set; }

        [Display(Name = "Tên Sinh Viên")]
        [StringLength(50)]
        public string TurnoverStudentName { get; set; }

        [Display(Name = "Ngày học")]
        [StringLength(50)]
        public string TurnoverStudyDate { get; set; }

        public DateTime TurnoverStartDate { get; set; }
        public DateTime TurnoverEndDate { get; set; }

        public double TurnoverTuition { get; set; }

        [Display(Name = "Tên Giáo Viên")]
        [StringLength(50)]
        public string TurnoverTeacher { get; set; }
    }
}