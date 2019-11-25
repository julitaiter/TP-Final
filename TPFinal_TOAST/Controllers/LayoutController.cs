using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPFinal_TOAST.Models;

namespace TPFinal_TOAST.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        [ChildActionOnly]
        public ActionResult SiteName()
        {
            return new ContentResult { Content = "Site name goes here" };
        }
    }
}