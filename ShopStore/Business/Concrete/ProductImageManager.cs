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
	public class ProductImageManager:IProductImageService
	{
		IProductImageDal productImageDal;

		public ProductImageManager(IProductImageDal productImageDal)
		{
			this.productImageDal = productImageDal;
		}

		public ProductImage Add(ProductImage productImage)
		{
			return productImageDal.Add(productImage);
		}

		public List<ProductImage> GetAll()
		{
			return productImageDal.GetAll();
		}
	}
}
