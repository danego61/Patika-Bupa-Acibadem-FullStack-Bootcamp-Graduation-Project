using Graduation.Project.Entity.Dto;
using Graduation.Project.Entity.IBase;
using Graduation.Project.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Graduation.Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            IResponse<List<DtoProduct>> response = productService.GetAll<DtoProduct>();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{productId:decimal}")]
        public IActionResult GetProduct(decimal productId)
        {
            IResponse<DtoProduct> response = productService.Find<DtoProduct>(productId);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public IActionResult AddProduct(DtoAddProduct newProduct)
        {
            IResponse<DtoProduct> response = productService.AddProduct<DtoProduct>(newProduct);
            if (response.StatusCode == StatusCodes.Status201Created)
                return CreatedAtAction(nameof(GetProduct), new { productId = response.Data.ProductId }, response);
            return StatusCode(response.StatusCode, response);
        }

    }
}
