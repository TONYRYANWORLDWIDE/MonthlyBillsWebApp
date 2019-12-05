using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;

namespace MonthlyBillsWebApp.ViewModels
{
    public class ViewModelMonthlyWeekly // System.Collections.IEnumerable
    {

        public List<MonthlyBill> monthlyBills { get; set; }
        public List<WeeklyBill> weeklyBills { get; set; }
        //public IQueryable<MonthlyBill> monthlyBills { get; set; }
        //public IQueryable<WeeklyBill> weeklyBills { get; set; }

        //public IEnumerator GetEnumerator()
        //{
        //    return ((IEnumerable)monthlyBills).GetEnumerator();
        //}

        //public MonthlyBill monthlyBills { get; set; }
        //public WeeklyBill weeklyBills { get; set; }

        //public virtual AspNetUser AspNetUser { get; set; }

        //public string BillAlias { get; set; }
        //public string DayOfWeek { get; set; }
    }
}