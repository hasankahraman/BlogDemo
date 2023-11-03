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
    public class NotificationManager : INotificationService
    {
        INotificationDAL _notificationDAL;

        public NotificationManager(INotificationDAL notificationDAL)
        {
            _notificationDAL = notificationDAL;
        }

        public void Add(Notification t)
        {
            _notificationDAL.Add(t);
        }

        public void Delete(Notification t)
        {
            _notificationDAL.Delete(t);
        }

        public List<Notification> GetAll()
        {
            return _notificationDAL.Get().Where(x => x.Status == true).ToList() ;
        }

        public Notification GetById(int id)
        {
            return _notificationDAL.GetById(id);
        }

        public void Update(Notification t)
        {
            _notificationDAL.Update(t);
        }
    }
}
