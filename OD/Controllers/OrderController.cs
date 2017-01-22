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


            // pozniej do poprawki - w tym miejscu sprawdzamy czy aktualnie zalogowany uzytkownik ma juz utworzone zamowienie
            //var order = db.Orders.Where(x => x.Customer == aktualny uzytkownik)

            Order order;

            if (Session["OrderId"] == null)
            {
                order = new Order();
                db.Orders.Add(order);
                db.SaveChanges();
                var temp = db.Orders.OrderByDescending(x => x.Id).First();
                Session["OrderId"] = temp.Id;
            }
            else
            {
                int temp = (int)Session["OrderId"];
                order = db.Orders.First(x => x.Id == temp);
            }

            if (order.OrderDetails.Any(x => x.Product.Id == orderDetails.Product.Id))
            {
                //db.Entry(orderDetails).State = EntityState.Modified;
                //order.OrderDetails.Where(x => x.Product.Id == orderDetails.Product.Id).Select(x => x.Quantity += orderDetails.Quantity);
                var temp = order.OrderDetails.Single(x => x.Product.Id == orderDetails.Product.Id);
                db.Entry(temp).State = EntityState.Modified;
                temp.Quantity += orderDetails.Quantity;
            }
            else
            {
                order.OrderDetails.Add(orderDetails);
            }
            
            //db.OrderDetails.Add(orderDetails);

            db.SaveChanges();

            return View("Index", order.OrderDetails);
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
