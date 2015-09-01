using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppIdentity.Models
{
    public class Comic
    {
        public int ID { get; set; }
        public string ComicName { get; set; }
        public string Company { get; set; }
        public int Year { get; set; }
    }
}