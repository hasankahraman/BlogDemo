using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
	public interface INewsletterService
	{
		void Add(Newsletter newsletter);
		void Delete(Newsletter newsletter);
		List<Newsletter> GetAll();
	}
}
