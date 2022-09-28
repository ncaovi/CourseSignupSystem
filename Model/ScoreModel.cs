using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("Score")]
    public class ScoreModel
    {
        [Key]
        public int ScoreId { get; set; }

        [ForeignKey("subjectModel")]
        public int ScoreSubjectId { get; set; }

        [ForeignKey("scoreTypeModel")]
        public int ScoreType { get; set; }

        [Display(Name = "Tên Khóa Đào Tạo")]
        [StringLength(20)]
        public string ScoreCourse { get; set; }

        [Display(Name = "Tên Môn Học")]
        [StringLength(20)]
        public string ScoreSubjectName { get; set; }

        [Display(Name = "Tên Loại Điểm")]
        [StringLength(20)]
        public string ScoreTypeName { get; set; }

        [Display(Name = "Số Cột Điểm")]
        public int ScoreQuantity { get; set; }

        [Display(Name = "Số Cột Điểm Bắt Buộc")]
        public int ScoreQuantityRequired { get; set; }


        public ScoreTypeModel scoreTypeModel { get; set; }

        public SubjectModel subjectModel { get; set; }


    }
}