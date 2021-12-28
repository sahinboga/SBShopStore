using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
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
		IProductImageService _productImageService=new ProductImageManager(new EfProductImageDal());
		IImageService _imageService=new ImageManager(new EfImageDal());
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

		public object GetAllByCategoryId(int? id)
		{
			throw new NotImplementedException();
		}

		public void ProductAdd(AddProductDto dto)
		{
			var addProduct=productDal.Add(dto.Products);
			foreach (var item in dto.Images)
			{
				var addImage=_imageService.ImageAdd(new Image() {ImageId=0, ImagePath=item});
				_productImageService.Add(new ProductImage() { ImageId = addImage.ImageId, ProductId = addProduct.ProductId });
			}
		}

		public void UpdateProduct(Product product)
		{
			productDal.Update(product);
		}

		public List<Product> GetAllByCategoryId(int categoryId)
		{
			return categoryId == 0 ? productDal.GetAll() : productDal.GetAll(x => x.CategoryId == categoryId);
		}
	}
}
