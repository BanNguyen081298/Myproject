using Microsoft.EntityFrameworkCore;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Presistent
{
    public class HelloAngularDbContext : DbContext
    {
        public HelloAngularDbContext()
        {
        }
        public HelloAngularDbContext(DbContextOptions<HelloAngularDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<PaymentDetail> PaymentDetail { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=helloangulardb;uid=root;password=123456;treattinyasboolean=true;convertzerodatetime=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.16-mysql"));
            }
        }
    }
}
