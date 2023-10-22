using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
	public interface IBlogService : IGenericService<Blog>
	{
		List<Blog> GetWithCategory();
		List<Blog> GetWithCategoryByWriter(int writerId);
		List<Blog> GetByAuthor(int writerId);
		List<Blog> GetLatest3Blogs();
	}
}
