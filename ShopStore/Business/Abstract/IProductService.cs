using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IProductService
	{
		List<Product> GetAll();
		void ProductAdd(AddProductDto dto);
		Product GetById(int id);
		void DeleteProduct(Product product);
		void UpdateProduct(Product product);
		List<Product> GetAllByCategoryId(int categoryId);
	}
}
