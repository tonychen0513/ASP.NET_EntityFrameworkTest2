using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Learning.Data;
using Learning.Web.Models;
using Learning.Data.Entities;

namespace Learning.Web.Controllers
{
    public class StudentsController : BaseApiController
    {
        public StudentsController(ILearningRepository repo)
            : base(repo)
        {
        }

        public IEnumerable<StudentModel> Get()
        {
            IQueryable<Student> query;
            query = TheRepository.GetAllStudentsWithEnrollments();

            var results = query.ToList().Select(s => TheModelFactory.Create(s));

            return results;
        }

        public HttpResponseMessage GetStudent(string userName)
        {
            try
            {
                var student = TheRepository.GetStudent(userName);
                if (student != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(student));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Post([FromBody] Student student)
        {
            try
            {
                if (TheRepository.Insert(student) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, TheModelFactory.Create(student));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not save to the datebase!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(string userName, [FromBody] Student student)
        {
            try
            {
                var originalStudent = TheRepository.GetStudent(userName);

                if (originalStudent == null || originalStudent.UserName != userName)
                {
                    return Request.CreateResponse(HttpStatusCode.NotModified, "Student is not found!");
                }
                else
                    student.Id = originalStudent.Id;

                if (TheRepository.Update(originalStudent, student) && TheRepository.SaveAll())
                {
                    return Request.CreateResponse(HttpStatusCode.OK, TheModelFactory.Create(student));
                }
                else
                    return Request.CreateResponse(HttpStatusCode.NotModified);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(string userName)
        {
            try
            {
                var student = TheRepository.GetStudent(userName);
                if (student == null)
                    return Request.CreateResponse(HttpStatusCode.NotFound);

                if (student.Enrollments.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "can not delete the student with enrollments in course.");
                }

                if (TheRepository.DeleteStudent(student.Id) && TheRepository.SaveAll())
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.BadRequest);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
