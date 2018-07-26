using CMS.Domain.Core;
using CMS.Infrastructure;
using CMS.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS_Model.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //InitData();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //private void InitData()
        //{
        //    Database.SetInitializer(new DropCreateDatabaseAlways<SchoolDbContext>());
        //    var context = new SchoolDbContext();
        //    //插入一行值
        //    context.Student.Add(new Student { Name = "wangty", Age = "26" });
        //    context.SaveChanges();
        //}
    }
}