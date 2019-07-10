using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Core.Domain.Entities;
using Assignment.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Infrastructure.Repositories;
using Assignment.Helpers;

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

        [HttpGet("get-by-id")]
        public ActionResult<CustomerDTO> GetById(int id)
        {
            if (!id.IsValidCustomerId())
                return BadRequest();

            var customer = customerRepository.GetByCustomerId(id);

            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpGet("get-by-email")]
        public ActionResult<CustomerDTO> GetByEmail(string email)
        {
            if (!email.IsValidEmail())
                return BadRequest();

            var customer = customerRepository.GetByCustomerEmail(email);

            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpGet("get-by-id-and-email")]
        public ActionResult<CustomerDTO> GetByIdAndEmail(int id, string email)
        {
            if (!email.IsValidEmail() || !id.IsValidCustomerId())
                return BadRequest();

            var customer = customerRepository.GetByIdAndEmail(id, email);

            if (customer == null)
                return NotFound();

            return customer;
        }


    }
}
