using Microsoft.EntityFrameworkCore;

namespace CourseSignupSystem.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }
        public DbSet<ScheduleModel> ScheduleModels { get; set; }
        public DbSet<ClassModel> ClassModels { get; set; }
        public DbSet<ReceiptsModel> ReceiptsModels { get; set; }

        public DbSet<DepartmentModel> DepartmentModels { get; set; }
        public DbSet<CourseModel> CourseModels { get; set; }
        public DbSet<SubjectModel> SubjectModels { get; set; }

        public DbSet<ScoreModel> ScoreModels { get; set; }
        public DbSet<ScoreTypeModel> ScoreTypesModels { get; set; }
        public DbSet<ScoreDetail> ScoreDetails { get; set; }
        public DbSet<ScoreOralTest> ScoreOralTests { get; set; }

        public DbSet<ScheduleHoliday> ScheduleHolidays { get; set; }

        public DbSet<ScheduleStudent> ScheduleStudents { get; set; }
        public DbSet<RegisterClass> registerClasses { get; set; }
        public DbSet<TurnoverModel> TurnoverModels { get; set; }

    }
}