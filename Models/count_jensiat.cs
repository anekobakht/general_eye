﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class count_jensiat
    {
        [Display(Name = "تعداد")]
        public int count { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان جنسیت")]
        public string name_jensiat { get; set; }
        //**********************************************************************
    }
}
