using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IMemberService
	{
		List<Member> GetAll();
		void MemberAdd(Member member);
		Member GetById(int id);
		void DeleteMember(Member member);
		void UpdateMember(Member member);
	}
}
