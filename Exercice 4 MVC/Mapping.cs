using BO;
using Exercice_5_MVC.Models;
using Exercice_5_MVC.ViewModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static NuGet.Packaging.PackagingConstants;
using Order = BO.Order;

namespace Exercice_5_MVC
{
    public class Mapping
    {
       public static WarehouseVM  ConvertToWarehouseVM(Warehouse warehouse)
        {
            var vm = new WarehouseVM();
            vm.Id = warehouse.Id;
            vm.Address = warehouse.Address;
            vm.Name = warehouse.Name;
            vm.PostalCode = warehouse.PostalCode;
            
            return vm;
        }

        public static Warehouse ToWarehouse(WarehouseVM wm)
        {
            var warehouse = new Warehouse();
            warehouse.Id = wm.Id;
            warehouse.Address = wm.Address;
            warehouse.Name = wm.Name;
            warehouse.PostalCode = wm.PostalCode;

            return warehouse;
        }

        public static OrderViewModel ConverToOrderVM(Order order)
        {
            var vm = new OrderViewModel();

            vm.Id = order.Id;
            vm.CustomerName = order.CustomerName;
            vm.Email = order.Email;
            vm.ShippingAddress = order.ShippingAddress;
            vm.OrderDate = order.OrderDate;
            vm.TotalAmount = order.TotalAmount;
            vm.OrderStatus = order.OrderStatus;
            vm.WarehouseId = order.WarehouseId;
            vm.OrderDetails = order.OrderDetails.ToList();

            return vm;
        }

        public static Order ToOrder(OrderViewModel vm)
        {
            var order = new Order();
            order.Id = vm.Id;
            order.CustomerName = vm.CustomerName;
            order.Email = vm.Email;
            order.ShippingAddress = vm.ShippingAddress;
            order.OrderDate = vm.OrderDate;
            order.TotalAmount = vm.TotalAmount;
            order.OrderStatus = vm.OrderStatus;
            order.OrderDetails = vm.OrderDetails.ToList();

            return order;
        }
    }
}
