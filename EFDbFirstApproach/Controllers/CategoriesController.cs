using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproach.Models;

namespace EFDbFirstApproach.Controllers
{
    public class CategoriesController : Controller
    {

        // GET: Categories
        CompanyDBContext db = new CompanyDBContext();
        public ActionResult Index()
        {
          
            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }
    }
}