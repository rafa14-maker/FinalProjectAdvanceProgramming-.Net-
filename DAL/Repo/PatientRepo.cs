using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class PatientRepo
    {
           public static List<Patient>Get()
           {
              AEntities db = new AEntities();
              return db.Patients.ToList();
           }
          public static Patient Get(int id)
           {
              AEntities db = new AEntities();
             var data = (from e in db.Patients where e.Id == id select e).FirstOrDefault();
              return data;  
          }
          public static void Create(Patient pt)
          {
            AEntities db = new AEntities();
            db.Patients.Add(pt);
            db.SaveChanges();
          }
          public static void Edit(Patient pt,int id)
          {
            AEntities db = new AEntities();
            pt.Id = id;
            var data = (from e in db.Patients where e.Id == id select e).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(pt);
            db.SaveChanges();
           }
          public static void delete(int id)
           {
            AEntities db = new AEntities();
            var data = (from e in db.Patients where e.Id == id select e).FirstOrDefault();
            db.Patients.Remove(data);
            var data1 = (from e in db.DoctorApproveAppointments where e.PatientId == id select e).FirstOrDefault();
            if (data1 != null) db.DoctorApproveAppointments.Remove(data1);
            var data2 = (from e in db.Appointments where e.PatientId == id select e).FirstOrDefault();
            if (data2 != null) db.Appointments.Remove(data2);
            db.SaveChanges();
            }
    }
}
