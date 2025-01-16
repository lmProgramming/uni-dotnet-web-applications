using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

//using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApp9_ApiStudent.Models;

namespace WebApp9_ApiStudent.Controllers
{
    // aby mozna było używać kontrolera z innych miejśc niż sam kontroler
    [EnableCors]
    [Route("api/student/")]
    [ApiController]

    public class StudentApiController : ControllerBase
    {
        private IRepository repository;
        public StudentApiController(IRepository repo) => repository = repo;

        [HttpGet]
        public IEnumerable<Student> Get() => repository.Students;

        [HttpGet("{id}")]
        public Student? Get(int id) => repository[id];

        [HttpPost]
        [EnableCors]
        public Student Post([FromBody] Student res) =>
            repository.AddStudent(new Student
            {
                Index = res.Index,
                Name = res.Name
            });

        [HttpPut]
        public Student Put([FromBody] Student res) =>
            repository.UpdateStudent(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id,
                [FromBody] JsonPatchDocument<Student> patch)
        {
            Student? res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteStudent(id);

        [HttpGet("prev/{id}")]
        public Student? GetPrev(int id) => repository.GetPreviousStudent(id);

        [HttpGet("next/{id}")]
        public Student? GetNext(int id) => repository.GetNextStudent(id);
    }
}