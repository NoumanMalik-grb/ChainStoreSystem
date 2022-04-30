﻿using ChainStoreSystem.Models;
using Microsoft.EntityFrameworkCore;
namespace ChainStoreSystem.Data
{
    public class ChainStoreDbContext : DbContext
    {
        public ChainStoreDbContext(DbContextOptions<ChainStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<SubCategory> Sub_Categorie { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Area> areas { get; set; }
        public DbSet<DamagedProduct> damagedProducts { get; set; }
        public DbSet<Account> accounts { get; set; }
        public DbSet<CompanyDetail> companyDetails { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
    }
}
