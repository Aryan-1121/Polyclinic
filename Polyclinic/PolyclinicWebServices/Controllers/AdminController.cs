using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolyclinicDALCrossPlatform;
using PolyclinicDALCrossPlatform.Models;

namespace PolyclinicWebServices.Controllers
{
    // [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : Controller
    {
        //Create repository object

        PolyclinicRepository repository = new PolyclinicRepository();
  



        public AdminController()
        {
            //Implement the logic here

            repository=new PolyclinicRepository();

            
        }


        [HttpGet("/api/hello")]
        public String Hello(){
            return "hello from admin controlller";
        }


        [HttpGet("/api/getAllPatients")] 
        public JsonResult GetAllPatientDetails()
        {

            //Implement the logic here

            List<Patients> patients = new List<Patients>();
            try
            {
                patients = repository.GetAllPatientDetails();

            }
            catch (Exception)
            {

                patients = null;
            }

            return Json(patients);
           

        }


        [HttpGet("/api/getPatientDetails")]
        public JsonResult GetPatientDetails(string patientId)
        {
            //Implement the logic here
            Patients patient = null;

            try
            {
                patient = repository.GetPatientDetails(patientId);
            }
            catch (Exception)
            {

                patient = null;
            }

            return Json(patient);
        }

           
        [HttpPost("/api/addPatients")]
        public JsonResult AddNewPatientDetails(Patients patient)
        {
            //Implement the logic here
            bool status = false;
           
            try
            {
                status = repository.AddNewPatientDetails(patient);
                if (status)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception)
            {

                status = false;
            }
            return Json(status);
        }

        // [HttpPut]
        // public JsonResult UpdatePatientAge(string patientId,byte age)
        // {
        //     //Implement the logic here
        //     bool status = false;
         
        //     try
        //     {
        //         status = repository.UpdatePatientAge(patientId,age);
                 
        //     }
        //     catch (Exception)
        //     {
        //         status = false;

        //     }
        //     return Json(status);
        // }
        // [HttpDelete]
        // public JsonResult CancelAppointment(int appointmentNo)
        // {
        //     //Implement the logic here
        //     int status = 0;

        //     try
        //     {
        //         status = repository.CancelAppointment(appointmentNo);
    
        //     }
        //     catch (Exception)
        //     {

        //         status = -1;
        //     }
        //     return Json(status);
        // }

    }
}
