using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    public class ScoreOralTest
    {
        [Key]
        public int ScoreOralTestId { get; set; }

        [Display(Name = "Điểm Thứ Nhất")]
        public float ScoreOralTestFisrt { get; set; }

        [Display(Name = "Điểm Thứ Hai")]
        public float ScoreOralTestSecond { get; set; }
        [Display(Name = "Điểm Thứ ba")]
        public float ScoreOralTestThird { get; set; }
        [Display(Name = "Điểm Thứ tư")]
        public float ScoreOralTestFourth { get; set; }
        [Display(Name = "Điểm Thứ năm")]
        public float ScoreOralTestFifth { get; set; }



        [Display(Name = "Điểm Thứ Nhất")]
        public float ScoreFinalFisrt { get; set; }

        [Display(Name = "Điểm Thứ Hai")]
        public float ScoreFinalSecond { get; set; }
    }
}