using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class v_user
    {
        public Int64 id_user { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان بخش")]
        [Required(ErrorMessage = "لطفا عنوان بخش را مشخص نمایید")]
        public string name_bakhsh { get; set; }
        //**********************************************************************
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        public string u_fname { get; set; }
        //**********************************************************************
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد نمایید")]
        public string u_lname { get; set; }
        //**********************************************************************
        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "لطفا کد ملی را وارد نمایید")]
        public string u_code_meli { get; set; }
        //**********************************************************************
        [Display(Name = "پست الکترونیک")]
        public string? u_email { get; set; }
        //**********************************************************************
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        public string u_username { get; set; }
        //**********************************************************************
        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا کلمه عبور را وارد نمایید")]
        public string u_userpass { get; set; }
        //**********************************************************************
        [Display(Name = "مدیر سیستم")]
        public bool u_admin { get; set; }
        //**********************************************************************


    }
}
