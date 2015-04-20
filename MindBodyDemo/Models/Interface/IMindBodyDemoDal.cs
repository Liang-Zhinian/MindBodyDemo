using MindBodyDemo.AppointmentService;
using MindBodyDemo.StaffService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBodyDemo.Models.Interface
{
    public interface IMindBodyDemoDal
    {
        IEnumerable<MindBodyDemo.StaffService.Staff> GetAllStaff();
        List<MindBodyDemo.Models.Data.Appointment> GetStaffAppointments(string first, string lastName, string staffId);
        MindBodyDemo.StaffService.Staff GetStaffInfo(string id);
    }
}
