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
    public class MessageManager : IMessageService
    {
        IMessageDAL _messageDAL;

        public MessageManager(IMessageDAL messageDAL)
        {
            _messageDAL = messageDAL;
        }

        public void Add(Message t)
        {
            _messageDAL.Add(t);
        }

        public void Delete(Message t)
        {
            _messageDAL.Delete(t);
        }

        public List<Message> GetAll()
        {
            return _messageDAL.Get();
        }

        public Message GetById(int id)
        {
            return _messageDAL.GetById(id);
        }

        public List<Message> GetInboxByWriter(int to)
        {
            return _messageDAL.GetInboxWithWriter(to);
        }

        public List<Message> GetSentboxByWriter(int from)
        {
            return _messageDAL.GetSentboxWithWriter(from);
        }

        public void Update(Message t)
        {
            _messageDAL.Update(t);
        }
    }
}
