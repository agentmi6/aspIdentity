using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppIdentity.Models
{
    public class Video
    {
        public int ID { get; set; }
        public string Title { get; set; }       
        public string Description { get; set; }
        public string VideoLink { get; set; }
        public string tags { get; set; }     
        public string isApproved { get; set; }        
    }
}