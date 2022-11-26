using AutoMapper;
using Demo.AutoMapperWeb.Model;
using Demo.AutoMapperWeb.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AutoMapperWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IMapper _mapper;
        public StudentsController(IMapper mapper)
        {
            this._mapper = mapper;
        }

        [HttpGet]
        public List<StudentVM> Get()
        {
            List<Student> list = new List<Student>();

            for (int i = 0; i < 3; i++)
            {
                Student student = new Student()
                {
                    ID = i,
                    Name = $"测试_{i}",
                    Age = 20,
                    Gender = "男"
                };
                list.Add(student);
            }

            var result = _mapper.Map<List<StudentVM>>(list);
            return result;
        }
    }
}
