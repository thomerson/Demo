using Demo.IocNinject.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Demo.IocNinject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repository;


        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        public JsonResult Index()
        {
            var data = repository.GetAll();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
