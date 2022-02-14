using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {

        private readonly IPolicyService policyService;

        public PolicyController(IPolicyService policyService)
        {
            this.policyService = policyService;
        }

        [HttpGet]
        public IActionResult GetPolicies([FromQuery] DtoPolicyQuery query)
        {
            IResponse<List<DtoPolicy>> response = policyService.GetPolicies<DtoPolicy>(query);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{policyNumber:int}")]
        public IActionResult GetPolicy(decimal policyNumber)
        {
            IResponse<DtoPolicy> response = policyService.Find<DtoPolicy>(policyNumber);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public IActionResult AddPolicy(DtoAddPolicy newPolicy)
        {
            IResponse<DtoPolicy> response = policyService.AddPolicy<DtoPolicy>(newPolicy);
            if (response.StatusCode == StatusCodes.Status201Created)
                return CreatedAtAction(nameof(GetPolicy), new { policyNumber = response.Data.PolicyId }, response);
            return StatusCode(response.StatusCode, response);
        }

    }
}
