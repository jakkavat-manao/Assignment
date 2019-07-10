using Assignment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Core.DTO
{
    public class TransactionDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}
