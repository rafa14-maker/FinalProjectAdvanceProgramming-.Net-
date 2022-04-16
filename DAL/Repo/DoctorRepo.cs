using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class DoctorRepo
    {
        public static List<Doctor> Get()
        {
            AEntities db = new AEntities();
            return db.Doctors.ToList();
        }
        public static Doctor Get(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Doctors where e.Id == id select e).FirstOrDefault();
            return data;
        }
        public static void Create(Doctor doc)
        {
            AEntities db = new AEntities();
            db.Doctors.Add(doc);
            db.SaveChanges();
        }
        public static void Edit(Doctor doc, int id)
        {
            AEntities db = new AEntities();
            doc.Id = id;
            var data = (from e in db.Doctors where e.Id == id select e).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(doc);
            db.SaveChanges();
        }
        public static void delete(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Doctors where e.Id == id select e).FirstOrDefault();
            if(data!=null)  db.Doctors.Remove(data);
            var data1 = (from e in db.DoctorApproveAppointments where e.DoctorId == id select e).FirstOrDefault();
              if(data1 != null)   db.DoctorApproveAppointments.Remove(data1);
            var data2 = (from e in db.Appointments where e.DoctorId == id select e).FirstOrDefault();
            if (data2 != null) db.Appointments.Remove(data2);
            db.SaveChanges();
        }
    }
}
