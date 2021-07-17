using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface IAttendanceRepository
    {
        bool GetAttendances(Gig gig, string userId);
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        void Add(Attendance attendance);
        Attendance GetAttendance(int id, string userId);
        void Remove(Attendance attendance);
        
    }
}