namespace Web1.Models
{
    using System.Data.Entity;

    public class mvc5Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public mvc5Context() : base("name=DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<Web1.Areas.Masters.Models.VENDOR> VENDORs { get; set; }
        public System.Data.Entity.DbSet<Web1.Areas.Masters.Models.VEHICLE> VEHICLEs { get; set; }
    }
}
