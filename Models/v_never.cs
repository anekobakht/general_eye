using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class v_never
    {
        [Display(Name = "کاربر سیستم")]
        public string? u_flname { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان خطا")]
        public string? name_khata { get; set; }
        //**********************************************************************
        [Key]
        [Display(Name = "شناسه ثبت")]
        public Int64? id_never { get; set; }
        //**********************************************************************
        [Display(Name = "نام و نام خانوادگی بیمار")]
        public string? demo_bimar_name_never { get; set; }
        //**********************************************************************
        [Display(Name = "جنسیت")]
        public string? demo_jensiat_never { get; set; }
        //**********************************************************************
        [Display(Name = "سن بیمار")]
        public Int64? demo_sen_never { get; set; }
        //**********************************************************************
        [Display(Name = "تاریخ مراجعه")]
        public string? demo_date_morajee_never { get; set; }
        //**********************************************************************
        [Display(Name = "تاریخ وقوع")]
        public string? demo_date_voghu_never { get; set; }
        //**********************************************************************
        [Display(Name = "ساعت")]
        public string? demo_saat_never { get; set; }
        //**********************************************************************
        [Display(Name = "پیوست اول")]
        public byte[]? peyvast1_never { get; set; }
        //**********************************************************************
        [Display(Name = "پیوست دوم")]
        public byte[]? peyvast2_never { get; set; }
        //**********************************************************************
        [Display(Name = "کد خطا")]
        public Int64 num_khata { get; set; }
        //**********************************************************************
        [Display(Name = "شرح خطا")]
        public string? sharh_never { get; set; }
        //**********************************************************************
        [Display(Name = "نام بخش")]
        public string? name_bakhsh { get; set; }
        //**********************************************************************


    }
}
