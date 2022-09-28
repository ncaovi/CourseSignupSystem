using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CourseSignupSystem.Models

{
    public class ScoreDetail
    {
        [Key]
        public int ScoreDetailId { get; set; }

        [ForeignKey("classModel")]
        public int ScoreClassId { get; set; }

        [NotMapped]
        public int ScoreStudentId { get; set; }

        [StringLength(50)]
        public string ScoreStudentName { get; set; }

        [StringLength(50)]
        public string ScoreSubjectName { get; set; }

        [Display(Name = "Điểm")]
        [ForeignKey("scoreOralTest")]
        public int ScoreDetailOral { get; set; }


        [Display(Name = "Điểm Trung Bình")]
        public float ScoreDetailMediumScore { get; set; }


        public ScoreOralTest scoreOralTest { get; set; }
        public ClassModel classModel { get; set; }

    }
}