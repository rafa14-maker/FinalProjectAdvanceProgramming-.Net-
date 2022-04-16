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
    public class PatientServices
    {
        public static List<PatientModel> Get()
        {
            var data = PatientRepo.Get();
            List<PatientModel> li = new List<PatientModel>();
            foreach (var item in data)
            {
                PatientModel ml = new PatientModel();
                ml.Name = item.Name;
                ml.Password = item.Password;
                ml.Email = item.Email;
                ml.Gender = item.Gender;
                ml.Id = item.Id;
                li.Add(ml);
            }
            return li;
        }


        public static void Add(PatientModel pt)
        {
            Patient p = new Patient();
            p.Name = pt.Name;
            p.Password = pt.Password;
            p.Email = pt.Email;
            p.Gender = pt.Gender;
            PatientRepo.Create(p);
        }

        public static void Edit(PatientModel pt, int id)
        {
            Patient p = new Patient();
            p.Name = pt.Name;
            p.Password = pt.Password;
            p.Email = pt.Email;
            p.Gender = pt.Gender;
            p.Id = id;
            PatientRepo.Edit(p, id);
        }

        public static void Delete(int id)
        {
            PatientRepo.delete(id);
        }
    }
}
