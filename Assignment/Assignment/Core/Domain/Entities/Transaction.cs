using Assignment.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Core.Domain.Entities
{
    public class Transaction : EntityBase<int>
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public TransactionStatus Status { get; set; }
    }

    public enum TransactionStatus
    {
        Success,
        Failed,
        Canceled
    }

}
