using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillsWebApp.Models
{
    public class MonthlyBillMetadata
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Bill")]
        public string Bill;

        [Required]
        [Range(0,31)]
        [Display(Name = "Date")]
        public Nullable<float> Date;

        [Required]
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
    public class WeeklyBillsMetadata
    {
        [StringLength(50)]
        [Required]
        [Display(Name = "Bill")]
        public string Bill;

        [Required]
        public float Cost;

        [Required]
        public string DayOfWeek;
    }
}