using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using general_eye.Models;

namespace general_eye.Data
{
    public class general_eyeContext : DbContext
    {
        public general_eyeContext(DbContextOptions<general_eyeContext> options)
            : base(options)
        {
        }

      




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


          

            //modelBuilder.Entity<v_never>()
            //.ToView(nameof(v_never))
            //.HasNoKey();

          



        }

      




        public DbSet<general_eye.Models.user>? user { get; set; }








    }
}
