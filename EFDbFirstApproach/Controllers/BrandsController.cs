﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproach.Models;

namespace EFDbFirstApproach.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        CompanyDBContext db = new CompanyDBContext();
        public ActionResult Index()
        {
            //here EFDBFirstDatabaseEntities is the name of db contex
            

            List<Brand> brands = db.Brands.ToList();

            return View(brands);
        }
    }
}