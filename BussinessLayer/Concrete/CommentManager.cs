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
	public class CommentManager : ICommentService
	{
		ICommentDAL _commentDAL;

		public CommentManager(ICommentDAL commentDAL)
		{
			_commentDAL = commentDAL;
		}

		public void Add(Comment comment)
		{
			_commentDAL.Add(comment);
		}

		public void Delete(Comment comment)
		{
			_commentDAL.Delete(comment);
		}

		public List<Comment> GetAll()
		{
			return _commentDAL.Get();
		}

		public List<Comment> GetAll(int blogId)
		{
			return _commentDAL.Get(x=> x.BlogId == blogId);
		}

		public Comment GetById(int id)
		{
			return _commentDAL.GetById(id);
		}

        public List<Comment> GetWithBlog()
        {
			return _commentDAL.GetWithBlog();
        }

        public void Update(Comment comment)
		{
			_commentDAL.Update(comment);
		}
	}
}
