﻿using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDAL _blogDAL;

		public BlogManager(IBlogDAL blogDAL)
		{
			_blogDAL = blogDAL;
		}

		public void Add(Blog blog)
		{
			_blogDAL.Add(blog);
		}

		public void Delete(Blog blog)
		{
			_blogDAL.Delete(blog);
		}

		public List<Blog> GetAll()
		{
			return _blogDAL.Get().OrderByDescending(x => x.CreatedAt).ToList();
		}

        public List<Blog> GetByAuthor(int writerId)
        {
			return _blogDAL.Get(x=> x.UserId == writerId).OrderByDescending(x=>x.CreatedAt).ToList();
        }

        public Blog GetById(int id)
		{
			return _blogDAL.GetById(id);
		}

        public List<Blog> GetLatest3Blogs()
        {
            return _blogDAL.Get().OrderByDescending(x => x.CreatedAt).Take(3).ToList();
        }

        public List<Blog> GetWithCategory()
		{
			return _blogDAL.GetWithCategory();
		}

        public List<Blog> GetWithCategoryByWriter(int writerId)
        {
			return _blogDAL.GetWithCategoryByWriter(writerId);
        }

        public void Update(Blog blog)
		{
			_blogDAL.Update(blog);
		}
	}
}
