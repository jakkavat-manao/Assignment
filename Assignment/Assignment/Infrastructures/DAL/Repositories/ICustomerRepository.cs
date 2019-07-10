using Assignment.Core.Domain.Entities;
using Assignment.Core.DTO;
using Assignment.Infrastructures.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Infrastructure.Repositories
{
    public interface ICustomerRepository: IRepository<CustomerDTO>
    {
        CustomerDTO GetByCustomerId(int id);
        CustomerDTO GetByCustomerEmail(string email);
        CustomerDTO GetByIdAndEmail(int id, string email);
    }
}
