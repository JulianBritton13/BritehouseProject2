using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BritehouseProject2.ViewModels
{
    public class AdminModel
    {
        //people
        public int Africa_count { get; set; }
        public int Europe_count { get; set; }
        public int USA_count { get; set; }
        public int Asia_count { get; set; }

        // orders
        public int US_count { get; set; }
        public int Nicaragua_count { get; set; }
        public int Japan_count { get; set; }
        public int Turkey_count { get; set; }
        public int France_count { get; set; }
        public int Mexico_count { get; set; }

        //returns countrys

        public int rAfrica_count { get; set; }
        public int rEurope_count { get; set; }
        public int rUSA_count { get; set; }
        public int rAsia_count { get; set; }
    


    }
}