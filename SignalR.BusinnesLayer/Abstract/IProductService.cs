using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinnesLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<ResultProductWCategoryNameDto> TGetProductsWithCategoryName();
        int TProductCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNamePasta();
        string TProductNameByMaxPrice();
        string TProductNameByMinPrice();
        decimal TProductPriceAvg();
        decimal TProductPriceAvgForHamburger();

    }
}
