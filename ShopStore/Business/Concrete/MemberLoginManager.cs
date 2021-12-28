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
	public class MemberLoginManager:IMemberLoginService
	{
		IMemberDal _memberDal;

		public MemberLoginManager(IMemberDal memberDal)
		{
			_memberDal = memberDal;
		}

		public Member GetMember(string email, string password)
		{
			return _memberDal.GetById(x=>x.Email==email && x.Password==password);
		}
	}
}
