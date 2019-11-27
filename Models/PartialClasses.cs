using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonthlyBillsWebApp.Models
{
    [MetadataType(typeof(MonthlyBillMetadata))]
    public partial class MonthlyBill
    {
        public static implicit operator List<object>(MonthlyBill v)
        {
            throw new NotImplementedException();
        }
    }
    [MetadataType(typeof(UpcomingBillMetadata))]
    public partial class UpcomingBill
    {
    }
    [MetadataType(typeof(WeeklyBillsMetadata))]
    public partial class WeeklyBill
    {
    }
    [MetadataType(typeof(KeyBalancemetadata))]
    public partial class KeyBalance
    {
    }
    [MetadataType(typeof(BringHomePaymetadata))]
    public partial class BringHomePay
    {
    }
}