using Microsoft.EntityFrameworkCore;
using PDFViewer.Models;
using System;

namespace PDFViewer.Data
{
    public class ApplicationDbContext : DbContext
    {

  
        public DbSet<SvgAccessModel> SvgAccessModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=D:\dotnet\PDFViewer\PDFViewer\Data\Users.db");

        internal object Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
