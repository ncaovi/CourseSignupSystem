using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignupSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent _studentSvc;

        public StudentController(IStudent studentSvc)
        {
            _studentSvc = studentSvc;
        }

        [HttpGet]
        [Authorize(Roles = "Sinh Vien")]
        [Route("ListRegisterClass")]
        public async Task<ActionResult<IEnumerable<RegisterClass>>> ListRegisterClass()
        {
            var list = await _studentSvc.GetRegistClass();
            return list;
        }

        [Authorize(Roles = "Sinh Vien")]
        [HttpGet]
        [Route("RegisterClassId")]
        public async Task<ActionResult<IEnumerable<RegisterClass>>> RegisterClassId(RegisterClass registerClass)
        {
            var list = await _studentSvc.RegistClassId(registerClass);
            return list;
        }

        [HttpPost]
        [Authorize(Roles = "Sinh Vien")]
        [Route("RegisterClass")]
        public async Task<ActionResult<int>> RegisterClass(RegisterClass registerClass)
        {
            try
            {
                var id = await _studentSvc.RegisterClass(registerClass);
                registerClass.RegisterClassId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }
    }
}