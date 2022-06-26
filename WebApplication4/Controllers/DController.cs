using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                Link link = new Link();

                link.KisaLink = I;

                link = link.UzunLinkGetir();
                if (link.Count < 10)
                {
                    link.SayacArttir();
                    Response.Redirect(link.UzunLink);
                }

            }
            catch (Exception ex)
            {
                string date = DateTime.Now.ToString();
                string msg = ex.Message;
                string trace = ex.StackTrace;
                string helplink = ex.HelpLink;
                string path = Server.MapPath("~/log/"+DateTime.Now.ToString("dd-MM-yyyy")+".txt");

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("------------------------");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.Write(date + " ");
                    sw.Write(msg + " ");
                    sw.Write(helplink + " ");
                    sw.WriteLine(trace);
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("----------------------");
                }
            }
            return View();
        }
    }
}

