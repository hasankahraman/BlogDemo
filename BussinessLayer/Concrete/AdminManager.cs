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
    public class AdminManager : IAdminService
    {
        IAdminDAL _adminDAL;

        public AdminManager(IAdminDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public void Add(Admin t)
        {
            _adminDAL.Add(t);
        }

        public void Delete(Admin t)
        {
            _adminDAL.Delete(t);
        }

        public List<Admin> GetAll()
        {
            return _adminDAL.Get();
        }

        public Admin GetById(int id)
        {
            return _adminDAL.GetById(id);
        }

        public void Update(Admin t)
        {
            _adminDAL.Update(t);
        }
    }
}
