using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    [Table("Role")]
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }
}
