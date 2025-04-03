using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppointmentApi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public string? Description { get; set; }
        public string? Status {  get; set; }
    }
}
