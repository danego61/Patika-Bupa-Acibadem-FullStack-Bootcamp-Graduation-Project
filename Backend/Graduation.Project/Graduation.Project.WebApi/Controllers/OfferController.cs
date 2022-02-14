using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {

        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet]
        public IActionResult GetOffers([FromQuery] DtoOfferQuery query)
        {
            IResponse<List<DtoOffer>> response = offerService.GetOffers<DtoOffer>(query);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{offerNumber:int}")]
        public IActionResult GetOffer(decimal offerNumber)
        {
            IResponse<DtoOffer> response = offerService.Find<DtoOffer>(offerNumber);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public IActionResult AddOffer(DtoAddOffer newOffer)
        {
            IResponse<DtoOffer> response = offerService.AddOffer<DtoOffer>(newOffer);
            if (response.StatusCode == StatusCodes.Status201Created)
                return CreatedAtAction(nameof(GetOffer), new { offerNumber = response.Data.OfferNumber }, response);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{offerNumber:int}/addOfferDetail")]
        public IActionResult AddOfferDetail(decimal offerNumber, DtoAddOfferDetails offerDetail)
        {
            IResponse response = offerService.AddOfferDetail(offerNumber, offerDetail);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{offerNumber:int}/completeOfferDetail")]
        public IActionResult CompleteOfferDetails(decimal offerNumber)
        {
            IResponse response = offerService.CompleteOfferDetails(offerNumber);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{offerNumber:int}/updateProduct")]
        public IActionResult UpdateOfferProduct(decimal offerNumber, DtoUpdateOfferProduct updateOfferProduct)
        {
            IResponse response = offerService.UpdateOfferProduct(offerNumber, updateOfferProduct);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{offerNumber:int}/updateInstallment")]
        public IActionResult UpdateOfferInstallment(decimal offerNumber, DtoUpdateOfferInstallment updateOfferInstallment)
        {
            IResponse response = offerService.UpdateOfferInstallment(offerNumber, updateOfferInstallment);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("{offerNumber:int}/payBill")]
        public IActionResult OfferPayBill(decimal offerNumber, DtoAddBillPayment billPayment)
        {
            billPayment.OfferId = offerNumber;
            IResponse response = offerService.OfferPayBill(billPayment);
            return StatusCode(response.StatusCode, response);
        }

    }
}
