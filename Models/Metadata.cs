using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillsWebApp.Models
{
    public class MonthlyBillMetadata
    {

        [StringLength(50)]
        [Display(Name = "Bill")]
        public string Bill;

        [Range(0,31)]
        [Display(Name = "Date")]
        public Nullable<float> Date;

        [StringLength(50)]
        [Display(Name = "BillAlias")]
        public string BillAlias;
    }
    public class UpcomingBillMetadata
    {

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "TheDate")]
        public Date TheDate;


    }
}