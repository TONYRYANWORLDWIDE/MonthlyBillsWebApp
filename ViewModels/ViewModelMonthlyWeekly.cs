using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MonthlyBillsWebApp.Models;

namespace MonthlyBillsWebApp.ViewModels
{
    public class ViewModelMonthlyWeekly
    {

        //public List<MonthlyBill> monthlyBills { get; set; }
        //public List<WeeklyBill> weeklyBills { get; set; }
        public IOrderedQueryable<MonthlyBill> monthlyBills { get; set; }
        public IOrderedQueryable<WeeklyBill> weeklyBills { get; set; }

        //public MonthlyBill monthlyBills { get; set; }
        //public WeeklyBill weeklyBills { get; set; }

        //public string BillAlias { get; set; }
        //public string DayOfWeek { get; set; }
    }
}