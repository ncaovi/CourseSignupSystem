using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("ScheduleStudent")]
    public class ScheduleStudent
    {
        [Key]
        public int ScheduleStudentId { get; set; }

        [ForeignKey("userModel")]
        public int ScheduleUser { get; set; }

        public int ScheduleSubject { get; set; }

        public int ScheduleClassId { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã Học Sinh")]
        public string ScheduleStudentCode { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Học SInh")]
        public string ScheduleStudentName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Lớp")]
        public string ScheduleClassName { get; set; }

        [StringLength(50)]
        [Display(Name = "Môn Học")]
        public string ScheduleSubjectName { get; set; }

        [StringLength(50)]
        [Display(Name = "Phòng Học")]
        public string ScheduleRoom { get; set; }

        [Display(Name = "Thứ")]
        public DateTime ScheduleOn { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime ScheduleStartDate { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public DateTime ScheduleEndDate { get; set; }




        public UserModel userModel { get; set; }
    }
}