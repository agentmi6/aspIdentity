using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppIdentity.Models
{
    public class Game
    {

        public int ID { get; set; }
        public string GameName { get; set; }
        public int Year { get; set; }
        public string Platform { get; set; }
        public string Approved { get; set; }
    }
}