using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using Learning.Data.Entities;
using Learning.Data;


namespace Learning.Web.Controllers
{
    public class CoursesController : ApiController
    {
        public CoursesController()
            : base()
        {
        }

        public List<Course> Get()
        {
            ILearningRepository repository = new LearningRepository(new LearningContext());

            return repository.GetAllCourses().ToList();
        }

        [Route("{id:int}")]
        public HttpResponseMessage GetCourse(int id)
        {
            ILearningRepository repository = new LearningRepository(new LearningContext());

            return Request.CreateResponse(HttpStatusCode.OK, repository.GetCourse(id));

        }
    }
}
