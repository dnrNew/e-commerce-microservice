﻿using Microsoft.EntityFrameworkCore;

namespace eShop.Email.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        public DbSet<EmailLog> Emails { get; set; }
                
    }
}
