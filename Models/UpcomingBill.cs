//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonthlyBillsWebApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UpcomingBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UpcomingBill()
        {
            this.UpcomingBills_Alter = new HashSet<UpcomingBills_Alter>();
        }
    
        public int id { get; set; }
        public Nullable<System.DateTime> TheDate { get; set; }
        public string DayOfWeek { get; set; }
        public string Name { get; set; }
        public Nullable<float> Amount { get; set; }
        public string Type { get; set; }
        public Nullable<decimal> RunningTotal { get; set; }
        public string UserID { get; set; }
        public Nullable<bool> Paid_ { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UpcomingBills_Alter> UpcomingBills_Alter { get; set; }
    }
}
