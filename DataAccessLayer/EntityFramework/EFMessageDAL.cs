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
    public class EFMessageDAL : GenericRepository<Message>, IMessageDAL
    {
        public List<Message> GetInboxWithWriter(int id)
        {
            using (var context = new Context())
                return context.Messages.Include(x => x.FromWriter).Where(x => x.FromId == id).ToList();
                //return context.Messages.Include(x => x.FromId).Where(x => x.FromId == id).ToList();
        }

        public List<Message> GetSentboxWithWriter(int id)
        {
            using (var context = new Context())
                //return context.Messages.Include(x => x.ToId).Where(x => x.ToId == id).ToList();
            return context.Messages.Include(x => x.ToWriter).Where(x => x.ToId == id).ToList();
        }
    }
}
