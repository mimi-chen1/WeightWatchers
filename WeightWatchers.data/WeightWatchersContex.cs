using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightWatchers.data.Entites;
using WeightWatchers.data.Model;

namespace WeightWatchers.data
{
    public  class WeightWatchersContex: DbContext
    {
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Card> Cards { get; set; }
        public WeightWatchersContex(DbContextOptions<WeightWatchersContex> options):base(options)
        {

        }
    }
}
