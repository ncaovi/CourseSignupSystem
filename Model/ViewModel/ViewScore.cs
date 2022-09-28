namespace CourseSignupSystem.Models.ViewModel
{
    public class ViewScore
    {

        public int ScoreId { get; set; }
        public int ScoreClassId { get; set; }
        public string ScoreSubjectName { get; set; }

        public string ScoreStudentName { get; set; }

        public float ScoreOralTestFisrt { get; set; } 

        public float ScoreOralTestSecond { get; set; }

        public float ScoreOralTestThird { get; set; }

        public float ScoreOralTestFourth { get; set; }

        public float ScoreOralTestFifth { get; set; }


        public float ScoreFinalFisrt { get; set; }

        public float ScoreFinalSecond { get; set; }
    }
}