using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadAPI.Models;

namespace UploadAPI.Context
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ): base(options) { }
        public DbSet<Photo> Photos { get; set; }
    }
}
