using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Core.Domain.Entities;
using Assignment.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Assignment.Helpers;
using WebAPI.Infrastructure.DAL.EF.Repositories;
using Assignment.ActionFilters;
using System.ComponentModel.DataAnnotations;
using Assignment.ActionFilters.Customer;

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
        [ValidateGetById]
        public ActionResult<CustomerDTO> GetById(int id)
        {
            var customer = customerRepository.GetByCustomerId(id);

            if (customer == null)
                return NotFound();

            return new ObjectResult(customer);
        }

        [HttpGet("get-by-email")]
        [ValidateGetByEmail]
        public ActionResult<CustomerDTO> GetByEmail(string email)
        {
            var customer = customerRepository.GetByCustomerEmail(email);

            if (customer == null)
                return NotFound();

            return new ObjectResult(customer);
        }

        [HttpGet("get-by-id-and-email")]
        [ValidateGetByIdAndEmail]
        public ActionResult<CustomerDTO> GetByIdAndEmail(int id, string email)
        {
            var customer = customerRepository.GetByIdAndEmail(id, email);

            if (customer == null)
                return NotFound();

            return new ObjectResult(customer);
        }


    }
}
