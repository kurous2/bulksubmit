using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProgramTest.Models;
using ProgramTest.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
namespace ProgramTest.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Gender> tblM_Gender { get; set; }
    public DbSet<Hobi> tblM_Hobi { get; set; }
    public DbSet<Umur> tblT_Umur { get; set; }
    public DbSet<Personal> tblT_Personal { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<Personal>()
            .HasOne(p => p.Gender)
            .WithMany()
            .HasForeignKey(p => p.IdGender);

        modelBuilder.Entity<Personal>()
            .HasOne(p => p.Hobi)
            .WithMany()
            .HasForeignKey(p => p.IdHobi);

    }
}
