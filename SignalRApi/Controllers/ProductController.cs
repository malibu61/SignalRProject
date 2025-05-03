using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            return Ok("Ürün Bilgisi Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Ürün Bilgisi Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(_mapper.Map<GetByIdProductDto>(value));
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Ürün Bilgisi Güncellendi");
        }

        [HttpGet("ProductWCategoryName")]
        public IActionResult ProductWCategoryName()
        {
            var value = _productService.TGetProductsWithCategoryName();
            return Ok(value);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TProductCount());
        }

        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            return Ok(_productService.TProductCountByCategoryNameHamburger());
        }

        [HttpGet("ProductCountByCategoryNamePasta")]
        public IActionResult ProductCountByCategoryNamePasta()
        {
            return Ok(_productService.TProductCountByCategoryNamePasta());
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            return Ok(_productService.TProductNameByMaxPrice());
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            return Ok(_productService.TProductNameByMinPrice());
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            return Ok(_productService.TProductPriceAvg());
        }

        [HttpGet("ProductPriceAvgForHamburger")]
        public IActionResult ProductPriceAvgForHamburger()
        {
            return Ok(_productService.TProductPriceAvgForHamburger());
        }

        //[HttpGet("TotalPriceByDrinkCategory")]
        //public IActionResult TotalPriceByDrinkCategory()
        //{
        //    return Ok(_productService.TTotalPriceByDrinkCategory());
        //}

        //[HttpGet("TotalPriceBySaladCategory")]
        //public IActionResult TotalPriceBySaladCategory()
        //{
        //    return Ok(_productService.TTotalPriceBySaladCategory());
        //}







        //[HttpGet("ProductCountByHamburger")]
        //public IActionResult ProductCountByHamburger()
        //{
        //    return Ok(_productService.TProductCountByCategoryNameHamburger());
        //}

        //[HttpGet("ProductCountByDrink")]
        //public IActionResult ProductCountByDrink()
        //{
        //    return Ok(_productService.TProductCountByCategoryNameDrink());
        //}

        //[HttpGet("ProductPriceAvg")]
        //public IActionResult ProductPriceAvg()
        //{
        //    return Ok(_productService.TProductPriceAvg());
        //}

        //[HttpGet("ProductPriceBySteakBurger")]
        //public IActionResult ProductPriceBySteakBurger()
        //{
        //    return Ok(_productService.TProductPriceBySteakBurger());
        //}



        //[HttpGet("ProductListWithCategory")]
        //public IActionResult ProductListWithCategory()
        //{
        //    var context = new SignalRContext();
        //    var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
        //    {
        //        Description = y.Description,
        //        ImageUrl = y.ImageUrl,
        //        Price = y.Price,
        //        ProductID = y.ProductID,
        //        ProductName = y.ProductName,
        //        ProductStatus = y.ProductStatus,
        //        CategoryName = y.Category.CategoryName
        //    });
        //    return Ok(values.ToList());
        //}


        //[HttpGet("GetLast9Products")]
        //public IActionResult GetLast9Products()
        //{
        //    var value = _productService.TGetLast9Products();
        //    return Ok(value);
        //}
    }
}
