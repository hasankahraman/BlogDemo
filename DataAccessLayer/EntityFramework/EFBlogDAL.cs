using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFBlogDAL : GenericRepository<Blog>, IBlogDAL
	{
		public List<Blog> GetWithCategory()
		{
			using (var context = new Context())
				return context.Blogs.Include(x => x.Category).ToList();
		}
	}
}
