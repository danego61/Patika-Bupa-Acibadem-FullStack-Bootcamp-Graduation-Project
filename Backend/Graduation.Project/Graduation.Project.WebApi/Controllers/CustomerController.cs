using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet("{customerId:length(9)}")]
        public IActionResult GetCustomer(string customerId)
        {
            IResponse<DtoCustomer> response = customerService.Find<DtoCustomer>(customerId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet]
        public IActionResult GetCustomerByGsm(string telephoneNumber)
        {
            IResponse<DtoCustomer> response = customerService.Get<DtoCustomer>(x => x.Gsm == telephoneNumber);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public IActionResult AddCustomer(DtoAddCustomer customer)
        {
            IResponse<DtoCustomer> response = customerService.AddCustomer<DtoCustomer>(customer);
            if (response.StatusCode == StatusCodes.Status201Created)
                return CreatedAtAction(nameof(GetCustomer), new { customerId = response.Data.CustomerId }, response);
            return StatusCode(response.StatusCode, response);
        }

    }
}
