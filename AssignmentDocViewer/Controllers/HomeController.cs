using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AssignmentDocViewer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int currentPageNumber = 1;
            int totalPages = 1;
            ViewBag.CurrentPage = currentPageNumber;
            ViewBag.DocContent = new DocUtilty().GetContent(currentPageNumber, out totalPages);
            ViewBag.TotalPages = totalPages;

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
        public string GetDocContent(int pageNumber)
        {
            string result = string.Empty;
            //result = "This is doc content and page number is " + pageNumber;
            int totalPages = 0;
            
            result = new DocUtilty().GetContent(pageNumber, out totalPages);
            return result;
        }
    }
}