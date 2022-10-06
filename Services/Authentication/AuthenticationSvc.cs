using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignupSystem.Services.Authentication
{
    public class AuthenticationSvc : IAuthentication
    {
        protected DataContext _context;
        protected IEncode _enCode;

        public AuthenticationSvc(DataContext context, IEncode encode)
        {
            _context = context;
            _enCode = encode;
        }

        public async Task<UserModel> Login(ViewLogin viewLogin)
        {

            var admin = await _context.UserModels.Where(
                p => p.UserEmail.Equals(viewLogin.UserEmail) || p.UserStudentCode.Equals(viewLogin.UserStudentCode)
                || p.UserTeacherCode.Equals(viewLogin.UserTeacherCode) && p.UserPassword.Equals(_enCode.Encode(viewLogin.UserPassword))
                ).FirstOrDefaultAsync();
            return admin;
        }

        public async Task<UserModel> GetUserEmail(ViewLogin viewLogin)
        {
            UserModel user = null;
            user = await _context.UserModels.FirstOrDefaultAsync(u => u.UserEmail == viewLogin.UserEmail);
            return user;
        }
        public async Task<UserModel> GetUserEmail(string email)
        {
            UserModel users = null;
            users = await _context.UserModels.FirstOrDefaultAsync(u => u.UserEmail == email);
            return users;
        }

        public async Task<UserModel> GetUserTeacherCode(ViewLogin viewLogin)
        {
            UserModel user = null;
            user = await _context.UserModels.FirstOrDefaultAsync(u => u.UserTeacherCode == viewLogin.UserTeacherCode);
            return user;
        }

        public async Task<UserModel> GetUserTeacherCode(string code)
        {
            UserModel users = null;
            users = await _context.UserModels.FirstOrDefaultAsync(u => u.UserTeacherCode == code);
            return users;
        }

        public async Task<UserModel> GetUserStudentCode(ViewLogin viewLogin)
        {
            UserModel user = null;
            user = await _context.UserModels.FirstOrDefaultAsync(u => u.UserStudentCode == viewLogin.UserStudentCode);
            return user;
        }

        public async Task<UserModel> GetUserStudentCode(string code)
        {
            UserModel users = null;
            users = await _context.UserModels.FirstOrDefaultAsync(u => u.UserStudentCode == code);
            return users;
        }

        public async Task<int> ChangePasswordAdmin(string email, UserModel userModel)
        {
            int ret = 0;
            try
            {

                UserModel _user = null;
                _user = await GetUserEmail(email);


                _user.UserPassword = _enCode.Encode(userModel.UserPassword);
                _context.Update(_user);
                await _context.SaveChangesAsync();

                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> ChangePasswordTeacherCode(string teachercode, UserModel userModel)
        {
            int ret = 0;
            try
            {

                UserModel _user = null;
                _user = await GetUserTeacherCode(teachercode);


                _user.UserPassword = _enCode.Encode(userModel.UserPassword);
                _context.Update(_user);
                await _context.SaveChangesAsync();

                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> ChangePasswordStudentCode(string studentcode, UserModel userModel)
        {
            int ret = 0;
            try
            {

                UserModel _user = null;
                _user = await GetUserStudentCode(studentcode);


                _user.UserPassword = _enCode.Encode(userModel.UserPassword);
                _context.Update(_user);
                await _context.SaveChangesAsync();

                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
    }
}