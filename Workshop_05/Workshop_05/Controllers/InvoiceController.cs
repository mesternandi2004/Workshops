using Microsoft.AspNetCore.Mvc;
using Workshop_05.Data;
using Workshop_05.Models;

namespace Workshop_05.Controllers
{
    public class InvoiceController : Controller
    {
        private static InvoiceRepository repository = new InvoiceRepository();

        public ActionResult Index()
        {
            var invoices = repository.GetAll();
            return View("~/Views/Home/Index.cshtml", invoices);
        }

        public ActionResult Create()
        {
            return View("~/Views/Home/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                repository.Add(invoice);
                return RedirectToAction("Index");
            }
            return View("~/Views/Home/Create.cshtml", invoice);
        }

        public ActionResult Edit(int id)
        {
            var invoice = repository.GetById(id);
            if (invoice == null) return NotFound();
            return View("~/Views/Home/Edit.cshtml", invoice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                repository.Update(invoice);
                return RedirectToAction("Index");
            }
            return View("~/Views/Home/Edit.cshtml", invoice);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var invoice = repository.GetById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            repository.Delete(id);
            return Ok(); 
        }

        [HttpPost]
        public ActionResult MarkAsPaid(int id)
        {
            var invoice = repository.GetById(id);
            if (invoice != null)
            {
                invoice.IsPaid = true;
                repository.Update(invoice);
            }
            return RedirectToAction("Index");
        }
    }
}
