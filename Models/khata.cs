using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class khata
    {
        [Key]
        public Int64 id_khata { get; set; }
        //**********************************************************************
        [Display(Name = "شماره خطا")]
        [Required(ErrorMessage = "لطفا شماره خطا را مشخص نمایید")]
        public Int64 num_khata { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان خطا")]
        [Required(ErrorMessage = "لطفا عنوان خطا را مشخص نمایید")]
        public string name_khata { get; set; }
        //**********************************************************************
        [Display(Name = "ارسال پیامک شود؟")]
        [Required(ErrorMessage = "لطفا وضعیت ارسال پیامک را مشخص نمایید")]
        public bool sms { get; set; }
        //**********************************************************************
    }
}
