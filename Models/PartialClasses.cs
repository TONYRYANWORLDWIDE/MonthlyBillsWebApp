using System;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillsWebApp.Models
{
    [MetadataType(typeof(MonthlyBillMetadata))]
    public partial class MonthlyBill
    {
    }
    [MetadataType(typeof(UpcomingBillMetadata))]
    public partial class UpcomingBill
    {
    }
    [MetadataType(typeof(WeeklyBillsMetadata))]
    public partial class WeeklyBill
    {
    }


}