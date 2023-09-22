using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace general_cheshm.Models
{
    public class mobile
    {
        [Key]
        public Int64 id_mobile { get; set; }
        //**********************************************************************
        [Display(Name = "شماره همراه")]
        [Required(ErrorMessage = "لطفا شماره همراه را وارد نمایید")]
        public string num_mobile { get; set; }
        //**********************************************************************
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        public string fname_mobile { get; set; }
        //**********************************************************************
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد نمایید")]
        public string lname_mobile { get; set; }
        //**********************************************************************

    }
}
