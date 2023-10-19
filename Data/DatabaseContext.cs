using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cSharpWebApi.Data.Employee.Dto;
using cSharpWebApi.Data.Author;
using cSharpWebApi.Data.Department;

namespace cSharpWebApi.Data
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public override int SaveChanges()
        {
            AddTimestampsAndUser();
            return base.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            AddTimestampsAndUser();
            return base.SaveChangesAsync();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            AddTimestampsAndUser();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestampsAndUser();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestampsAndUser()
        {
            var entities = ChangeTracker.Entries()
                                        .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if(entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                    ((BaseEntity)entity.Entity).CreatedBy = "andr3a.giacomini";
                }
                    
                ((BaseEntity)entity.Entity).UpdatedAt = now;
                ((BaseEntity)entity.Entity).UpdatedBy = "andr3a.giacomini";
            }
        }

        public DbSet<Address.Address> Addresses { get; set; }
        public DbSet<Author.Author> Authors { get; set; }
        public DbSet<Employee.Employee> Employees { get; set; } = default!;
        public DbSet<Department.Department> Departments { get; set; }
        public DbSet<AuthorBook.AuthorBook> AuthorBook { get; set; }
        public DbSet<Book.Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address.Address>()
                .HasOne<Author.Author>(au => au.AuthorAddress)
                .WithOne(ad => ad.Address)
                .HasForeignKey<Author.Author>(ad => ad.AddressId);

            modelBuilder.Entity<Address.Address>()
                .HasOne<Employee.Employee>(au => au.EmployeeAddress)
                .WithOne(ad => ad.Address)
                .HasForeignKey<Employee.Employee>(ad => ad.AddressId);

            modelBuilder.Entity<Author.Author>()
                .HasMany(ab => ab.AuthorBooks)
                .WithOne(a => a.Author)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Book.Book>()
                .HasMany(ab => ab.BookAuthors)
                .WithOne(b => b.Book)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}