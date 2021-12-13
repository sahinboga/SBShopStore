using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal productDal;
		public ProductManager(IProductDal productDal)
		{
			this.productDal = productDal;
		}
		public void DeleteProduct(Product product)
		{
			productDal.Delete(product);
		}

		public List<Product> GetAll()
		{
			return productDal.GetAll();
		}

		public Product GetById(int id)
		{
			return productDal.GetById(x=>x.ProductId==id);
		}

		public void ProductAdd(Product product)
		{
			productDal.Add(product);
		}

		public void UpdateProduct(Product product)
		{
			productDal.Update(product);
		}
	}
}
