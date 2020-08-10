using apiAspNetEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiAspNetEF.Data {
    public class DataContext: DbContext { //Representaçao do banco de dados em memoria

        public DataContext(DbContextOptions<DataContext> options): base(options) {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
