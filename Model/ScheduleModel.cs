using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("ScheduleTeacher")]
    public class ScheduleModel
    {
        [Key]
        public int ScheduleId { get; set; }

        [ForeignKey("userModel")]
        public int ScheduleUser { get; set; }

        public int ScheduleSubject { get; set; }

        public int ScheduleClassId { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã Giáo Viên")]
        public string ScheduleTeacherCode { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Giáo Viên")]
        public string ScheduleTeacherName { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Lớp")]
        public string ScheduleClassName { get; set; }

        [StringLength(50)]
        [Display(Name = "Môn Học")]
        public string ScheduleSubjectName { get; set; }

        [StringLength(50)]
        [Display(Name = "Phòng Học")]
        public string ScheduleRoom { get; set; }

        [Display(Name = "Giờ Học")]
        public DateTime ScheduleTime { get; set; }

        [Display(Name = "Thứ")]
        public DateTime ScheduleOn { get; set; }

        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime ScheduleStartDate { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public DateTime ScheduleEndDate { get; set; }

        [Display(Name = "Thời Gian")]
        public DateTime Schedule { get; set; }


        public UserModel userModel { get; set; }
        public SubjectModel subjectModel { get; set; }

    }
}