using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using System.Threading.Tasks;

namespace CourseSignupSystem.Interfaces
{
    public interface IAuthentication
    {
        Task<UserModel> Login(ViewLogin viewLogin);

        Task<UserModel> GetUserEmail(ViewLogin viewLogin);
        Task<UserModel> GetUserTeacherCode(ViewLogin viewLogin);
        Task<UserModel> GetUserStudentCode(ViewLogin viewLogin);

        Task<int> ChangePasswordAdmin(string email, UserModel userModel);
        Task<int> ChangePasswordTeacherCode(string teachercode, UserModel userModel);
        Task<int> ChangePasswordStudentCode(string studentcode, UserModel userModel);
    }
}