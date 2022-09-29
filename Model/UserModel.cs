using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    public enum Gender
    {
        [Display(Name = "Nam")]
        Nam = 1,
        [Display(Name = "Nữ")]
        Nu = 2
    }

    [Table("User")]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Họ")]
        [StringLength(20)]
        public string UserSurname { get; set; }

        [Display(Name = "Tên Đệm và Tên")]
        [StringLength(30)]
        public string UserFisrtName { get; set; }

        [NotMapped]
        public string User { get; set; }

        [Display(Name = "Mã Giảng Viên")]
        [Column(TypeName = "varchar(20)"), MaxLength(50)]
        public string UserTeacherCode { get; set; }

        [Display(Name = "Mã Số Thuế")]
        [Column(TypeName = "varchar(20)"), MaxLength(50)]
        public string UserTaxCode { get; set; }

        [Display(Name = "Mã Học Viên")]
        [Column(TypeName = "varchar(20)"), MaxLength(50)]
        public string UserStudentCode { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string UserPhone { get; set; }

        [Display(Name = "Địa Chỉ")]
        [StringLength(200)]
        public string UserAddress { get; set; }


        [Display(Name = "Giới Tính")]
        public Gender UserGender { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime UserBirthday { get; set; }

        [Display(Name = "Tên Phụ Huynh")]
        [StringLength(200)]
        public string UserParentName { get; set; }

        [Display(Name = "Hình Ảnh Đại Diện")]
        [Column(TypeName = "varchar(200)"), MaxLength(100)]
        public string UserImg { get; set; }

        [NotMapped]
        public IFormFile UploadImg { get; set; }

        [Display(Name = "Lớp Học")]
        //[ForeignKey("classModel")]
        public int UserClass { get; set; }

        [Display(Name = "Môn Dạy Chính")]
        [StringLength(200)]
        public string UserMainSubject { get; set; }

        [Display(Name = "Môn Kiêm Nhiệm")]
        [StringLength(200)]
        public string UserParttimeSubject { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string UserCofirmPassword { get; set; }

        [ForeignKey("roleModel")]
        public int UserRole { get; set; }

        public bool UserBlock { get; set; }

        public bool UserStatus { get; set; }

        public bool IsDelete { get; set; }

        public RoleModel roleModel { get; set; }

        public ClassModel classModel { get; set; }
    }
}