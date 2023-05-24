using HoltinModels.DiscountCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public DiscountPolicies DiscountPolicies { get; set; }
        public string EmailPattern { get; set; }
    }

    public class ConnectionStrings
    {
        public string MyConnectionString { get; set; }
    }
}




