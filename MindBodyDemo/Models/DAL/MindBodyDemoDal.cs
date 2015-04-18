using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MindBodyDemo.Models.Interface;
using MindBodyDemo.StaffService;
using MindBodyDemo.AppointmentService;

namespace MindBodyDemo.Models.DAL
{
    public class MindBodyDemoDal : IMindBodyDemoDal
    {
        public IEnumerable<MindBodyDemo.StaffService.Staff> GetAllStaff() 
        {
            GetStaffRequest staffRequest = new GetStaffRequest();
            StaffService.SourceCredentials credentials = new StaffService.SourceCredentials();
            credentials.SourceName = "MBO.Hsiang-Ting.Yang";
            credentials.Password = "XgnwDdXhe+85Xg0JAK6g17kOMsw=";
            int[] ids = new int[1];
            ids[0] = -31100;
            credentials.SiteIDs = ids;

            staffRequest.SourceCredentials = credentials;


            MindBodyDemo.StaffService.StaffService s = new StaffService.StaffService();
            
            GetStaffResult result =  s.GetStaff(staffRequest);
            result.StaffMembers.Select(x=>x.ID<=0);

            IEnumerable<MindBodyDemo.StaffService.Staff> validStaff = from staff in result.StaffMembers
                                                                where staff.ID > 0
                                                                select staff;          
            return validStaff;
        }




        public List<MindBodyDemo.Models.Data.Appointment> GetStaffAppointments(string first, string lastName, string staffId) 
        {
            //first = "Luke";
            //lastName = "Peterson";
            //staffId = 100000052;
            GetStaffAppointmentsRequest request = new GetStaffAppointmentsRequest();

            // for source credentials
            AppointmentService.SourceCredentials sourceCredentials = new AppointmentService.SourceCredentials();
            sourceCredentials.SourceName = "MBO.Hsiang-Ting.Yang";
            sourceCredentials.Password = "XgnwDdXhe+85Xg0JAK6g17kOMsw=";
            int[] ids = new int[1];
            ids[0] = -31100;
            sourceCredentials.SiteIDs = ids;

            request.SourceCredentials = sourceCredentials;

            // for user credentials
            AppointmentService.StaffCredentials staffCredentials = new AppointmentService.StaffCredentials();
            staffCredentials.Username = first + "." + lastName;
            staffCredentials.Password = first[0].ToString().ToLower() + lastName[0].ToString().ToLower() + staffId;
            //staffCredentials.Username = "Luke.Peterson";
            //staffCredentials.Password = "lp100000052";
            staffCredentials.SiteIDs = ids;

            request.StaffCredentials = staffCredentials;
            request.StartDate = new DateTime(2014, 1, 3);
            request.EndDate = new DateTime(2014, 1, 4);
            
            MindBodyDemo.AppointmentService.AppointmentService appointmentServ = new AppointmentService.AppointmentService();
            var result = appointmentServ.GetStaffAppointments(request);

            List<MindBodyDemo.Models.Data.Appointment> apps = new List<MindBodyDemo.Models.Data.Appointment>();

            if (result != null && result.Appointments != null) 
            {
                foreach (var app in result.Appointments)
                {
                    MindBodyDemo.Models.Data.Appointment data = new Data.Appointment();
                    data.appointmentDate = app.StartDateTime.Value.ToString("yyyy-MM-dd");
                    data.startDate = app.StartDateTime.Value.TimeOfDay.ToString();
                    data.endDate = app.EndDateTime.Value.TimeOfDay.ToString();
                    data.appointmentType = app.SessionType.Name;
                    data.clientName = app.Client.FirstName + app.Client.LastName;
                    apps.Add(data);
                }
            }

            return apps;
        }
    }
}