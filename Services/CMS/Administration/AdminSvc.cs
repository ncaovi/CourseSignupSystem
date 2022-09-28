using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignupSystem.Services.CMS.Administration
{
    public class AdminSvc : IAdmin
    {
        protected DataContext _context;
        protected IEncode _enCode;


        public AdminSvc(DataContext context, IEncode encode) 
        {
            _context = context;
            _enCode = encode;
        }


        public async Task<UserModel> GetUser(int id)
        {
            UserModel user = null;
            user = await _context.UserModels.FindAsync(id);
            return user;
        }

        #region Role
        public async Task<int> AddRole(RoleModel roleModel)
        {
            int ret = 0;
            try
            {
                _context.Add(roleModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        #region Student
        public async Task<List<UserModel>> GetStudentAll()
        {
            var user = await _context.UserModels.Where(u => u.UserRole == 3).ToListAsync();
            return user;
        }

        public async Task<List<UserModel>> GetStudentId(ViewLogin viewLogin)
        {

            var user = await _context.UserModels.Where(u => u.UserRole == 3).Where(u => u.UserStudentCode == viewLogin.UserStudentCode ||
               u.UserFisrtName == viewLogin.UserFisrtName || u.UserPhone == viewLogin.UserPhone || u.UserEmail == viewLogin.UserEmail).ToListAsync();
            return user;
        }

        public async Task<int> AddStudent(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                userModel.UserBlock = false;
                userModel.UserPassword = _enCode.Encode(userModel.UserPassword);
                userModel.IsDelete = true;
                userModel.UserRole = 3;

                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        var fileExtension = Path.GetExtension(fileName);
                        var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }


                        userModel.UserImg = fileName;
                    }
                }

                await _context.AddAsync(userModel);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditStudent(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                UserModel user = null;
                user = await GetUser(userModel.UserId);

                user.UserSurname = userModel.UserSurname;
                user.UserFisrtName = userModel.UserFisrtName;
                user.UserBirthday = userModel.UserBirthday;
                user.UserEmail = userModel.UserEmail;
                user.UserAddress = userModel.UserAddress;
                user.UserParentName = userModel.UserParentName;
                user.UserClass = userModel.UserClass;
                user.UserPhone = userModel.UserPhone;
                user.UserPassword = _enCode.Encode(userModel.UserPassword);


                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        //var fileExtension = Path.GetExtension(fileName);
                        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Students", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        user.UserImg = fileName;
                    }
                }
                _context.Update(user);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int ret = 0;
            try
            {
                var user = await GetUser(id);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Teacher

        public async Task<List<UserModel>> GetTeacherAll()
        {
            var user = await _context.UserModels.Where(u => u.UserRole == 2).ToListAsync();
            return user;
        }

        public async Task<List<UserModel>> GetTeacherId(ViewLogin viewLogin)
        {
            var user = await _context.UserModels.Where(u => u.UserRole == 2).Where(u => u.UserTeacherCode == viewLogin.UserTeacherCode ||
               u.UserFisrtName == viewLogin.UserFisrtName || u.UserPhone == viewLogin.UserPhone || u.UserEmail == viewLogin.UserEmail).ToListAsync();
            return user;
        }

        public async Task<int> AddTeacher(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                userModel.UserBlock = false;
                userModel.UserPassword = _enCode.Encode(userModel.UserPassword);
                userModel.IsDelete = true;
                userModel.UserRole = 2;


                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        //var fileExtension = Path.GetExtension(fileName);
                        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        userModel.UserImg = fileName;
                    }
                }

                await _context.AddAsync(userModel);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditTeacher(UserModel userModel, IFormFile file)
        {
            int ret = 0;
            try
            {
                UserModel user = null;
                user = await GetUser(userModel.UserId);

                user.UserTaxCode = userModel.UserTaxCode;
                user.UserSurname = userModel.UserSurname;
                user.UserFisrtName = userModel.UserFisrtName;
                user.UserBirthday = userModel.UserBirthday;
                user.UserEmail = userModel.UserEmail;
                user.UserGender = userModel.UserGender;
                user.UserAddress = userModel.UserAddress;

                user.UserMainSubject = userModel.UserMainSubject;
                user.UserParttimeSubject = userModel.UserParttimeSubject;
                user.UserPhone = userModel.UserPhone;
                user.UserPassword = _enCode.Encode(userModel.UserPassword);


                if (file != null)
                {
                    if (file.Length > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);

                        //var fileExtension = Path.GetExtension(fileName);
                        //var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = DateTime.Now.Ticks + extension;

                        var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers");

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Image\\Teachers", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        user.UserImg = fileName;
                    }
                }
                _context.Update(user);
                await _context.SaveChangesAsync();
                ret = userModel.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteTeacher(int id)
        {
            int ret = 0;
            try
            {
                var user = await GetUser(id);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Course (Khóa)

        public async Task<List<CourseModel>> GetCourse()
        {
            var list = await _context.CourseModels.ToListAsync();
            return list;
        }

        public async Task<List<CourseModel>> GetCourseId(CourseModel courseModel)
        {
            var course = await _context.CourseModels.Where(c => c.CourseCode == courseModel.CourseCode ||
                                    c.CourseName == courseModel.CourseName).ToListAsync();
            return course;
        }

        public async Task<CourseModel> GetCourseId(int id)
        {
            CourseModel course = null;
            course = await _context.CourseModels.FindAsync(id);
            return course;
        }

        public async Task<CourseModel> GetCourseString(string code)
        {
            CourseModel course = null;
            course = await _context.CourseModels.Where(c => c.CourseCode == code).FirstOrDefaultAsync();
            return course;
        }
        public async Task<int> CopyCourse(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
                CourseModel course = null;
                course = await GetCourseString(courseModel.Course);

                await _context.AddAsync(courseModel);
                await _context.SaveChangesAsync();
                ret = courseModel.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> AddCourse(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(courseModel);
                await _context.SaveChangesAsync();
                ret = courseModel.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditCourse(CourseModel courseModel)
        {
            int ret = 0;
            try
            {
                CourseModel course = null;
                course = await GetCourseId(courseModel.CourseId);

                course.CourseCode = courseModel.CourseCode;
                course.CourseName = courseModel.CourseName;

                _context.Update(course);
                await _context.SaveChangesAsync();
                ret = courseModel.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteCourse(int id)
        {
            int ret = 0;
            try
            {
                var course = await GetCourseId(id);
                _context.Remove(course);
                await _context.SaveChangesAsync();
                ret = course.CourseId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Department (Tổ Bộ Môn)

        public async Task<List<DepartmentModel>> GetDepartment()
        {
            var department = await _context.DepartmentModels.ToListAsync();
            return department;
        }

        public async Task<List<DepartmentModel>> GetDepartmentId(DepartmentModel departmentModel)
        {
            var department = await _context.DepartmentModels.Where(d => d.DepartmentName == departmentModel.DepartmentName).ToListAsync();
            return department;
        }

        public async Task<DepartmentModel> GetDepartmentId(int id)
        {
            DepartmentModel department = null;
            department = await _context.DepartmentModels.FindAsync(id);
            return department;
        }

        public async Task<int> AddDepartment(DepartmentModel departmentModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(departmentModel);
                await _context.SaveChangesAsync();
                ret = departmentModel.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditDepartment(DepartmentModel departmentModel)
        {
            int ret = 0;
            try
            {
                DepartmentModel depart = null;
                depart = await GetDepartmentId(departmentModel.DepartmentId);

                depart.DepartmentName = departmentModel.DepartmentName;

                _context.Update(depart);
                await _context.SaveChangesAsync();
                ret = departmentModel.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteDepartment(int id)
        {
            int ret = 0;
            try
            {
                var depart = await GetDepartmentId(id);
                _context.Remove(depart);
                await _context.SaveChangesAsync();
                ret = depart.DepartmentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Subject (Môn Học)

        public async Task<List<SubjectModel>> GetSubject()
        {
            var subjects = await _context.SubjectModels.ToListAsync();
            return subjects;
        }

        public async Task<List<SubjectModel>> GetSubjectAll()
        {
            var subjects = await _context.SubjectModels.Include(s => s.courseModel).
                                    Include(s => s.departmentModel).ToListAsync();
            return subjects;
        }

        public async Task<List<SubjectModel>> GetSubjectId(SubjectModel subjectModel)
        {
            var subjects = await _context.SubjectModels.Where(s => s.SubjectName == subjectModel.SubjectName ||
                                                  s.SubjectCode == subjectModel.SubjectCode).ToListAsync();
            return subjects;
        }

        public async Task<SubjectModel> GetSubjectId(int id)
        {
            SubjectModel subject = null;
            subject = await _context.SubjectModels.FindAsync(id);
            return subject;
        }

        public async Task<int> AddSubject(SubjectModel subjectModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(subjectModel);
                await _context.SaveChangesAsync();
                ret = subjectModel.SubjectId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditSubject(SubjectModel subjectModel)
        {
            int ret = 0;
            try
            {
                SubjectModel subject = null;
                subject = await GetSubjectId(subjectModel.SubjectId);

                subject.SubjectName = subjectModel.SubjectName;
                subject.SubjectCode = subjectModel.SubjectCode;
                subject.SubjectCourse = subjectModel.SubjectCourse;
                subject.SubjectDepartment = subjectModel.SubjectDepartment;

                _context.Update(subject);
                await _context.SaveChangesAsync();
                ret = subjectModel.SubjectId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteSubject(int id)
        {
            int ret = 0;
            try
            {
                var subject = await GetSubjectId(id);
                _context.Remove(subject);
                await _context.SaveChangesAsync();
                ret = subject.SubjectId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        #region ScoreType (Loại Điểm)

        public async Task<List<ScoreTypeModel>> GetScoreType()
        {
            var scoreType = await _context.ScoreTypesModels.ToListAsync();
            return scoreType;
        }

        public async Task<ScoreTypeModel> GetScoreTypeId(int id)
        {
            ScoreTypeModel scoreType = null;
            scoreType = await _context.ScoreTypesModels.FindAsync(id);
            return scoreType;
        }

        public async Task<int> AddScoreType(ScoreTypeModel scoreTypeModel)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(scoreTypeModel);
                await _context.SaveChangesAsync();
                ret = scoreTypeModel.ScoreTypeId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditScoreType(ScoreTypeModel scoreTypeModel)
        {
            int ret = 0;
            try
            {
                ScoreTypeModel scoreType = null;
                scoreType = await GetScoreTypeId(scoreTypeModel.ScoreTypeId);

                scoreType.ScoreTypeName = scoreTypeModel.ScoreTypeName;
                scoreType.ScoreTypeCoefficient = scoreTypeModel.ScoreTypeCoefficient;

                _context.Update(scoreType);
                await _context.SaveChangesAsync();
                ret = scoreTypeModel.ScoreTypeId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteScoreType(int id)
        {
            int ret = 0;
            try
            {
                var scoreType = await GetScoreTypeId(id);
                _context.Remove(scoreType);
                await _context.SaveChangesAsync();
                ret = scoreType.ScoreTypeId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Score (Điểm)

        public async Task<List<ScoreModel>> GetScore()
        {
            var score = await _context.ScoreModels.ToListAsync();
            return score;
        }

        public async Task<List<ScoreModel>> GetScoreAll()
        {
            var score = await _context.ScoreModels.Include(s => s.subjectModel).
                                    Include(s => s.scoreTypeModel).ToListAsync();
            return score;
        }

        public async Task<List<ScoreModel>> GetScoreId(ScoreModel scoreModel)
        {
            var score = await _context.ScoreModels.Where(s => s.ScoreSubjectName == scoreModel.ScoreSubjectName).ToListAsync();
            return score;
        }

        public async Task<ScoreModel> GetScoreId(int id)
        {
            ScoreModel score = null;
            score = await _context.ScoreModels.FindAsync(id);
            return score;
        }

        public async Task<int> AddScore(ScoreModel scoreModel)
        {
            int ret = 0;
            try
            {
                var ScoreType = await _context.ScoreTypesModels.FindAsync(scoreModel.ScoreType);
                var ScoreSubject = await _context.SubjectModels.FindAsync(scoreModel.ScoreSubjectId);
                var ScoreCourse = await _context.CourseModels.FindAsync(ScoreSubject.SubjectCourse);

                scoreModel.ScoreTypeName = ScoreType.ScoreTypeName;
                scoreModel.ScoreSubjectName = ScoreSubject.SubjectName;
                scoreModel.ScoreCourse = ScoreCourse.CourseName;

                await _context.AddAsync(scoreModel);
                await _context.SaveChangesAsync();
                ret = scoreModel.ScoreId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditScore(ScoreModel scoreModel)
        {
            int ret = 0;
            try
            {
                ScoreModel score = null;
                score = await GetScoreId(scoreModel.ScoreId);

                var ScoreType = await _context.ScoreTypesModels.FindAsync(scoreModel.ScoreType);
                var ScoreSubject = await _context.SubjectModels.FindAsync(scoreModel.ScoreSubjectId);
                var ScoreCourse = await _context.CourseModels.FindAsync(ScoreSubject.SubjectCourse);

                score.ScoreTypeName = ScoreType.ScoreTypeName;
                score.ScoreSubjectName = ScoreSubject.SubjectName;
                score.ScoreCourse = ScoreCourse.CourseName;

                _context.Update(score);
                await _context.SaveChangesAsync();
                ret = scoreModel.ScoreId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteScore(int id)
        {
            int ret = 0;
            try
            {
                var score = await GetScoreId(id);
                _context.Remove(score);
                await _context.SaveChangesAsync();
                ret = score.ScoreId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        #region Class (Lớp Học)

        public async Task<List<ClassModel>> GetClass()
        {
            List<ClassModel> list = new List<ClassModel>();
            list = await _context.ClassModels.ToListAsync();
            return list;
        }

        public async Task<List<UserModel>> GetClassStudent(ClassModel classModel)
        {
            List<UserModel> listStudent = new List<UserModel>();

            listStudent = await _context.UserModels.Where(s => s.UserClass == classModel.ClassId).ToListAsync();
            return listStudent;
        }

        public async Task<List<ClassModel>> GetClassId(ClassModel classModel)
        {
            List<ClassModel> list = new List<ClassModel>();
            list = await _context.ClassModels.Where(c => c.ClassCode == classModel.ClassCode ||
                            c.ClassName == classModel.ClassName).ToListAsync();
            return list;
        }

        public async Task<ClassModel> GetClassId(int id)
        {
            var classModel = await _context.ClassModels.FindAsync(id);
            return classModel;
        }

        public async Task<int> AddClass(ClassModel classModel)
        {
            int ret = 0;
            try
            {
                var courseName = await _context.CourseModels.FindAsync(classModel.ClassCourse);

                classModel.ClassCourseName = courseName.CourseName;

                await _context.AddAsync(classModel);
                await _context.SaveChangesAsync();
                ret = classModel.ClassId;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditClass(ClassModel classModel)
        {
            int ret = 0;
            try
            {
                ClassModel classs = null;
                classs = await GetClassId(classModel.ClassId);

                classs.ClassName = classModel.ClassName;
                classs.ClassCode = classModel.ClassCode;
                classs.ClassSchoolYear = classModel.ClassSchoolYear;
                classs.ClassDescription = classModel.ClassDescription;
                classs.ClassQuantity = classModel.ClassQuantity;
                classs.ClassStatus = classModel.ClassStatus;
                classs.ClassTuition = classModel.ClassTuition;

                var courseName = await _context.CourseModels.FindAsync(classModel.ClassCourse);

                classs.ClassCourseName = courseName.CourseName;

                _context.Update(classs);
                await _context.SaveChangesAsync();
                ret = classModel.ClassId;
            }
            catch (Exception)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteClass(int id)
        {
            int ret = 0;
            try
            {
                var classs = await GetClassId(id);
                _context.Remove(classs);
                await _context.SaveChangesAsync();
                ret = classs.ClassId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        #region ScoreDetail (Bảng Điểm)

        public async Task<List<ScoreDetail>> GetScoreDetail()
        {
            var list = await _context.ScoreDetails.Include(s => s.scoreOralTest).ToListAsync();
            return list;
        }

        public async Task<List<ScoreDetail>> ScoreDetailId(ScoreDetail scoreDetail)
        {
            List<ScoreDetail> list = new List<ScoreDetail>();
            list = await _context.ScoreDetails.Where(l => l.ScoreSubjectName == scoreDetail.ScoreSubjectName).ToListAsync();
            return list;
        }

        public async Task<ScoreDetail> ScoreDetailId(int id)
        {
            var list = await _context.ScoreDetails.FindAsync(id);
            return list;
        }

        public async Task<ScoreOralTest> ScoreOralTestId(int id)
        {
            var list = await _context.ScoreOralTests.FindAsync(id);
            return list;
        }

        public async Task<int> AddScoreDetail(ViewScore viewScore)
        {
            int ret = 0;
            try
            {
                var listSubject = await _context.SubjectModels.Where(s => s.SubjectName == viewScore.ScoreSubjectName).ToListAsync();
                var listStudent = await _context.UserModels.Where(s => s.UserClass == viewScore.ScoreClassId).
                                                Where(s => s.UserFisrtName == viewScore.ScoreStudentName).ToListAsync();

                if (listSubject != null)
                {
                    if (listStudent != null)
                    {
                        ScoreDetail scoreDetail = new ScoreDetail();

                        scoreDetail.ScoreStudentName = Convert.ToString(listStudent[0].UserFisrtName);
                        scoreDetail.ScoreSubjectName = Convert.ToString(listSubject[0].SubjectName);


                        if (viewScore.ScoreOralTestFisrt != 0 || viewScore.ScoreOralTestSecond != 0 ||
                               viewScore.ScoreOralTestThird != 0 || viewScore.ScoreOralTestFourth != 0 || viewScore.ScoreOralTestFifth != 0)
                        {
                            ScoreOralTest scoreOralTest = new ScoreOralTest();
                            scoreOralTest.ScoreOralTestFisrt = viewScore.ScoreOralTestFisrt;
                            scoreOralTest.ScoreOralTestSecond = viewScore.ScoreOralTestSecond;
                            scoreOralTest.ScoreOralTestThird = viewScore.ScoreOralTestThird;
                            scoreOralTest.ScoreOralTestFourth = viewScore.ScoreOralTestFourth;
                            scoreOralTest.ScoreOralTestFifth = viewScore.ScoreOralTestFifth;

                            scoreOralTest.ScoreFinalFisrt = viewScore.ScoreFinalFisrt;
                            scoreOralTest.ScoreFinalSecond = viewScore.ScoreFinalSecond;

                            await _context.AddAsync(scoreOralTest);
                            await _context.SaveChangesAsync();
                            scoreDetail.ScoreDetailOral = scoreOralTest.ScoreOralTestId;
                        }
                        scoreDetail.ScoreClassId = viewScore.ScoreClassId;

                        await _context.AddAsync(scoreDetail);
                        await _context.SaveChangesAsync();
                        ret = scoreDetail.ScoreDetailId;
                    }
                    else
                    {
                        ret = 0;
                    }
                }
                else
                {
                    ret = 0;
                }
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditScoreDetail(ViewScore viewScore)
        {
            int ret = 0;
            try
            {
                ScoreDetail scoreDetail = null;
                scoreDetail = await ScoreDetailId(viewScore.ScoreId);

                if (viewScore.ScoreOralTestFisrt != 0 || viewScore.ScoreOralTestSecond != 0 ||
                       viewScore.ScoreOralTestThird != 0 || viewScore.ScoreOralTestFourth != 0 || viewScore.ScoreOralTestFifth != 0)
                {
                    ScoreOralTest scoreOralTest = new ScoreOralTest();
                    scoreOralTest = await ScoreOralTestId(scoreDetail.ScoreDetailOral);


                    scoreOralTest.ScoreOralTestFisrt = viewScore.ScoreOralTestFisrt;
                    scoreOralTest.ScoreOralTestSecond = viewScore.ScoreOralTestSecond;
                    scoreOralTest.ScoreOralTestThird = viewScore.ScoreOralTestThird;
                    scoreOralTest.ScoreOralTestFourth = viewScore.ScoreOralTestFourth;
                    scoreOralTest.ScoreOralTestFifth = viewScore.ScoreOralTestFifth;

                    scoreOralTest.ScoreFinalFisrt = viewScore.ScoreFinalFisrt;
                    scoreOralTest.ScoreFinalSecond = viewScore.ScoreFinalSecond;

                    _context.Update(scoreOralTest);
                    await _context.SaveChangesAsync();
                    ret = scoreOralTest.ScoreOralTestId;
                }

            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }



        #endregion

        #region Receipts (Học Phí)
        public async Task<List<ReceiptsModel>> GetReceipts()
        {
            var list = await _context.ReceiptsModels.ToListAsync();
            return list;
        }
        public async Task<int> AddReceipts(ReceiptsModel receiptsModel)
        {
            int ret = 0;
            try
            {
                var student = await _context.UserModels.FindAsync(receiptsModel.ReceiptsStudentId);
                var classs = await _context.ClassModels.FindAsync(student.UserClass);


                receiptsModel.ReceiptsTraining = student.UserFisrtName;
                receiptsModel.ReceiptsClassName = classs.ClassName;
                receiptsModel.ReceiptsFee = classs.ClassTuition;
                receiptsModel.ReceiptsRateFee = classs.ClassTuition;
                receiptsModel.ReceiptsPayableFee = receiptsModel.ReceiptsFee + receiptsModel.ReceiptsSurcharge;

                if (student != null)
                {
                    TurnoverModel turnoverModel = new TurnoverModel();
                    turnoverModel.TurnoverStudentCode = student.UserStudentCode;
                    turnoverModel.TurnoverStudentName = student.UserFisrtName;
                    turnoverModel.TurnoverStudentClass = classs.ClassName;
                    turnoverModel.TurnoverTuition = classs.ClassTuition;
                    await _context.AddAsync(turnoverModel);
                    await _context.SaveChangesAsync();
                }
                else
                {

                }

                await _context.AddAsync(receiptsModel);
                await _context.SaveChangesAsync();
                ret = receiptsModel.ReceiptsId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        #region Schedule (Giáo Viên)

        public async Task<List<ScheduleModel>> GetSchedule()
        {
            var list = await _context.ScheduleModels.ToListAsync();
            return list;
        }

        public async Task<List<ScheduleModel>> ScheduleId(ScheduleModel scheduleModel)
        {
            List<ScheduleModel> list = new List<ScheduleModel>();
            list = await _context.ScheduleModels.Where(l => l.ScheduleTeacherName == scheduleModel.ScheduleTeacherName ||
                            l.ScheduleSubjectName == scheduleModel.ScheduleSubjectName).ToListAsync();
            return list;
        }
        public async Task<ScheduleModel> ScheduleId(int id)
        {
            var list = await _context.ScheduleModels.FindAsync(id);
            return list;
        }
        public async Task<int> AddSchedule(ScheduleModel scheduleModel)
        {
            int ret = 0;
            try
            {
                var subject = await _context.SubjectModels.FindAsync(scheduleModel.ScheduleClassId);
                var classs = await _context.ClassModels.FindAsync(scheduleModel.ScheduleClassId);
                var teacher = await _context.UserModels.FindAsync(scheduleModel.ScheduleUser);

                scheduleModel.ScheduleTeacherCode = teacher.UserTeacherCode;
                scheduleModel.ScheduleTeacherName = teacher.UserFisrtName;
                scheduleModel.ScheduleClassName = classs.ClassName;
                scheduleModel.ScheduleSubjectName = subject.SubjectName;


                await _context.AddAsync(scheduleModel);
                await _context.SaveChangesAsync();
                ret = scheduleModel.ScheduleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditSchedule(ScheduleModel scheduleModel)
        {
            int ret = 0;
            try
            {
                ScheduleModel schedule = null;
                schedule = await ScheduleId(scheduleModel.ScheduleId);

                var subject = await _context.SubjectModels.FindAsync(scheduleModel.ScheduleClassId);
                var classs = await _context.ClassModels.FindAsync(scheduleModel.ScheduleClassId);
                var teacher = await _context.UserModels.FindAsync(scheduleModel.ScheduleUser);


                schedule.ScheduleTeacherCode = teacher.UserTeacherCode;
                schedule.ScheduleTeacherName = teacher.UserFisrtName;
                schedule.ScheduleClassName = classs.ClassName;
                schedule.ScheduleSubjectName = subject.SubjectName;
                schedule.ScheduleRoom = scheduleModel.ScheduleRoom;
                schedule.ScheduleTime = scheduleModel.ScheduleTime;
                schedule.ScheduleOn = scheduleModel.ScheduleOn;
                schedule.ScheduleStartDate = scheduleModel.ScheduleStartDate;
                schedule.ScheduleEndDate = scheduleModel.ScheduleEndDate;
                schedule.Schedule = scheduleModel.Schedule;

                _context.Update(schedule);
                await _context.SaveChangesAsync();
                ret = scheduleModel.ScheduleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteSchedule(int id)
        {
            int ret = 0;
            try
            {
                var schedule = await ScheduleId(id);
                _context.Remove(schedule);
                await _context.SaveChangesAsync();
                ret = schedule.ScheduleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        #endregion

        #region Schedule (Học Sinh)

        public async Task<List<ScheduleStudent>> GetScheduleStudent(ScheduleStudent scheduleStudent)
        {
            var list = await _context.ScheduleStudents.Where(s => s.ScheduleUser == scheduleStudent.ScheduleUser).ToListAsync();
            return list;
        }

        public async Task<ScheduleStudent> ScheduleStudentId(int id)
        {
            var list = await _context.ScheduleStudents.FindAsync(id);
            return list;
        }
        public async Task<int> AddScheduleStudent(ScheduleStudent scheduleStudent)
        {
            int ret = 0;
            try
            {
                var student = await _context.UserModels.FindAsync(scheduleStudent.ScheduleUser);
                var classs = await _context.ClassModels.FindAsync(scheduleStudent.ScheduleClassId);
                var subject = await _context.SubjectModels.FindAsync(scheduleStudent.ScheduleClassId);

                scheduleStudent.ScheduleStudentName = student.UserFisrtName;
                scheduleStudent.ScheduleStudentCode = student.UserStudentCode;
                scheduleStudent.ScheduleClassName = classs.ClassName;
                scheduleStudent.ScheduleSubjectName = subject.SubjectName;

                await _context.AddAsync(scheduleStudent);
                await _context.SaveChangesAsync();
                ret = scheduleStudent.ScheduleStudentId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        #endregion

        #region Schedule (Ngày Nghỉ)
        public async Task<List<ScheduleHoliday>> GetScheduleHoliday()
        {
            var ScheduleHoliday = await _context.ScheduleHolidays.ToListAsync();
            return ScheduleHoliday;
        }

        public async Task<List<ScheduleHoliday>> ScheduleHolidayId(ScheduleHoliday scheduleHoliday)
        {
            var schedule = await _context.ScheduleHolidays.Where(s => s.ScheduleHolidayName == scheduleHoliday.ScheduleHolidayName ||
                                            s.ScheduleHolidayReason == scheduleHoliday.ScheduleHolidayReason).ToListAsync();
            return schedule;
        }

        public async Task<ScheduleHoliday> ScheduleHolidayId(int id)
        {
            ScheduleHoliday scheduleHoliday = null;
            scheduleHoliday = await _context.ScheduleHolidays.FindAsync(id);
            return scheduleHoliday;
        }

        public async Task<int> AddScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {
            int ret = 0;
            try
            {
                await _context.AddAsync(scheduleHoliday);
                await _context.SaveChangesAsync();
                ret = scheduleHoliday.ScheduleHolidayId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditScheduleHoliday(ScheduleHoliday scheduleHoliday)
        {
            int ret = 0;
            try
            {
                ScheduleHoliday schedule = null;
                schedule = await ScheduleHolidayId(scheduleHoliday.ScheduleHolidayId);

                schedule.ScheduleHolidayName = scheduleHoliday.ScheduleHolidayName;
                schedule.ScheduleHolidayReason = scheduleHoliday.ScheduleHolidayReason;
                schedule.ScheduleHolidayStartDate = scheduleHoliday.ScheduleHolidayStartDate;
                schedule.ScheduleHolidayEndDate = scheduleHoliday.ScheduleHolidayEndDate;

                _context.Update(schedule);
                await _context.SaveChangesAsync();
                ret = schedule.ScheduleHolidayId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteScheduleHoliday(int id)
        {
            int ret = 0;
            try
            {
                var scheduleHoliday = await ScheduleHolidayId(id);
                _context.Remove(scheduleHoliday);
                await _context.SaveChangesAsync();
                ret = scheduleHoliday.ScheduleHolidayId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        #endregion


    }

}