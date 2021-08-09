using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproach.Models;

namespace EFDbFirstApproach.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        // to retrive all the products
        CompanyDBContext db = new CompanyDBContext();
        public ActionResult Index(string search="", string SortColumn="ProductName",string IconClass = "fa-sort-desc",int PageNo=1)
        {
            
            //List<Product> products = db.Products.ToList(); //to retrive all the list of db
            // List<Product> products = db.Products.Where(temp=>temp.CategoryID==1 && temp.Price >= 50000).ToList(); // conditional sorting
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            ViewBag.search = search;
            ViewBag.IconClass = IconClass;
            ViewBag.SortColumn = SortColumn;
            //sorting
            if (ViewBag.SortColumn=="ProductID")
            {
                if (ViewBag.IconClass=="fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductID).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductID).ToList();
                }
            }

            else if (ViewBag.SortColumn == "ProductName" && search.Length==0)
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.ProductName).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.ProductName).ToList();
                }
            }

            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.Price).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.Price).ToList();
                }
            }

            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
                }
            }

            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.DateOfPurchase).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
                }
            }

            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.Brand.BrandName).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
                }
            }

            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                {
                    products = db.Products.OrderBy(temp => temp.Category.CategoryName).ToList();
                }
                else
                {
                    products = db.Products.OrderByDescending(temp => temp.Category.CategoryName ).ToList();
                }
            }

            //pagination

            int NumberOfRecordsPerPage = 3;
            int NumberOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NumberOfRecordsPerPage)));
            int NumberOfRecordsToSkip = (PageNo - 1) * NumberOfRecordsPerPage;

            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPg = NumberOfPages;

            products = products.Skip(NumberOfRecordsToSkip).Take(NumberOfRecordsPerPage).ToList();

            return View(products);
        }

        //to retrive single row

        public ActionResult Details(long id)
        {
           
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        // to create products
        public ActionResult Create()
        {
            
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
           
            if (Request.Files.Count>=1)
            {
                var file = Request.Files[0];
                var imageBytes = new Byte[file.ContentLength - 1];
                file.InputStream.Read(imageBytes, 0, imageBytes.Length);
                var base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                p.Photo = base64String;
            }
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(long id)
        {
            
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            
            Product ExistingProduct =  db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
            
            ExistingProduct.ProductName = p.ProductName;
            ExistingProduct.Price = p.Price;
            ExistingProduct.DateOfPurchase = p.DateOfPurchase;
            ExistingProduct.CategoryID = p.CategoryID;
            ExistingProduct.BrandID = p.BrandID;
            ExistingProduct.AvailabilityStatus = p.AvailabilityStatus;
            ExistingProduct.Active = p.Active;
            db.SaveChanges();

            return RedirectToAction("index");
            
        }

        public ActionResult Delete(long id)
        {
            
            Product p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(long id,Product p)
        {
            
            Product removingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(removingProduct);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}