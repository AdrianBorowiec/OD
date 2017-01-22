using OD.DAL;
using OD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OD.Controllers
{
    public class OrderController : Controller
    {
        private Db db = new Db();
        
        public ActionResult Index()
        {

            if (Session["OrderId"] == null)
            {
                return View("EmptyOrder");
            }
            else
            {
                var orderId = (int)Session["OrderId"];
                var model = db.OrderDetails.Where(x => x.Order.Id == orderId).AsEnumerable();

                ViewBag.Total = model.Sum(x => x.TotalAmount);
                return View(model);
            }
        }

        public ActionResult AddToCart(int? id, int? quantity)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.FirstOrDefault(x => x.Id == id);
            var orderDetails = new OrderDetails()
            {
                Product = product,
                Quantity = quantity,
                TotalAmount = product.Price * quantity
            };

            Order order;

            if (Session["OrderId"] == null)
            {
                order = new Order();
                order.OrderStatus = OrderStatus.Nowe;
                var tempCustomerId = (int)Session["CustomerId"];
                var customer = db.Customers.FirstOrDefault(x => x.Id == tempCustomerId);
                order.Customer = customer;
                db.Orders.Add(order);
                db.SaveChanges();
                var tempOrderId = db.Orders.OrderByDescending(x => x.Id).First();
                Session["OrderId"] = tempOrderId.Id;
            }
            else
            {
                int temp = (int)Session["OrderId"];
                order = db.Orders.First(x => x.Id == temp);
            }

            if (order.OrderDetails.Any(x => x.Product.Id == orderDetails.Product.Id))
            {
                var temp = order.OrderDetails.Single(x => x.Product.Id == orderDetails.Product.Id);
                db.Entry(temp).State = EntityState.Modified;
                temp.Quantity += orderDetails.Quantity;
            }
            else
            {
                order.OrderDetails.Add(orderDetails);
            }

            db.SaveChanges();
            ViewBag.Total = order.OrderDetails.Sum(x => x.TotalAmount);

            return View("Index", order.OrderDetails);
        }
       
        public ActionResult EmptyOrder()
        {
            Session.Remove("OrderId");

            return RedirectToAction("Index");
        }

        public ActionResult FinishOrder()
        {
            var orderId = (int)Session["OrderId"];

            var order = db.Orders.Single(x => x.Id == orderId);
            db.Entry(order).State = EntityState.Modified;

            order.OrderStatus = OrderStatus.Zakończone;
            order.TotalAmount = order.OrderDetails.Sum(x => x.TotalAmount);

            foreach (var item in order.OrderDetails)
            {
                var product = db.Products.Single(x => x.Id == item.Product.Id);
                db.Entry(product).State = EntityState.Modified;

                product.Quantity -= item.Quantity;
            }

            db.SaveChanges();
            Session.Remove("OrderId");

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrderDetails orderDetails = db.OrderDetails.Find(id);

            if (orderDetails == null)
            {
                return HttpNotFound();
            }

            try
            {
                db.OrderDetails.Remove(orderDetails);
                db.SaveChanges();
                return Content("true");
            }
            catch
            {
                return Content("false");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
