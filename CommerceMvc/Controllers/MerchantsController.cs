using CommerceMvc.DataAccess;
using CommerceMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceMvc.Controllers
{
    public class MerchantsController : Controller
    {
        private CommerceMvcContext _context;

        public MerchantsController(CommerceMvcContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            ViewData["CurrentUser"] = Request.Cookies["CurrentUser"];
            var merchants = _context.Merchants;

            return View(merchants);
        }

        [Route("/merchants/{id:int}")]
        public ActionResult Show(int id)
        {
            ViewData["CurrentUser"] = Request.Cookies["CurrentUser"];
            var merchant = _context
                .Merchants
                .Include(m => m.Products)
                .Where(m => m.Id == id)
                .First();

            return View(merchant);
        }

        public ActionResult New()
        {
            ViewData["CurrentUser"] = Request.Cookies["CurrentUser"];
            return View();
        }

        [HttpPost]
        [Route("/merchants")]
        public ActionResult Create(Merchant merchant)
        {
            _context.Merchants.Add(merchant);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
