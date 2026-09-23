using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrackIt.Application.Interfaces;
using TrackIt.Domain.Entities;
using TrackIt.Infrastructure.Data;


namespace TrackIt.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
