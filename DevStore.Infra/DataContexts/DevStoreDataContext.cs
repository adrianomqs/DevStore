using DevStore.Domain;
using DevStore.Infra.Mappings;
using System.Data.Entity;

namespace DevStore.Infra
{
    public class DevStoreDataContext : DbContext
    {
        public DevStoreDataContext() 
            : base("DevStoreConnectionString")
        {
            
            Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {
            context.Categories.Add(new Category { Id = 1, Title = "Informática" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.SaveChanges();

            context.Products.Add(new Product { Id = 1, CategoryId = 1, IsActive = true, Title = "Mouse", Price = 10 });
            context.Products.Add(new Product { Id = 2, CategoryId = 1, IsActive = true, Title = "Notebook Dell", Price = 2840.99M });

            context.Products.Add(new Product { Id = 3, CategoryId = 3, IsActive = true, Title = "Papel A4", Price = 10.3M });
            context.Products.Add(new Product { Id = 4, CategoryId = 3, IsActive = true, Title = "Caneta Bic", Price = 1.5M });
            context.Products.Add(new Product { Id = 5, CategoryId = 3, IsActive = true, Title = "Lápis", Price = 1.6M });
            context.Products.Add(new Product { Id = 6, CategoryId = 3, IsActive = true, Title = "Borracha", Price = 0.5M });

            context.Products.Add(new Product { Id = 7, CategoryId = 2, IsActive = true, Title = "God Of War 3 - PS3", Price = 120 });
            context.Products.Add(new Product { Id = 8, CategoryId = 2, IsActive = true, Title = "Forza 4 - Xbox One", Price = 140 });
            context.Products.Add(new Product { Id = 9, CategoryId = 2, IsActive = true, Title = "Fifa 14 - PS3", Price = 130 });
            context.Products.Add(new Product { Id = 10, CategoryId = 2, IsActive = true, Title = "Gran Turismo 6 - PS4", Price = 165 });
            context.Products.Add(new Product { Id = 11, CategoryId = 2, IsActive = true, Title = "FIFA World Cup Brazil - PS4", Price = 195 });
            context.Products.Add(new Product { Id = 12, CategoryId = 2, IsActive = true, Title = "Batlefield 3 - PS4", Price = 100 });
            context.Products.Add(new Product { Id = 13, CategoryId = 2, IsActive = true, Title = "Resident Evil 6 - PS4", Price = 85.3M });
            context.Products.Add(new Product { Id = 14, CategoryId = 2, IsActive = true, Title = "Assassins Creed 3 - PS4", Price = 70 });
            context.Products.Add(new Product { Id = 15, CategoryId = 2, IsActive = true, Title = "Assassins Creed Black Flag - PS4", Price = 180.5M });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
