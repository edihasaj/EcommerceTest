using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliersList = SupplierRepository.GetSuppliers();

            return View(suppliersList);
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int id)
        {
            var supplierDetails = SupplierRepository.GetSupplierById(id);

            return View(supplierDetails);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                SupplierRepository.Insert(supplier);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int id)
        {
            var supplierDetails = SupplierRepository.GetSupplierById(id);

            return View(supplierDetails);
        }

        // POST: Suppliers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Supplier supplier)
        {
            try
            {
                SupplierRepository.Update(supplier);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int id)
        {
            var supplierDetails = SupplierRepository.GetSupplierById(id);

            return View(supplierDetails);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var supplierDetails = SupplierRepository.GetSupplierById(id);

            try
            {
                SupplierRepository.Remove(supplierDetails);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}