using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AppointmentRepo
    {
        public static List<Appointment> Get()
        {
            AEntities db = new AEntities();
            return db.Appointments.ToList();
        }
        public static Appointment Get(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Appointments where e.Id == id select e).FirstOrDefault();
            return data;
        }
        public static void Create(Appointment doc)
        {
            AEntities db = new AEntities();
            db.Appointments.Add(doc);
            db.SaveChanges();
        }
        public static void Edit(Appointment doc, int id)
        {
            AEntities db = new AEntities();
            doc.Id = id;
            var data = (from e in db.Appointments where e.Id == id select e).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(doc);
            db.SaveChanges();
        }
        public static void delete(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Appointments where e.Id == id select e).FirstOrDefault();
            db.Appointments.Remove(data);
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
