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
	public class MemberManager : IMemberService
	{
		IMemberDal memberDal;

		public MemberManager(IMemberDal memberDal)
		{
			this.memberDal = memberDal;
		}
		public void DeleteMember(Member member)
		{
			throw new NotImplementedException();
		}

		public List<Member> GetAll()
		{
			throw new NotImplementedException();
		}

		public Member GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void MemberAdd(Member member)
		{
			memberDal.Add(member);
		}

		public void UpdateMember(Member member)
		{
			throw new NotImplementedException();
		}
	}
}
