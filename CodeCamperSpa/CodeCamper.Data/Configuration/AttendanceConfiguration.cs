using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data.Configuration
{
    public class AttendanceConfiguration
        : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            //Many to Many

            //Attendance has a composite key: SessionId and PersonId
            HasKey(a => new { a.SessionId, a.PersonId });

            //Attendance has 1 session
            //Session have many Attendances
            //Attendance.Session 1---* Session.AttendanceList
            HasRequired(a => a.Session)
                .WithMany(session => session.AttendanceList)
                .HasForeignKey(a => a.SessionId)
                .WillCascadeOnDelete(false);

            //Attendance has 1 Person
            //Persons have many Attendances
            //Attendance.Person 1---* Person.AttendanceList
            HasRequired(a => a.Person)
                .WithMany(person => person.AttendanceList)
                .HasForeignKey(a => a.PersonId)
                .WillCascadeOnDelete(false);
        }
    }
}
