using System;
using System.Data.Entity;
using System.Linq;

namespace Brighteye.DataModel
{
    public class BrighteyeContext : DbContext
    {
        public BrighteyeContext()
            : base("name=BrighteyeContext")
        {
        }
        
        public DbSet<Number> Numbers { get; set; }
    }
}