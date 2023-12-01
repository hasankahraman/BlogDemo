using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        List<Message> GetInboxByWriter(int to);
        List<Message> GetSentboxByWriter(int from);
        Message GetDetailsWithWriter(int messageId);
    }
}
