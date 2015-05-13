using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Rest_web_service_for_android.Controllers
{
	public class ProductsController : ApiController
	{
		private AndroidEntities androidEntities = new AndroidEntities();

		public IEnumerable<Product> Get()
		{
			return androidEntities.Products.AsEnumerable();
		}

		public Product Get(int id)
		{
			return androidEntities.Products.Where(x => x.Id == id).FirstOrDefault();
		}

		public Product Post(string name, decimal price, string description)
		{
			Product product = new Product()
			{
				Name = name,
				Price = price,
				Description = description
			};

			androidEntities.Products.Add(product);
			androidEntities.SaveChanges();
			return product;
		}

		public Product Post(Product product)
		{
			Product foundProduct = androidEntities.Products.Where(x => x.Id == product.Id).FirstOrDefault();
			if (foundProduct != null)
			{
				foundProduct.Name = product.Name;
				foundProduct.Price = product.Price;
				foundProduct.Description = product.Description;
			}
			androidEntities.SaveChanges();
			return foundProduct;
		}

		public void Delete(int id)
		{
			Product product = androidEntities.Products.Where(x => x.Id == id).FirstOrDefault();
			if (product != null)
			{
				androidEntities.Products.Remove(product);
			}
			androidEntities.SaveChanges();
		}
	}
}