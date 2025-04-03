using AppointmentApi.Data;
using AppointmentApi.Models;

namespace AppointmentApi.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _context;
        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Appointment> GetAppointments()
        {
            return _context.Appointments.ToList();
        }
        public bool AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateAppointment(int id, Appointment appointment)
        {
            var existing = _context.Appointments.Find(id);
            if (existing == null) 
                return false;

            existing.Date = appointment.Date;
            existing.Description = appointment.Description;
            existing.Status = appointment.Status;
            _context.Appointments.Update(existing);//sil
            _context.SaveChanges();
            return true;
        }
        public bool DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null) return false;

            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
            return true;
        }
    }
}
