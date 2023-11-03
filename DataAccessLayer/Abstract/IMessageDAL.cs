using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDAL : IGenericDAL<Message>
    {
        List<Message> GetInboxWithWriter(int id);
        List<Message> GetSentboxWithWriter(int id);
    }
}
