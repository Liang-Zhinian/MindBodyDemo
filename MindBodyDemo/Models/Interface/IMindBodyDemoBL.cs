using MindBodyDemo.AppointmentService;
using MindBodyDemo.StaffService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBodyDemo.Models.Interface
{
    interface IMindBodyDemoBL
    {
        IEnumerable<MindBodyDemo.StaffService.Staff> GetCompanyStaff();
        List<MindBodyDemo.Models.Data.Appointment> GetStaffAppointments(string first, string lastName, string staffId);
        MindBodyDemo.StaffService.Staff GetStaffInfo(string id);
    }
}
