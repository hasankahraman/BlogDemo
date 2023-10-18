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
    public class ContactManager : IContactService
    {
        IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void Add(Contact contact)
        {
            _contactDAL.Add(contact);
        }

        public void Delete(Contact contact)
        {
            _contactDAL.Delete(contact);
        }

        public List<Contact> GetAll()
        {
            return _contactDAL.Get();
        }

        public Contact GetById(int id)
        {
            return _contactDAL.GetById(id);
        }

        public void Update(Contact contact)
        {
            _contactDAL.Update(contact);
        }
    }
}
