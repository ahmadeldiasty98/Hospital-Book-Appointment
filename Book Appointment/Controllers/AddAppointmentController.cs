using Book_Appointment.Data;
using Book_Appointment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Book_Appointment.Controllers
{
    public class AddAppointmentController : Controller
    {
        ApplicationDbContext dbcontext = new ApplicationDbContext();
        public IActionResult Index(int doctorId)
        {
            var doctor = dbcontext.doctors.Find(doctorId);
            return View(doctor);
        }
        [HttpPost]
        public IActionResult BookAppointment(string patientName, string doctorName, DateOnly appointmentDate, TimeOnly appointmentTime)
        {
            BookedApp bookedApp = new BookedApp
            {
                PatientName = patientName,
                DoctorName = doctorName,
                Date = appointmentDate,
                Time = appointmentTime
            };
            dbcontext.bookedApps.Add(bookedApp);
            dbcontext.SaveChanges();
            return RedirectToAction("BookedAppointments", "AddAppointment");
        }
        public IActionResult BookedAppointments()
        {
            var Appointments = dbcontext.bookedApps.ToList();
            return View(Appointments);
        }
    }
}