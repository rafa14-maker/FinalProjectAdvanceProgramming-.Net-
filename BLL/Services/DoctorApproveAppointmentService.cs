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
    public class DoctorApproveAppointmentsService
    {
        public static List<DoctorApproveAppointmentsModel> Get()
        {
            var data = DoctorApproveAppointmentRepo.Get();
            List<DoctorApproveAppointmentsModel> li = new List<DoctorApproveAppointmentsModel>();
            foreach (var item in data)
            {
                DoctorApproveAppointmentsModel ml = new DoctorApproveAppointmentsModel();
                ml.DoctorId = item.DoctorId;
                ml.PatientId = item.PatientId;
                ml.Id = item.Id;
                li.Add(ml);
            }
            return li;
        }


        public static void Add(DoctorApproveAppointmentsModel doc)
        {
            DoctorApproveAppointment dc = new DoctorApproveAppointment();
            dc.DoctorId = doc.DoctorId;
            dc.PatientId = doc.PatientId;
            dc.Id = doc.Id;
            DoctorApproveAppointmentRepo.Create(dc);
        }

        public static void Edit(DoctorApproveAppointmentsModel doc, int id)
        {
            DoctorApproveAppointment dc = new DoctorApproveAppointment();
            dc.DoctorId = doc.DoctorId;
            dc.PatientId = doc.PatientId;
            dc.Id = doc.Id;
            DoctorApproveAppointmentRepo.Edit(dc, id);
        }

        public static void Delete(int id)
        {
            DoctorApproveAppointmentRepo.delete(id);
        }
        public static string GetName(int id)
        {
            return DoctorApproveAppointmentRepo.GetName(id);

        }
        public static string GetPatientName(int id)
        {
            return DoctorApproveAppointmentRepo.GetPatientName(id);

        }
    }
}


    

