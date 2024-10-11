using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_JQ1_18_12.Models
{
    public class EmployeModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public long Mobile { get; set; }
        public string Age { get; set; }
        

        public string Country { get; set; }
        public int State { get; set; }
    }
}