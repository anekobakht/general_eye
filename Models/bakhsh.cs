﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class bakhsh
    {
        [Key]
        public Int64 id_bakhsh { get; set; }
        //**********************************************************************
        [Display(Name = "عنوان بخش")]
        [Required(ErrorMessage = "لطفا عنوان بخش را وارد نمایید")]
        public string name_bakhsh { get; set; }
        //**********************************************************************

    }
}
