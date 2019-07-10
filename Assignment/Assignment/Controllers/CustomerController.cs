using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Core.Domain.Entities;
using Assignment.Core.DTO;
using Assignment.Core.Query;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpGet("GetById")]
        public ActionResult<CustomerDTO> GetById(int customerId, string email)
        {
            //var asdas = CustomerDTOsMock.Where(x => x.email == customerQuery.Email || x.customerID == customerQuery.CustomerId).SingleOrDefault();
            return new CustomerDTO()
            {
                CustomerID = 123456,
                Name = "Firstname Lastname",
                Email = "user @domain.com",
                Mobile = "0123456789",
                transactions = new List<Transaction>() {
                    new Transaction() {
                        Id = 1,
                        Date = DateTime.Now,
                        Amount = 1234.56M,
                        Currency = "USD",
                        Status = TransactionStatus.Success
                    }
                }
            };
        }


    }
}
