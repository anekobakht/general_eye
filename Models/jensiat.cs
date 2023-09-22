﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class jensiat
    {
        [Key]
        public Int64 id_jensiat { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان جنسیت")]
        [Required(ErrorMessage = "لطفا عنوان جنسیت را مشخص نمایید")]
        public string name_jensiat { get; set; }
        //**********************************************************************
    }
}
