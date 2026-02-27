using BO;
using Exercice_5_MVC.Models;
using Exercice_5_MVC.Service;
using Exercice_5_MVC.Service.Exercice_4_MVC.Service;
using Exercice_5_MVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Reflection;

namespace Exercice_5_MVC.Controllers
{
    public class OrderController : Controller
    {
        WarehouseService warehouseService;
        OrderService orderService;

        public OrderController()
        {
            warehouseService = new WarehouseService();
            orderService = new OrderService();
        }

        public ActionResult Index()
        {
            var orderVM = orderService.GetOrders();
            var orderDetailVM = orderService.GetOrderDetail();

            foreach (var order in orderVM)
            {
                order.OrderDetails = orderDetailVM.Where(d => d.OrderId == order.Id).ToList();
            }
            return View(orderService.GetOrders().Select(x => Mapping.ConverToOrderVM(x)));
        }

        // GET: OrderController/Order/5
        public ActionResult Create(int id)
        {

            ViewBag.ArticlesReference = orderService.GetArticle();

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(OrderViewModel orderVM, string action, List<OrderDetail> orderDetails)
        {
            
            //if (!ModelState.IsValid)
            //{
            //    return View(orderVM);
            //}

            if (action == "Save")
            {
                var lignes = orderDetails
                    .Where(x => x.Quantity > 0)
                    .ToList();

                List<OrderDetail> ord = new List<OrderDetail>();
                foreach (var ligne in lignes)
                {
                    ord.Add(ligne);
                }
                orderVM.OrderDetails = ord;
                orderService.Add(Mapping.ToOrder(orderVM));
            }

            return RedirectToAction("Index");
        }

        // GET: OrderController/Order/5
        public ActionResult Details(int id)
        {
            var foundOrder= orderService.GetOrders().FirstOrDefault(w => w.Id == id);

            return View(Mapping.ConverToOrderVM(foundOrder));
        }
    }
}