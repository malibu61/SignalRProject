using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

		public List<Product> GetLast9Products()
		{
			using (var context = new SignalRContext())
			{
				var values = context.Products.OrderBy(x=>x.ProductID).Take(9).ToList();
				return values;
			}
		}

		public List<ResultProductWCategoryNameDto> GetProductsWithCategoryName()
        {
            using (var context = new SignalRContext())
            {
                var values = context.Products.Include(x => x.Category).Select(p => new ResultProductWCategoryNameDto
                {
                    ProductId = p.ProductID,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    CategoryName = p.Category.CategoryName // burada Category'den alıyoruz
                }).ToList();
                return values;
            }
        }

        public int ProductCount()
        {
            using (var context = new SignalRContext())
            {
                var value = context.Products.Count();
                return value;
            }
        }

        public int ProductCountByCategoryNameHamburger()
        {
            using (var context = new SignalRContext())
            {
                var valueCategory = context.Categories.Where(x => x.CategoryName == "Hamburger").Select(y => y.CategoryId).FirstOrDefault();

                var valuesProductCount = context.Products.Where(x => x.CategoryId == valueCategory).Count();
                return valuesProductCount;
            }

            //using (var context = new SignalRContext())
            //{
            //    "Hamburger" isimli kategorinin ID'sini alıyoruz
            //    var valueCategory = context.Categories
            //                            .Where(x => x.CategoryName == "Hamburger")
            //                            .Select(x => x.CategoryId)
            //                            .FirstOrDefault(); // veya SingleOrDefault()

            //    Bu kategoriye ait ürünleri sayıyoruz
            //   var valuesProductCount = context.Products
            //                             .Where(x => x.CategoryId == valueCategory)
            //                             .Count();

            //    return valuesProductCount;
            //}
        }

        public int ProductCountByCategoryNamePasta()
        {
            using (var context = new SignalRContext())
            {
                var valueCategory = context.Categories.Where(x => x.CategoryName == "Makarna").Select(y => y.CategoryId).FirstOrDefault();

                var valuesProductCount = context.Products.Where(x => x.CategoryId == valueCategory).Count();
                return valuesProductCount;
            }
        }

        public string ProductNameByMaxPrice()
        {
            using (var context = new SignalRContext())
            {
                var valuePrice = context.Products.Max(x => x.Price);
                var valuesProductName = context.Products.Where(x => x.Price == valuePrice).Select(x => x.ProductName).FirstOrDefault();
                return valuesProductName;
            }
        }

        public string ProductNameByMinPrice()
        {
            using (var context = new SignalRContext())
            {
                var valuePrice = context.Products.Min(x => x.Price);
                var valuesProductName = context.Products.Where(x => x.Price == valuePrice).Select(x => x.ProductName).FirstOrDefault();
                return valuesProductName;
            }
        }

        public decimal ProductPriceAvg()
        {
            using (var context = new SignalRContext())
            {
                var value = context.Products.Average(x => x.Price);
                return value;
            }
        }

        public decimal ProductPriceAvgForHamburger()
        {
            using (var context = new SignalRContext())
            {
                var value = context.Products.Where(x => x.CategoryId == 1).Average(x => x.Price);
                return value;
            }
        }
    }
}
