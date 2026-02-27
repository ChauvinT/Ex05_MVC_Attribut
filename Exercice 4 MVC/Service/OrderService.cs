namespace Exercice_5_MVC.Service
{
    using BO;
    using Exercice_5_MVC.ViewModel;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;

    public class OrderService
    {
        private static ApplicationDbContext dbContext = new ApplicationDbContext();

        public List<Order> GetOrders()
        {
            return dbContext.Orders;
        }
        public List<OrderDetail> GetOrderDetail()
        {
            return dbContext.OrderDetails;
        }

        public List<Article> GetArticle()
        {
            return dbContext.ArticleReferences;
        }

        public void Add(Order order)
        {
            decimal totalAmount = 0;

            order.Id = dbContext.Orders.LastOrDefault().Id+1;
            foreach (var item in order.OrderDetails) {
                item.OrderId = order.Id;
                dbContext.OrderDetails.Add(item);

                totalAmount += item.UnitPrice * item.Quantity;
            }
            order.TotalAmount = Convert.ToDouble(totalAmount);
            dbContext.Orders.Add(order);
        }

        public void Remove(Order order)
        {
            dbContext.Orders.Remove(order);
        }
    }
}
