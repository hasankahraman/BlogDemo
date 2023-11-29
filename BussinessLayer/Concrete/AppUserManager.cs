using BussinessLayer.Abstract;
using DataAccessLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        IUserDAL _appUserDAL;

        public AppUserManager(IUserDAL appUserDAL)
        {
            _appUserDAL = appUserDAL;
        }

        public void Add(AppUser t)
        {
            _appUserDAL.Add(t);
        }

        public void Delete(AppUser t)
        {
            _appUserDAL.Delete(t);
        }

        public List<AppUser> GetAll()
        {
            return _appUserDAL.Get();
        }

        public AppUser GetById(int id)
        {
            return _appUserDAL.GetById(id);
        }

        public void Update(AppUser t)
        {
            _appUserDAL.Update(t);
        }
    }
}
