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


}