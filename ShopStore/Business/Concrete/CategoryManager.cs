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
	public class CategoryManager : ICategoryService
	{
		ICategoryDal categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			this.categoryDal = categoryDal;
		}
		public void CategoryAdd(Category category)
		{
			categoryDal.Add(category);
		}

		public void DeleteCategory(Category category)
		{
			categoryDal.Delete(category);
		}

		public List<Category> GetAll()
		{
			return categoryDal.GetAll();
		}

		public Category GetById(int id)
		{
			return categoryDal.GetById(x=>x.CategoryId==id);
		}

		public void UpdateCategory(Category category)
		{
			categoryDal.Update(category);
		}
	}
}
