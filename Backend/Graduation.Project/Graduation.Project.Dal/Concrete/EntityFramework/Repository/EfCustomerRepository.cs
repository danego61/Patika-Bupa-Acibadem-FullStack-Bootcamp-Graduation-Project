using Graduation.Project.Dal.Abstract;
using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation.Project.Dal.Concrete.EntityFramework.Repository
{
    public class EfCustomerRepository : EfGenericRepository<Customer>, ICustomerRepository
    {

        private readonly IProcedureFunctions procedure;

        public EfCustomerRepository(DbContext context, IProcedureFunctions procedure) : base(context)
        {
            this.procedure = procedure;
        }

        public Customer AddCustomer(DtoAddCustomer customer)
        {
            return new Customer
            {
                Address = customer.Address,
                Birthdate = customer.Birthdate,
                CustomerId = procedure.SpAddCustomer(customer),
                Gender = customer.Gender,
                Gsm = customer.Gsm,
                Mail = customer.Mail,
                Name = customer.Name,
                Passaport = customer.Passaport,
                Surname = customer.Surname,
                TcNo = customer.TcNo
            };
        }
    }
}
