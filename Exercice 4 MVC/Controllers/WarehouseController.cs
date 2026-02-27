using BO;
using Exercice_5_MVC.Models;
using Exercice_5_MVC.Service.Exercice_4_MVC.Service;
using Exercice_5_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exercice_5_MVC.Controllers
{

    public class WarehouseController : Controller
    {

        WarehouseService warehouseService; 

        public WarehouseController()
        {
            warehouseService = new WarehouseService();
        }

        // GET: WarehouseController
        public ActionResult Index()
        {
            return View(warehouseService.GetWarehouses().Select(x => Mapping.ConvertToWarehouseVM(x)));
        }

        // GET: WarehouseController/Details/5
        public ActionResult Details(int id)
        {
            // Search throught warehouses list the target warehouse by id
            var foundWarehouse = warehouseService.GetWarehouses().FirstOrDefault(w => w.Id == id);

            return View(Mapping.ConvertToWarehouseVM(foundWarehouse));
        }

        // GET: WarehouseController/Order/5
        public ActionResult Order(int id, Models.Order order)
        {
            OrderViewModel vm = new OrderViewModel();
            return View(vm);

            // Search throught warehouses list the target warehouse by id
            //var foundWarehouse = warehouseService.GetWarehouses().FirstOrDefault(w => w.Id == id);

            //return RedirectToAction("Create", "Order", id );
        }

        // GET: WarehouseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: WarehouseController/Edit/5
        public ActionResult Edit(int id)
        {
            // Search throught warehouses list the target warehouse by id
            var foundWarehouse = warehouseService.GetWarehouses().FirstOrDefault(w => w.Id == id);

            return View(Mapping.ConvertToWarehouseVM(foundWarehouse));
        }

        // POST: WarehouseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // Search throught warehouses list the target warehouse by id
                var foundWarehouse = warehouseService.GetWarehouses().FirstOrDefault(w => w.Id == id);
                if (foundWarehouse is null)
                {
                    throw new Exception();
                }
                ApplyFormCollectionToWarehouse(collection, foundWarehouse);
                warehouseService.Update(foundWarehouse);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void ApplyFormCollectionToWarehouse(IFormCollection collection, Warehouse foundWarehouse)
        {
            foreach (var field in collection)
            {
                if (field.Key == nameof(foundWarehouse.Id))
                {
                    foundWarehouse.Id = int.Parse(field.Value);
                }
                else if (field.Key == nameof(foundWarehouse.Name))
                {
                    foundWarehouse.Name = field.Value;
                }
                else if (field.Key == nameof(foundWarehouse.Address))
                {
                    foundWarehouse.Address = field.Value;
                }
                else if (field.Key == nameof(foundWarehouse.PostalCode))
                {
                    foundWarehouse.PostalCode = int.Parse(field.Value);
                }
            }
        }

        // GET: WarehouseController/Delete/5
        public ActionResult Delete(int id)
        {
            // Search throught warehouses list the target warehouse by id
            var foundWarehouse = warehouseService.GetWarehouses().FirstOrDefault(w => w.Id == id);

            return View(Mapping.ConvertToWarehouseVM(foundWarehouse));
        }

        // POST: WarehouseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // Search throught warehouses list the target warehouse by id
                var foundWarehouse = warehouseService.GetWarehouses().FirstOrDefault(w => w.Id == id);
                if(foundWarehouse != null)
                {
                    warehouseService.Remove(foundWarehouse);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

  
    }
}
