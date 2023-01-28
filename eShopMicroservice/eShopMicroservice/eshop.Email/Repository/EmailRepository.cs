﻿using eShop.Email.Messages;
using eShop.Email.Model;
using eShop.Email.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace eShop.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<MySqlContext> _context;

        public EmailRepository(DbContextOptions<MySqlContext> context)
        {
            _context = context;
        }

        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new EmailLog()
            {
                Email = message.Email,
                SentDate = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully!"
            };

            await using var _db = new MySqlContext(_context);
            _db.Emails.Add(email);
            await _db.SaveChangesAsync();
        }
    }
}
