using CourseSignupSystem.Interfaces;
using CourseSignupSystem.Models;
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
        [Route("ListRegisterClass")]
        public async Task<ActionResult<IEnumerable<RegisterClass>>> ListRegisterClass()
        {
            var list = await _studentSvc.GetRegistClass();
            return list;
        }

        [HttpGet]
        [Route("RegisterClassId")]
        public async Task<ActionResult<IEnumerable<RegisterClass>>> RegisterClassId(RegisterClass registerClass)
        {
            var list = await _studentSvc.RegistClassId(registerClass);
            return list;
        }

        [HttpPost]
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