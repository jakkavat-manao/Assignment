using Assignment.Core.Domain.Entities;
using Assignment.Core.DTO;
using Assignment.Infrastructures.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AssignmentDbContext assignmentDbContext;
        public CustomerRepository(AssignmentDbContext assignmentDbContext)
        {
            this.assignmentDbContext = assignmentDbContext;
        }
        public IEnumerable<CustomerDTO> GetAll()
        {
            return assignmentDbContext.Customers.Include(x => x.Transactions).Select(x => x.ToDTO());
        }
        public bool Add(CustomerDTO item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(CustomerDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
