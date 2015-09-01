using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AppIdentity.Models
{
    public class AppIdentityDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AppIdentityDBContext() : base("name=AppIdentityDBContext")
        {
        }

        public System.Data.Entity.DbSet<AppIdentity.Models.Game> Games { get; set; }

        public System.Data.Entity.DbSet<AppIdentity.Models.Comic> Comics { get; set; }

        public System.Data.Entity.DbSet<AppIdentity.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<AppIdentity.Models.Video> Videos { get; set; }
    }
}
