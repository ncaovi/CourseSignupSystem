using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CourseSignupSystem.Models
{
    [Table("ScheduleHoliday")]
    public class ScheduleHoliday
    {
        [Key]
        public int ScheduleHolidayId { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Ngày Nghỉ")]
        public string ScheduleHolidayName { get; set; }

        [StringLength(50)]
        [Display(Name = "Lý Do")]
        public string ScheduleHolidayReason { get; set; }


        [Display(Name = "Ngày Bắt Đầu")]
        public DateTime ScheduleHolidayStartDate { get; set; }

        [Display(Name = "Ngày Kết Thúc")]
        public DateTime ScheduleHolidayEndDate { get; set; } 
    }
}