using BLL.BEnt;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Hospital_Management_System.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/Admin/Get")]
        public HttpResponseMessage Get()
        {
            List<AdminModel> li = new List<AdminModel>();
            var data = AdminServices.Get();

            foreach (var item in data)
            {
                AdminModel st = new AdminModel();
                st.Id = item.Id;
                st.Name = item.Name;
                st.Gender = item.Gender;
                st.Email = item.Email;
                st.Password = item.Password;
                li.Add(st);
            }
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("api/Admin/Get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            List<AdminModel> li = new List<AdminModel>();
            var data = AdminServices.Get();

            foreach (var item in data)
            {
                if (item.Id == id)
                {
                    AdminModel st = new AdminModel();
                    st.Id = item.Id;
                    st.Name = item.Name;
                    st.Gender = item.Gender;
                    st.Email = item.Email;
                    st.Password = item.Password;
                    li.Add(st);
                }
            }

            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }

        [HttpPost]
        [Route("api/Admin/CreateAdmin")]
        public IHttpActionResult Create(AdminModel adm)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            AdminServices.Add(adm);
            return Ok();
        }

        [HttpPost]
        [Route("api/Admin/EditAdmin/{id}")]
        public IHttpActionResult Edit(AdminModel adm, int id)
        {
            if (!ModelState.IsValid) return BadRequest("Enter write Information");
            AdminServices.Edit(adm, id);
            return Ok();
        }
        [HttpPost, Route("api/Admin/DeleteAdmin/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            AdminServices.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("api/Admin/GetDoctor")]
        public HttpResponseMessage GetDoctor()
        {
            List<DoctorModel> li = new List<DoctorModel>();
            var data = DoctorServices.Get();

            foreach (var item in data)
            {
                DoctorModel doc = new DoctorModel();
                doc.Id = item.Id;
                doc.Name = item.Name;
                doc.Gender = item.Gender;
                doc.Email = item.Email;
                doc.Password = item.Password;
                li.Add(doc);
            }
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }


        [HttpPost]
        [Route("api/Admin/CreateDoctor")]
        public IHttpActionResult CreateDoctor(DoctorModel doc)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            DoctorServices.Add(doc);
            return Ok();
        }

        [HttpPost]
        [Route("api/Admin/EditDoctor/{id}")]
        public IHttpActionResult EditDoctor(DoctorModel doc, int id)
        {
            if (!ModelState.IsValid) return BadRequest("Enter write Information");
            DoctorServices.Edit(doc, id);
            return Ok();
        }

        [HttpPost, Route("api/Admin/DeleteDoctor/{id}")]
        public IHttpActionResult DeleteDoctor(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            DoctorServices.Delete(id);
            return Ok();
        }



        [HttpGet]
        [Route("api/Admin/GetPatient")]
        public HttpResponseMessage GetPatient()
        {
            List<PatientModel> li = new List<PatientModel>();
            var data = PatientServices.Get();

            foreach (var item in data)
            {
                PatientModel pt = new PatientModel();
                pt.Id = item.Id;
                pt.Name = item.Name;
                pt.Gender = item.Gender;
                pt.Email = item.Email;
                pt.Password = item.Password;
                li.Add(pt);
            }
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }


        [HttpPost]
        [Route("api/Admin/CreatePatient")]
        public IHttpActionResult CreatePatient(PatientModel pt)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            PatientServices.Add(pt);
            return Ok();
        }

        [HttpPost]
        [Route("api/Admin/EditPatient/{id}")]
        public IHttpActionResult EditPatient(PatientModel pt, int id)
        {
            if (!ModelState.IsValid) return BadRequest("Enter write Information");
            PatientServices.Edit(pt, id);
            return Ok();
        }

        [HttpPost, Route("api/Admin/DeletePatient/{id}")]
        public IHttpActionResult DeletePatient(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            PatientServices.Delete(id);
            return Ok();
        }



    }
}
