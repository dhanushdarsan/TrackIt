using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrackIt.Application.Interfaces;
using TrackIt.Domain.Entities;
using TrackIt.Infrastructure.Data;

namespace TrackIt.Infrastructure.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly AppDbContext _context;

        public IssueRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Issue>> GetAllAsync()
        {
           return await _context.Issues.ToListAsync();
        }

        public async Task<Issue> AddAsync(Issue issue)
        {
            _context.Issues.Add(issue);
            await _context.SaveChangesAsync();
            return issue;
        }

        public async Task<Issue?> GetAsync(int id)
        {
            return await _context.Issues.FindAsync(id);
        }

        public async Task<Issue> UpdateAsync(Issue issue)
        {
            _context.Issues.Update(issue);
            await _context.SaveChangesAsync();
            return issue;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            if (issue == null)
            {
                return false;
            }
            _context.Issues.Remove(issue);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
