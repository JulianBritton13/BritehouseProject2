using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using BritehouseProject2.Models;
using BritehouseProject2.App_Start;

namespace BritehouseProject2.Controllers
{
    public class OrdersController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<OrdersModel> ordersCollection;

        // GET: Orders

        public OrdersController()
        {
            dBContext = new MongoDBContext();
            ordersCollection = dBContext.database.GetCollection<OrdersModel>("ordersreviews");
        }

        public ActionResult Index()
        {
            List<OrdersModel> ordersList = ordersCollection.AsQueryable<OrdersModel>().ToList();
            return View(ordersList);
        }
    }
}