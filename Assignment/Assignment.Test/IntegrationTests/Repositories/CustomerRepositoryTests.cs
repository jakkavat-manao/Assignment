using Assignment.Test.Mocks;
using Moq;
using System;
using System.Linq;
using WebAPI.Infrastructure.DAL.EF.Repositories;
using Xunit;

namespace Assignment.Test.UnitTest.Repositories
{
    public class CustomerRepositoryTests
    {
        public readonly ICustomerRepository MockCustomerRepository;
        public CustomerRepositoryTests()
        {
            var customers = MockCustomers.CreateCustomers();
            var customersAndTransactions = MockCustomers.CreateCustomersAndTransactions();
            Mock<ICustomerRepository> mockCustomerRepository = new Mock<ICustomerRepository>();

            mockCustomerRepository.Setup(mr => mr.GetByCustomerId(It.IsAny<int>()))
                .Returns((int i) => customers.Where(x => x.Id == i).Select(x => x.ToDTO()).SingleOrDefault());

            mockCustomerRepository.Setup(mr => mr.GetByCustomerEmail(It.IsAny<string>()))
                .Returns((string email) => 
                    customersAndTransactions.Where(x => x.Email == email).Select(x => x.ToDTO()).SingleOrDefault()
                );

            mockCustomerRepository.Setup(mr => mr.GetByIdAndEmail(It.IsAny<int>(), It.IsAny<string>()))
                .Returns((int id, string email) => 
                    customersAndTransactions.Where(x => x.Id == id && x.Email == email).Select(x => x.ToDTO()).SingleOrDefault()
                );


            this.MockCustomerRepository = mockCustomerRepository.Object;
        }

        [Fact]
        public void GetCustomerDTOById()
        {
            var customers = this.MockCustomerRepository.GetByCustomerId(22);
            Assert.NotNull(customers);
        }

        [Fact]
        public void GetCustomerDTOByEmail()
        {
            var customers = this.MockCustomerRepository.GetByCustomerEmail("mockcustomertransaction1@gmail.com");
            Assert.NotNull(customers);
        }

        [Fact]
        public void GetCustomerDTOByIdAndEmail()
        {
            var customers = this.MockCustomerRepository.GetByIdAndEmail(2, "mockcustomertransaction2@gmail.com");
            Assert.NotNull(customers);
        }
    }
}
