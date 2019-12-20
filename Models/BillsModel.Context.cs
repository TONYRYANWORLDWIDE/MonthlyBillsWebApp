﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class BillsEntities : DbContext
{
    public BillsEntities()
        : base("name=BillsEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<MonthlyBill> MonthlyBills { get; set; }

    public virtual DbSet<WeeklyBill> WeeklyBills { get; set; }

    public virtual DbSet<BringHomePay> BringHomePays { get; set; }

    public virtual DbSet<Date> Dates { get; set; }

    public virtual DbSet<UpcomingBill> UpcomingBills { get; set; }

    public virtual DbSet<KeyBalance> KeyBalances { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<UpcomingBills_Alter> UpcomingBills_Alter { get; set; }


    public virtual int sp_DateOfEachBill()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DateOfEachBill");
    }


    public virtual int sp_Cleanup_UpcomingBill_Alter()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_Cleanup_UpcomingBill_Alter");
    }


    public virtual int sp_DateOfEachBill_WithParameter(string aSPUser)
    {

        var aSPUserParameter = aSPUser != null ?
            new ObjectParameter("ASPUser", aSPUser) :
            new ObjectParameter("ASPUser", typeof(string));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DateOfEachBill_WithParameter", aSPUserParameter);
    }

}

}

