
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
    
public partial class BringHomePay
{

    public int id { get; set; }

    public string Name { get; set; }

    public Nullable<float> amount { get; set; }

    public string DayOfWeek { get; set; }

    public string Frequency { get; set; }

    public Nullable<System.DateTime> PickOnePayDate { get; set; }

    public string UserID { get; set; }



    public virtual AspNetUser AspNetUser { get; set; }

}

}
