using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<ResultProductWCategoryNameDto> GetProductsWithCategoryName();
        int ProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNamePasta();
        string ProductNameByMaxPrice();
        string ProductNameByMinPrice();
        decimal ProductPriceAvg();
        decimal ProductPriceAvgForHamburger();
    }
}
