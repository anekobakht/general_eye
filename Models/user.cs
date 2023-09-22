using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_eye.Models
{
    public class user
    {
        [Key]
        public Int64 user_id { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام و نام خانوادگی را وارد نمایید")]
        public string? flname { get; set; }
        //**********************************************************************
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        public string? username { get; set; }
        //**********************************************************************
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد نمایید")]
        public string? userpass { get; set; }
        //**********************************************************************
        [Display(Name = "مدیر سیستم می باشد؟")]
        [Required(ErrorMessage = "لطفا ماهیت مدیر سیستم را مشخص نمایید")]
        public bool? admin { get; set; }
        //**********************************************************************


    }
}
