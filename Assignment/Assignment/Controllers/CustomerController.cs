using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Core.Domain.Entities;
using Assignment.Core.DTO;
using Assignment.Core.Query;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure.Repositories;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet("get-all")]
        public ActionResult<IEnumerable<CustomerDTO>> GetAll()
        {
            return customerRepository.GetAll().ToList();
        }

    }
}
