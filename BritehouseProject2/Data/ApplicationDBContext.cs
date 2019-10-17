using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BritehouseProject2.Models;

namespace BritehouseProject2.Data
{
    public class ApplicationDBContext
    {
        public List<PeopleModel> tPeopleList { get; set; }
        public List<OrdersModel> tOrdersList { get; set; }
    }
}