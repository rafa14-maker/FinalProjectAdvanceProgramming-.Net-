
using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class DoctorApproveAppointmentRepo
    {
         public static List<DoctorApproveAppointment> Get()
        {
            AEntities db = new AEntities();
            return db.DoctorApproveAppointments.ToList();
        }
        public static DoctorApproveAppointment Get(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.DoctorApproveAppointments where e.Id == id select e).FirstOrDefault();
            return data;
        }
        public static void Create(DoctorApproveAppointment doc)
        {
            AEntities db = new AEntities();
            db.DoctorApproveAppointments.Add(doc);
            db.SaveChanges();
        }
        public static void Edit(DoctorApproveAppointment doc, int id)
        {
            AEntities db = new AEntities();
            doc.Id = id;
            var data = (from e in db.DoctorApproveAppointments where e.Id == id select e).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(doc);
            db.SaveChanges();
        }
        public static void delete(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.DoctorApproveAppointments where e.Id == id select e).FirstOrDefault();
            db.DoctorApproveAppointments.Remove(data);
            db.SaveChanges();
        }
        public static string GetName(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Doctors where e.Id == id select e).FirstOrDefault();
            string s = data.Name;
            return s;
        }
        public static string GetPatientName(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Patients where e.Id == id select e).FirstOrDefault();
            string s = data.Name;
            return s;
        }
    }
    }
