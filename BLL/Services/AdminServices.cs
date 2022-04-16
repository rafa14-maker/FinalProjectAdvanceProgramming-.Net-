using BLL.BEnt;
using DAL.Database;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminServices
    {
        public static List<AdminModel>Get()
        {
            var data = AdminRepo.Get();
            List<AdminModel> li = new List<AdminModel>();
            foreach (var item in data)
            {
               AdminModel ml = new AdminModel();
               ml.Name = item.Name;
                ml.Password = item.Password;
                ml.Email = item.Email;  
                ml.Gender = item.Gender;
                ml.Id = item.Id;
                li.Add(ml);
            }
            return li;
        }


        public static void Add(AdminModel adm)
        {
            Admin ad = new Admin();
            ad.Name = adm.Name;
            ad.Password = adm.Password;
            ad.Email = adm.Email;
            ad.Gender = adm.Gender;
            AdminRepo.Create(ad);
        }

        public static void Edit(AdminModel adm,int id)
        {
            Admin ad = new Admin();
            ad.Name = adm.Name;
            ad.Password = adm.Password;
            ad.Email = adm.Email;
            ad.Gender = adm.Gender;
            ad.Id = id;
            AdminRepo.Edit(ad,id);
        }

        public static void Delete(int id)
        {
            AdminRepo.delete(id);
        }


    }
}
