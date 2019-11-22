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
        [Range(0, 31)]
        [Display(Name = "Date")]
        public Nullable<float> Date;

        [Required]
        [Display(Name = "Cost")]
        public Nullable<float> Cost;

        //[Required]
        //[StringLength(50)]
        //[Display(Name = "BillAlias")]
        //public string BillAlias;
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

    public class KeyBalancemetadata
    {

        [Required]
        [Display(Name = "Bank Balance")]
        public float KeyBalance1;
    }

    public class BringHomePaymetadata
    {

        [Required]
        [Display(Name = "Name")]
        public string Name;

        [Required]
        [Display(Name = "amount")]
        public float amount;

        [Required]
        [Display(Name = "DayOfWeek")]
         public string DayOfWeek;

        [Required]
        [Display(Name = "Frequency")]
        public string Frequency;


        [Required]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = false)]

        [Display(Name = "PickOnePayDate")]
        //public Date PickOnePayDate;
        public DateTime PickOnePayDate;




    }


}


