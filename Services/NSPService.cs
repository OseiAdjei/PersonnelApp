﻿using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class NSPService : INSPService   
    {
        private readonly AppDbContext _context;
        public NSPService(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Nsp nsp)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Nsp>> GetAllAsync()
        {
            var result = await _context.Nsp.ToListAsync();
            return result;
        }

        public async Task<Nsp> GetByIdAsync(int id)
        {
            var result = await _context.Nsp.FirstOrDefaultAsync(n => n.NspId == id);

            return result;
        }
    }
}
