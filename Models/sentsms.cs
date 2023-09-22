﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class sentsms
    {
        [Key]
        public Int64 id_sentsms { get; set; }
        //**********************************************************************
        [Display(Name = "شناسه شماره همراه")]
        public Int64 id_user{ get; set; }
        //**********************************************************************
        [Display(Name = "شناسه ثبت خطا")]
        public Int64 id_never { get; set; }
        //**********************************************************************
        [Display(Name = "وضعیت ارسال پیام")]
        public string status { get; set; }
        //**********************************************************************
    }
}
