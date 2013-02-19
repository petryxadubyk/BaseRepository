using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRS.DataAccess.Configurations
{
    class FluentApiDoc
    {
        //Session has 1 Speaker,
        //Speaker has many Session records
        //Session.Speaker 1---* Person.AttendanceList
        //HasRequired(session => session.Speaker)
        //  .WithMany(person => person.SpeakerSessions) //SpeakerSessions is session collection in Person entity
        //.HasForeignKey(session => session.SpeakerId);


        //1) A one-to-zero-or-one relationship between the Instructor and OfficeAssignment entities:
        //modelBuilder.Entity<Instructor>()
        //.HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);


        /*2) A many-to-many relationship between the Instructor and Course entities. 
         * The code specifies the table and column names for the join table. 
         * Code First can configure the many-to-many relationship for you without this code, 
         * but if you don't call it, you will get default names such as 
         * InstructorInstructorID for the InstructorID column.*/

        /*modelBuilder.Entity<Course>()
            .HasMany(c => c.Instructors).WithMany(i => i.Courses)
            .Map(t => t.MapLeftKey("CourseID")
                .MapRightKey("InstructorID")
                .ToTable("CourseInstructor"));
         */


        /*3) A zero-or-one-to-many relationship between the Instructor and Department tables. 
         * In other words, a department may or may not have an instructor assigned to it as 
         * administrator; the assigned administrator is represented by the 
         * Department.Administrator navigation property: */

        /*modelBuilder.Entity<Department>()
            .HasOptional(x => x.Administrator);
         */


        //4) one-to-zero-or-one relationship between the Instructor and OfficeAssignment entities:
        //modelBuilder.Entity<Instructor>()
        //.HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);

        //5) one-to-zero-or-one relationship between the Department and Instructor tables, 
        //represented by the Department.Administrator navigation property:
        //(an Instructor entity does not have to have a corresponding Department, 
        // so the WithRequired method is not called)
        //modelBuilder.Entity<Department>()
        //.HasOptional(x => x.Administrator);
    }
}
