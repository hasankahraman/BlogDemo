using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        Writer Login(Writer writer);
        //List<Writer> GetById(int writerId);
        Writer GetWriterFromEmail(string email);
    }
}
