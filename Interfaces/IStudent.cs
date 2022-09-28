using CourseSignupSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignupSystem.Interfaces
{
    public interface IStudent
    {
        Task<int> RegisterClass(RegisterClass registerClass);

        Task<List<RegisterClass>> GetRegistClass();

        Task<List<RegisterClass>> RegistClassId(RegisterClass registerClass);
    }
}