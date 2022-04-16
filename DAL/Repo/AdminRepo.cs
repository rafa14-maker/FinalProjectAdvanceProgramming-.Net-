using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class AdminRepo
    {
        public static List<Admin> Get()
        {
            AEntities db = new AEntities();
            return db.Admins.ToList();
        }
        public static Admin Get(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Admins where e.Id == id select e).FirstOrDefault();
            return data;
        }
        public static void Create(Admin adm)
        {
            AEntities db = new AEntities();
            db.Admins.Add(adm);
            db.SaveChanges();
        }
        public static void Edit(Admin adm, int id)
        {
            AEntities db = new AEntities();
            adm.Id = id;
            var data = (from e in db.Admins where e.Id == id select e).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(adm);
            db.SaveChanges();
        }
        public static void delete(int id)
        {
            AEntities db = new AEntities();
            var data = (from e in db.Admins where e.Id == id select e).FirstOrDefault();
            db.Admins.Remove(data);
            db.SaveChanges();
        }
    }
}
