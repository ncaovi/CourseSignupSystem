using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseSignupSystem.Models
{
    public enum Status
    {
        [Display(Name = "Đã Đóng Học Phí")]
        True = 1,
        [Display(Name = "Chưa Đóng Học Phí")]
        False = 2
    }

    [Table("Receipts")]
    public class ReceiptsModel
    {
        [Key]
        public int ReceiptsId { get; set; }

        [ForeignKey("userModel")]
        public int ReceiptsStudentId { get; set; }



        [Display(Name = "Lớp Học")]
        [StringLength(30)]
        public string ReceiptsClassName { get; set; }

        [Display(Name = "Khóa Đào Tạo")]
        [StringLength(30)]
        public string ReceiptsTraining { get; set; }

        [Display(Name = "Thu Phí")]
        public double ReceiptsFee { get; set; }

        [Display(Name = "Loại Học Phí")]
        [StringLength(30)]
        public string ReceiptsTypeFee { get; set; }

        [Display(Name = "Mức Thu Phí")]
        public double ReceiptsRateFee { get; set; }

        [Display(Name = "Giảm Giá")]
        public int ReceiptsDiscount { get; set; }

        [Display(Name = "Ghi Chú")]
        [StringLength(50)]
        public string ReceiptsNote { get; set; }

        [Display(Name = "Phí Phụ Thu ")]
        public double ReceiptsSurcharge { get; set; }


        [Display(Name = "Mức Phí Phải Thu")]
        public double ReceiptsPayableFee { get; set; }

        [Display(Name = "Trạng Thái")]
        [Range(1, int.MaxValue)]
        public Status ReceiptsStatus { get; set; }

        public UserModel userModel { get; set; }

    }
}