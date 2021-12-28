using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IImageService
	{
		List<Image> GetAll();
		Image ImageAdd(Image image);
		Image GetById(int id);
		void DeleteImage(Image image);
		void UpdateImage(Image image);
	}
}
