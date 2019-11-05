using LifeCore.Models;
using LifeCore.Nhibernate;
using Microsoft.AspNetCore.Mvc;

namespace LifeCore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Test {Name = "gfsdg"};
            using (var session = NhibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Save(model);
                    transaction.Commit();
                }
            }
            return View();
        }
    }
}
