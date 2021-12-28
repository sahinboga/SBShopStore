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
	public class ImageManager : IImageService
	{
		IImageDal imageDal;

		public ImageManager(IImageDal imageDal)
		{
			this.imageDal = imageDal;
		}

		public void DeleteImage(Image image)
		{
			imageDal.Delete(image);
		}

		public List<Image> GetAll()
		{
			throw new NotImplementedException();
		}

		public Image GetById(int id)
		{
			return imageDal.GetById(x=>x.ImageId==id);
		}

		public Image ImageAdd(Image image)
		{
			return imageDal.Add(image);
		}

		public void UpdateImage(Image image)
		{
			imageDal.Update(image);
		}
	}
}
