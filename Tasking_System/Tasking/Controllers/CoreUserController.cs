using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Tasking.Models;

namespace Tasking.Controllers
{
    public class CoreUserController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: CoreUser
        public ActionResult Index()
        {
            return View(db.CoreUsers.ToList());
        }

        public ActionResult MyAccount()
        {
            return View(db.CoreUsers.SingleOrDefault(x => x.UserName.Equals(User.Identity.Name)));
        }
    }
}