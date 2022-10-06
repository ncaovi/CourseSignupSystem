using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("Class")]
    public class ClassModel
    {
        [Key]
        public int ClassId { get; set; }

        [ForeignKey("courseModel")]
        public int ClassCourse { get; set; }

        [StringLength(20)]
        [Display(Name = "Mã Lớp")]
        public string ClassCode { get; set; }

        [StringLength(20)]
        [Display(Name = "Tên Lớp")]
        public string ClassName { get; set; }

        [StringLength(20)]
        [Display(Name = "Niên Khóa")]
        public string ClassSchoolYear { get; set; }

        [StringLength(50)]
        [Display(Name = "Mô Tả")]
        public string ClassDescription { get; set; }

        [Display(Name = "Tên Khóa")]
        [StringLength(30)]
        public string ClassCourseName { get; set; }

        [Display(Name = "Số Lượng")]
        public int ClassQuantity { get; set; }

        public int ClassQuantityPresent { get; set; }

        [Display(Name = "Trạng Thái")]
        public bool ClassStatus { get; set; }

        [Display(Name = "Học Phí")]
        public double ClassTuition { get; set; }

        //[ForeignKey("userModel")]
        //public int ClassUser { get; set; }

        public ICollection<UserModel> userModel { get; set; }

        public CourseModel courseModel { get; set; }
    }
}