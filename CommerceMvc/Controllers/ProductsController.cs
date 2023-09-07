using CommerceMvc.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceMvc.Controllers
{
    public class ProductsController : Controller
    {
        private CommerceMvcContext _context;

        public ProductsController(CommerceMvcContext context)
        {
            _context = context;
        }

        [Route("/products/{id:int}")]
        public ActionResult Show(int id)
        {
            ViewData["CurrentUser"] = Request.Cookies["CurrentUser"];
            var product = _context
                .Products
                .Include(p => p.Merchant)
                .Where(p => p.Id == id)
                .First();

            return View(product);
        }
    }
}
