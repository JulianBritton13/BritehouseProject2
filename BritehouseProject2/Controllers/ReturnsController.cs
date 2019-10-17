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
    public class ReturnsController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<ReturnsModel> returnsCollection;

        // GET: Returns
        public ReturnsController()
        {
            dBContext = new MongoDBContext();
            returnsCollection = dBContext.database.GetCollection<ReturnsModel>("returnsreviews");
        }
        public ActionResult Index()
        {
            List<ReturnsModel> returnsList = returnsCollection.AsQueryable<ReturnsModel>().ToList();
            return View(returnsList);
        }
    }
}