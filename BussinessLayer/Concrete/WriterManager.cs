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
    public class WriterManager : IWriterService
    {
        IWriterDAL _writerDAL;

        public WriterManager(IWriterDAL writerDAL)
        {
            _writerDAL = writerDAL;
        }

        public void Add(Writer writer)
        {
            _writerDAL.Add(writer);
        }

        public void Delete(Writer t)
        {
            _writerDAL.Delete(t);
        }

        public List<Writer> GetAll()
        {
            return _writerDAL.Get();
        }

        public Writer GetById(int id)
        {
            return _writerDAL.GetById(id);
        }

        public Writer GetWriterFromEmail(string email)
        {
            return _writerDAL.Get(x => x.Email == email).FirstOrDefault();
        }

        public Writer Login(Writer writer)
        {
            return _writerDAL.Get(x => x.Email == writer.Email && x.Password == writer.Password).FirstOrDefault();
        }

        public void Update(Writer t)
        {
            _writerDAL.Update(t);
        }
    }
}
