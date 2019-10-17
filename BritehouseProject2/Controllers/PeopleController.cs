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
    public class PeopleController : Controller
    {
        private MongoDBContext dBContext;
        private IMongoCollection<PeopleModel> peopleCollection;

        // GET: People

        public PeopleController()
        {
            dBContext = new MongoDBContext();
            peopleCollection = dBContext.database.GetCollection<PeopleModel>("personreviews");
        }
        public ActionResult Index()
        {
            List<PeopleModel> peopleList = peopleCollection.AsQueryable<PeopleModel>().ToList();
            return View(peopleList);
        }
    }
}