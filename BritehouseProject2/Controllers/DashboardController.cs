using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver;
using BritehouseProject2.Models;
using BritehouseProject2.App_Start;
using BritehouseProject2.ViewModels;

namespace BritehouseProject2.Controllers
{
    public class DashboardController : Controller
    {

        private MongoDBContext dBContext;
        private IMongoCollection<PeopleModel> peopleCollection;
        private IMongoCollection<ReturnsModel> returnsCollection;
        private IMongoCollection<OrdersModel> ordersCollection;

    

        


        public DashboardController()
        {
            dBContext = new MongoDBContext();
            peopleCollection = dBContext.database.GetCollection<PeopleModel>("personreviews");
            returnsCollection = dBContext.database.GetCollection<ReturnsModel>("returnsreviews");
            ordersCollection = dBContext.database.GetCollection<OrdersModel>("ordersreviews");
          
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            List<PeopleModel> peopleList = peopleCollection.AsQueryable<PeopleModel>().ToList();
            List<ReturnsModel> returnsList = returnsCollection.AsQueryable<ReturnsModel>().ToList();
            List<OrdersModel> ordersList = ordersCollection.AsQueryable<OrdersModel>().ToList();
            ViewModels.AdminModel admin = new ViewModels.AdminModel();

            int totalAfrica = (from x in peopleList.Where(x => x.Region.Contains("Africa")) select x.Person).Count();
            int totalEurope = (from x in peopleList.Where(x => x.Region.Contains("Europe")) select x.Person).Count();
            int totalAsia = (from x in peopleList.Where(x => x.Region.Contains("Asia")) select x.Person).Count();
            int totalUSA = (from x in peopleList.Where(x => x.Region.Contains("US")) select x.Person).Count();

            admin.Africa_count = totalAfrica;
            admin.Europe_count = totalEurope;
            admin.Asia_count = totalAsia;
            admin.USA_count = totalUSA;
            //Orders

            int totalUS = (from x in ordersList.Where(x => x.Country.Contains("United States")) select x.Country).Count();
            int totalNicaragua = (from x in ordersList.Where(x => x.Country.Contains("Nicaragua")) select x.Country).Count();
            int totalJapan = (from x in ordersList.Where(x => x.Country.Contains("Japan")) select x.Country).Count();
            int totalTurkey = (from x in ordersList.Where(x => x.Country.Contains("Turkey")) select x.Country).Count();
            int totalFrance = (from x in ordersList.Where(x => x.Country.Contains("France")) select x.Country).Count();
            int totalMexico = (from x in ordersList.Where(x => x.Country.Contains("Mexico")) select x.Country).Count();

            admin.US_count = totalUS;
            admin.Nicaragua_count = totalNicaragua;
            admin.Japan_count = totalJapan;
            admin.Turkey_count = totalTurkey;
            admin.France_count = totalFrance;
            admin.Mexico_count = totalMexico;

            return View(admin);
        }

            public ActionResult tables()
            {


            List<PeopleModel> peopleList = peopleCollection.AsQueryable<PeopleModel>().ToList();
            List<OrdersModel> ordersList = ordersCollection.AsQueryable<OrdersModel>().ToList();
            TablesModel tdata = new TablesModel();
            tdata.tPeopleList = peopleList;
            tdata.tOrdersList = ordersList;
       

            return View(tdata);
            }
    }
      
}
