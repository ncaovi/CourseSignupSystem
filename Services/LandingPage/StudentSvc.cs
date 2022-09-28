using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignupSystem.Services.LandingPage
{
    public class StudentSvc : IStudent
    {
        protected DataContext _context;
        public StudentSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<List<RegisterClass>> GetRegistClass()
        {
            var list = await _context.registerClasses.ToListAsync();
            return list;
        }

        public async Task<List<RegisterClass>> RegistClassId(RegisterClass registerClass)
        {
            var list = await _context.registerClasses.Where(l => l.RegisterClassStudentCode == registerClass.RegisterClassStudentCode).ToListAsync();
            return list;
        }

        public async Task<int> RegisterClass(RegisterClass registerClass)
        {
            int ret = 0;
            try
            {
                var student = await _context.UserModels.FindAsync(registerClass.RegisterUser);
                var classs = await _context.ClassModels.FindAsync(registerClass.RegisterClassCourse);

                registerClass.RegisterClassCourseName = classs.ClassCourseName; 
                registerClass.RegisterClassStudentName = student.UserFisrtName;
                registerClass.RegisterClassStudentCode = student.UserStudentCode;
                registerClass.RegisterClassTuition = classs.ClassTuition;
                registerClass.RegisterClassDescription = classs.ClassDescription;

                await _context.AddAsync(registerClass);
                await _context.SaveChangesAsync();
                ret = registerClass.RegisterClassId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
    }
}