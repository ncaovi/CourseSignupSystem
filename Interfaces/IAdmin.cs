using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignupSystem.Interfaces
{
    public interface IAdmin
    {
        #region Role
        Task<int> AddRole(RoleModel roleModel);

        #endregion

        #region Student
        Task<List<UserModel>> GetStudentAll();
        Task<List<UserModel>> GetStudentId(ViewLogin viewLogin);
        Task<int> AddStudent(UserModel userModel, IFormFile file);
        Task<int> EditStudent(UserModel userModel, IFormFile file);
        Task<int> DeleteStudent(int id);
        #endregion

        #region Teacher
        Task<int> AddTeacher(UserModel userModel, IFormFile file);
        Task<int> EditTeacher(UserModel userModel, IFormFile file);
        Task<List<UserModel>> GetTeacherAll();
        Task<List<UserModel>> GetTeacherId(ViewLogin viewLogin);
        Task<int> DeleteTeacher(int id);

        #endregion

        #region Course

        Task<List<CourseModel>> GetCourse();
        Task<List<CourseModel>> GetCourseId(CourseModel courseModel);
        Task<int> CopyCourse(CourseModel courseModel);
        Task<int> AddCourse(CourseModel courseModel);
        Task<int> EditCourse(CourseModel courseModel);
        Task<int> DeleteCourse(int id);

        #endregion

        #region Department
        Task<List<DepartmentModel>> GetDepartment();
        Task<List<DepartmentModel>> GetDepartmentId(DepartmentModel departmentModel);
        Task<int> AddDepartment(DepartmentModel departmentModel);
        Task<int> EditDepartment(DepartmentModel departmentModel);
        Task<int> DeleteDepartment(int id);
        #endregion

        #region Subject 
        Task<List<SubjectModel>> GetSubject();
        Task<List<SubjectModel>> GetSubjectAll();
        Task<int> AddSubject(SubjectModel subjectModel);
        Task<int> EditSubject(SubjectModel subjectModel);
        Task<List<SubjectModel>> GetSubjectId(SubjectModel subjectModel);
        Task<int> DeleteSubject(int id);

        #endregion

        #region ScoreType (Loại Điểm)
        Task<List<ScoreTypeModel>> GetScoreType();
        Task<int> AddScoreType(ScoreTypeModel scoreTypeModel);
        Task<int> EditScoreType(ScoreTypeModel scoreTypeModel);
        Task<int> DeleteScoreType(int id);
        #endregion

        #region Score (Điểm)

        Task<int> AddScore(ScoreModel scoreModel);
        Task<List<ScoreModel>> GetScore();
        Task<List<ScoreModel>> GetScoreAll();
        Task<List<ScoreModel>> GetScoreId(ScoreModel scoreModel);
        Task<int> EditScore(ScoreModel scoreModel);
        Task<int> DeleteScore(int id);

        #endregion

        #region  Class(Lớp Học)

        Task<List<ClassModel>> GetClass();
        Task<List<ClassModel>> GetClassId(ClassModel classModel);
        Task<List<UserModel>> GetClassStudent(ClassModel classModel);
        Task<int> AddClass(ClassModel classModel);
        Task<int> EditClass(ClassModel classModel);
        Task<int> DeleteClass(int id);
        #endregion

        #region ScoreDetail (Bảng Điểm)
        Task<List<ScoreDetail>> GetScoreDetail();
        Task<List<ScoreDetail>> ScoreDetailId(ScoreDetail scoreDetail);
        Task<int> AddScoreDetail(ViewScore viewScore);
        Task<int> EditScoreDetail(ViewScore viewScore);
        #endregion

        #region Receipts (học phí)

        Task<List<ReceiptsModel>> GetReceipts();
        Task<int> AddReceipts(ReceiptsModel receiptsModel);
        #endregion

        #region Schedule ( Lịch Dạy)
        Task<List<ScheduleModel>> GetSchedule();
        Task<List<ScheduleModel>> ScheduleId(ScheduleModel scheduleModel);
        Task<int> AddSchedule(ScheduleModel scheduleModel);
        Task<int> EditSchedule(ScheduleModel scheduleModel);

        Task<int> DeleteSchedule(int id);
        #endregion

        #region Schedule (Ngày Nghỉ)
        Task<List<ScheduleHoliday>> GetScheduleHoliday();
        Task<List<ScheduleHoliday>> ScheduleHolidayId(ScheduleHoliday scheduleHoliday);
        Task<int> AddScheduleHoliday(ScheduleHoliday scheduleHoliday);
        Task<int> EditScheduleHoliday(ScheduleHoliday scheduleHoliday);
        Task<int> DeleteScheduleHoliday(int id);
        #endregion

        #region Schedule (Học Sinh)
        Task<List<ScheduleStudent>> GetScheduleStudent(ScheduleStudent scheduleStudent);

        Task<int> AddScheduleStudent(ScheduleStudent scheduleStudent);
        #endregion
    }
}