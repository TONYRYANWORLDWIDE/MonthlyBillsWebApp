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
    
    public partial class transactionsupdateNew
    {
        public int id { get; set; }
        public long index { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public string originaldescription { get; set; }
        public Nullable<double> amount { get; set; }
        public string amount_transformed { get; set; }
        public string transaction_type { get; set; }
        public string category { get; set; }
        public string account_name { get; set; }
        public string sub_cat { get; set; }
    }
}
