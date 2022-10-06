using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using CourseSignupSystem.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignupSystem.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IAuthentication _authentication;
        public IConfiguration _configuration;
        public TokenController(IAuthentication authentication, IConfiguration configuration)
        {
            _authentication = authentication;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [ActionName("Login")]
        public async Task<IActionResult> Login(ViewLogin viewLogin)
        {
            if (viewLogin != null && !string.IsNullOrEmpty(viewLogin.UserEmail) && !string.IsNullOrEmpty(viewLogin.UserPassword) ||
                !string.IsNullOrEmpty(viewLogin.UserStudentCode) && !string.IsNullOrEmpty(viewLogin.UserPassword) ||
                  !string.IsNullOrEmpty(viewLogin.UserTeacherCode) && !string.IsNullOrEmpty(viewLogin.UserPassword))
            {
                var user = await _authentication.Login(viewLogin);

                if (user != null)
                {
                    var claims = new[]
                    {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),

                            new Claim("Id", user.UserId.ToString()),
                            new Claim("FisrtName", user.UserFisrtName),
                            new Claim("SurName", user.UserSurname),
                            new Claim("Email", user.UserEmail),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                        claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    ViewToken viewToken = new ViewToken()
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        User = user
                    };
                    return Ok(viewToken);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }


        //[HttpGet]
        //[ActionName("UserEmail")]
        //public async Task<ActionResult<UserModel>> GetUserEmail(ViewLogin viewLogin)
        //{
        //    var user = await _authentication.GetUserEmail(viewLogin);
        //    return user;
        //}

        //[HttpGet]
        //[ActionName("UserTeacherCode")]
        //public async Task<ActionResult<UserModel>> GetUserTeacherCode(ViewLogin viewLogin)
        //{
        //    var user = await _authentication.GetUserTeacherCode(viewLogin);
        //    return user;
        //}

        //[HttpGet]
        //[ActionName("UserStudentCode")]
        //public async Task<ActionResult<UserModel>> GetUserStudentCode(ViewLogin viewLogin)
        //{
        //    var user = await _authentication.GetUserStudentCode(viewLogin);
        //    return user;
        //}

        [HttpPut("{email}")]
        [Authorize(Roles = "Admin")]
        [ActionName("ChangePassAdmin")]
        public async Task<ActionResult<int>> ChangePass(string email, UserModel userModel)
        {
            if (email != userModel.UserEmail)
            {
                return BadRequest();
            }
            try
            {
                await _authentication.ChangePasswordAdmin(email, userModel);
                userModel.UserEmail = email;
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        [HttpPut("{teachercode}")]
        [Authorize(Roles = "Giang Vien")]
        [ActionName("ChangePassTeacher")]
        public async Task<ActionResult<int>> ChangePassTeacherCode(string teachercode, UserModel userModel)
        {
            if (teachercode != userModel.UserTeacherCode)
            {
                return BadRequest();
            }
            try
            {
                await _authentication.ChangePasswordTeacherCode(teachercode, userModel);
                userModel.UserTeacherCode = teachercode;
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        [HttpPut("{studentcode}")]
        [Authorize(Roles = "Sinh Vien")]
        [ActionName("ChangePassStudent")]
        public async Task<ActionResult<int>> ChangePassStudentCode(string studentcode, UserModel userModel)
        {
            if (studentcode != userModel.UserStudentCode)
            {
                return BadRequest();
            }
            try
            {
                await _authentication.ChangePasswordStudentCode(studentcode, userModel);
                userModel.UserStudentCode = studentcode;
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }
    }
}