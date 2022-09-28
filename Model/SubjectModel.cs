using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("Subject")]
    public class SubjectModel
    {
        [Key]
        public int SubjectId { get; set; }

        [ForeignKey("departmentModel")]
        public int SubjectDepartment { get; set; }

        [ForeignKey("courseModel")]
        public int SubjectCourse { get; set; }

        [Display(Name = "Mã Môn Học"), StringLength(30)]
        public string SubjectCode { get; set; }

        [Display(Name = "Tên Môn Học"), StringLength(30)]
        public string SubjectName { get; set; }

        public DepartmentModel departmentModel { get; set; }
        public CourseModel courseModel { get; set; }
    }
}