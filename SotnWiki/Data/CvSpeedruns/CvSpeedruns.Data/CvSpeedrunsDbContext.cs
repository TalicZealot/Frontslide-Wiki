using CvSpeedruns.Models;
using System.Data.Entity;

namespace CvSpeedruns.Data
{
    public class CvSpeedrunsDbContext : DbContext
    {
        public CvSpeedrunsDbContext()
            :base("DefaultConnection")
        {
        }

        public IDbSet<Run> Runs { get; set; }
    }
}
