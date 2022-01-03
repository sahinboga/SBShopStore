using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ILoginService
	{
		Member GetMember(string email, string password);
		Admin GetAdmin(string email, string password);
	}
}
