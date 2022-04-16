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
    public class DoctorController : ApiController
    {
        [HttpGet]
        [Route("api/Doctor/Get")]
        public HttpResponseMessage Get()
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
        [Route("api/Doctor/Create")]
        public IHttpActionResult Create(DoctorModel doc)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            DoctorServices.Add(doc);
            return Ok();
        }

        [HttpPost]
        [Route("api/Doctor/Edit/{id}")]
        public IHttpActionResult Edit(DoctorModel doc, int id)
        {
            if (!ModelState.IsValid) return BadRequest("Enter write Information");
            DoctorServices.Edit(doc, id);
            return Ok();
        }

        [HttpPost, Route("api/Doctor/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            DoctorServices.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("api/Doctor/Appointments")]
        public HttpResponseMessage GetAppointments()
        {
            List<AppointmentModel> li = new List<AppointmentModel>();
            var data = AppointmentServices.Get();

            foreach (var item in data)
            {
                AppointmentModel doc = new AppointmentModel();
                doc.Id = item.Id;
                doc.DoctorId = item.DoctorId;
                doc.PatientId = item.PatientId;
                doc.DoctorName = AppointmentServices.GetName(item.Id);
                doc.PatientName = AppointmentServices.GetPatientName(item.Id);
                Random rnd = new Random();
                int a = rnd.Next(4);
                doc.Slot = a;
                li.Add(doc);

            }
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }


       


        [HttpPost, Route("api/Appointment/Delete/{id}")]
        public IHttpActionResult AppointmentDelete(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            AppointmentServices.Delete(id);
            return Ok();
        }


        [HttpGet]
        [Route("api/DoctorApprove/Appointments")]
        public HttpResponseMessage GetAppointmentDoctor()
        {
            List<DoctorApproveAppointmentsModel> li = new List<DoctorApproveAppointmentsModel>();
            var data = DoctorApproveAppointmentsService.Get();

            foreach (var item in data)
            {
                DoctorApproveAppointmentsModel doc = new DoctorApproveAppointmentsModel();
                doc.Id = item.Id;
                doc.DoctorId = item.DoctorId;
                doc.PatientId = item.PatientId;
                doc.DoctorName = DoctorApproveAppointmentsService.GetName(item.Id);
                doc.PatientName = DoctorApproveAppointmentsService.GetPatientName(item.Id);
                Random rnd = new Random();
                int a = rnd.Next(4);
                doc.Slot = a;
                li.Add(doc);

            }
            var datajava = new JavaScriptSerializer().Serialize(li);
            return Request.CreateResponse(HttpStatusCode.OK, datajava);
        }





        [HttpPost, Route("api/DoctorApprove/Delete/{id}")]
        public IHttpActionResult ApproveDelete(int id)
        {
            if (!ModelState.IsValid) return BadRequest("Please Enter write info");
            DoctorApproveAppointmentsService.Delete(id);
            return Ok();
        }

    }
}
