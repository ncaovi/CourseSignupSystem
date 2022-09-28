using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("RegisterClass")]
    public class RegisterClass
    {
        [Key]
        public int RegisterClassId { get; set; }

        [ForeignKey("userModel")]
        public int RegisterUser { get; set; }

        public int RegisterClassCourse { get; set; }

        [StringLength(40)]
        public string RegisterClassCourseName { get; set; }

        public DateTime RegistClassDate { get; set; }
         
        public string RegisterClassDescription { get; set; }

        public double RegisterClassTuition { get; set; }

        [StringLength(40)]
        public string RegisterClassStudentCode { get; set; }

        [StringLength(40)]
        public string RegisterClassStudentName { get; set; }


        public UserModel userModel { get; set; }
    }
}