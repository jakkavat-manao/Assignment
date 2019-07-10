using Assignment.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Core.Domain.Entities
{
    public class Customer : EntityBase<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Mobile { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
