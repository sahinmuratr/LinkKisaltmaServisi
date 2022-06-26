using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DController : Controller
    {
        // GET: D
        public ActionResult In(String I)
        {

            Link link = new Link();

            link.KisaLink = I;

            link = link.UzunLinkGetir();
            if (link.Count < 10)
            {
                link.SayacArttir();
                Response.Redirect(link.UzunLink);
            }
            return View();
        }
    }
}