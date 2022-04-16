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
   public class AppointmentServices
    {
        public static List<AppointmentModel> Get()
        {
            var data = AppointmentRepo.Get();
            List<AppointmentModel> li = new List<AppointmentModel>();
            foreach (var item in data)
            {
                AppointmentModel ml = new AppointmentModel();
                ml.DoctorId = item.DoctorId;
                ml.PatientId = item.PatientId;
                ml.Id = item.Id;
                li.Add(ml);
            }
            return li;
        }


        public static void Add(AppointmentModel doc)
        {
            Appointment dc = new Appointment();
            dc.DoctorId = doc.DoctorId;
            dc.PatientId = doc.PatientId;
            dc.Id = doc.Id;
            AppointmentRepo.Create(dc);
        }

        public static void Edit(AppointmentModel doc, int id)
        {
            Appointment dc = new Appointment();
            dc.DoctorId = doc.DoctorId;
            dc.PatientId = doc.PatientId;
            dc.Id = doc.Id;
            AppointmentRepo.Edit(dc, id);
        }

        public static void Delete(int id)
        {
            AppointmentRepo.delete(id);
        }
       public static string GetName(int id)
        {
           return AppointmentRepo.GetName(id);

        }
       public static string GetPatientName(int id)
       {
           return AppointmentRepo.GetPatientName(id);

       }

    }
}
