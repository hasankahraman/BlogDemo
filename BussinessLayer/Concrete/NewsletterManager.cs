using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
	public class NewsletterManager : INewsletterService
	{
		INewsletterDAL _newsletterDAL;

		public NewsletterManager(INewsletterDAL newsletterDAL)
		{
			_newsletterDAL = newsletterDAL;
		}

		public void Add(Newsletter newsletter)
		{
			_newsletterDAL.Add(newsletter);
		}

		public void Delete(Newsletter newsletter)
		{
			_newsletterDAL.Delete(newsletter);
		}

		public List<Newsletter> GetAll()
		{
			return _newsletterDAL.Get();
		}
	}
}
