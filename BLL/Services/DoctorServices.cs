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
    public class DoctorServices
    {
        public static List<DoctorModel> Get()
        {
            var data = DoctorRepo.Get();
            List<DoctorModel> li = new List<DoctorModel>();
            foreach (var item in data)
            {
                DoctorModel ml = new DoctorModel();
                ml.Name = item.Name;
                ml.Password = item.Password;
                ml.Email = item.Email;
                ml.Gender = item.Gender;
                ml.Id = item.Id;
                li.Add(ml);
            }
            return li;
        }


        public static void Add(DoctorModel doc)
        {
            Doctor dc = new Doctor();
            dc.Name = doc.Name;
            dc.Password = doc.Password;
            dc.Email = doc.Email;
            dc.Gender = doc.Gender;
            DoctorRepo.Create(dc);
        }

        public static void Edit(DoctorModel doc, int id)
        {
            Doctor dc = new Doctor();
            dc.Name = doc.Name;
            dc.Password = doc.Password;
            dc.Email = doc.Email;
            dc.Gender = doc.Gender;
            dc.Id = id;
            DoctorRepo.Edit(dc, id);
        }

        public static void Delete(int id)
        {
             DoctorRepo.delete(id);
        }

    }
}
