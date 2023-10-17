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

        public Writer Login(Writer writer)
        {
            return _writerDAL.Get(x => x.Email == writer.Email && x.Password == writer.Password).FirstOrDefault();
        }
    }
}
