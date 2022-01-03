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
	public class LoginManager:ILoginService
	{
		IMemberDal _memberDal;
		IAdminDal _adminDal;

		public LoginManager(IMemberDal memberDal, IAdminDal adminDal)
		{
			_memberDal = memberDal;
			_adminDal = adminDal;
		}

		public Member GetMember(string email, string password)
		{
			return _memberDal.GetById(x=>x.Email==email && x.Password==password);
		}
		public Admin GetAdmin(string email, string password)
		{
			return _adminDal.GetById(x => x.Email == email && x.Password == password);
		}
	}
}
