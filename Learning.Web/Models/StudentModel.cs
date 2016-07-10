using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Web.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Data.Enums.Gender Gender { get; set; }
        public int EnrollmentsCount { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public IEnumerable<EnrollmentModel> Enrollments { get; set; }
    }
}