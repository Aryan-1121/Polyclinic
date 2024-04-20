using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PolyclinicDALCrossPlatform.Models;

namespace PolyclinicDALCrossPlatform
{
    public class PolyclinicRepository
    {
        PolyclinicDBContext context;
        public PolyclinicRepository()
        {
            context = new PolyclinicDBContext();
        }

        public List<Patients> GetAllPatientDetails()
        {
        try{
            // List<Patients> patientlist = (from patient in context.Patients orderby patient.PatientId select patient).ToList();
                // List<Patients> patientList = context.Patients.OrderBy(patient => patient.PatientId).ToList();
                    string sqlQuery = "SELECT * FROM Patients ORDER BY PatientId";
                    var patientList = context.Patients.FromSqlRaw(sqlQuery).ToList();
        // List<Patients> patientlist = context.Patients.ToList();

        // MYSQL query 

            // Console.WriteLine(patientlist);
            return patientList;
        }catch(Exception e){
            Console.WriteLine(e);
            return null; 
        }

        }

        public Patients GetPatientDetails(string patientId)
        {
            Patients patientDetails = null;
            try
            {
                patientDetails = context.Patients
                                        .Where(p => p.PatientId == patientId)
                                        .FirstOrDefault();
            }
            catch (Exception ex)
            {
                patientDetails = null;
                Console.WriteLine(ex.Message);
            }
            return patientDetails;
        }

        public bool AddNewPatientDetails(Patients patientObj)
        {
            bool status = false;
            try
            {
                context.Patients.Add(patientObj);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                Console.WriteLine(ex.Message);
            }
            return status;

        }

        public bool UpdatePatientAge(string patientId, byte newAge)
        {
            bool status = false;
            Patients patientObj = context.Patients.Find(patientId);
            try
            {
                if (patientObj != null)
                {
                    patientObj.Age = newAge;
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                status = false;
            }
            return status;
        }

        public int CancelAppointment(int appointmentNo)
        {
            int status = -1;
            Appointments appointmentsObj = null;
            try
            {
                appointmentsObj = context.Appointments.Find(appointmentNo);
                if (appointmentsObj != null)
                {
                    context.Appointments.Remove(appointmentsObj);
                    context.SaveChanges();
                    status = 1;
                }
                else
                {
                    status = -1;
                }
            }
            catch (Exception ex)
            {
                status = -99;
                Console.WriteLine(ex.Message);
            }
            return status;
        }

    }
}
