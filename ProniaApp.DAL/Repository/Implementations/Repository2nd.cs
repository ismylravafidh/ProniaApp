using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using ProniaApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaApp.Core.Entities.Common;
using ProniaApp.DAL.Context;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace ProniaApp.DAL.Repository.Implementations
{
    public class Repository2nd<Entity> : IRepository2nd<Entity> where Entity : BaseEntity, new()
    {
        private readonly ProniaAppDbContext _dbContext;
        public Repository2nd(ProniaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DbSet<Entity> Table => _dbContext.Set<Entity>();
        public async Task<Entity> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task Create(Entity entity)
        {
            await Table.AddAsync(entity);
        }
        public async void RemoveRange(IEnumerable<Entity> entity)
        {
            Table.RemoveRange(entity);
        }
        public async void Remove(Entity entity)
        {
            Table.Remove(entity);
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
