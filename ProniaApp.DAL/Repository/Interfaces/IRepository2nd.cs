using Microsoft.EntityFrameworkCore;
using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.DAL.Repository.Interfaces
{
    public interface IRepository2nd<Entity> where Entity : BaseEntity, new()
    {
        Task<Entity> GetByIdAsync(int id);
        Task Create(Entity entity);
        void RemoveRange(IEnumerable<Entity> entity);
        void Remove(Entity entity);
        Task SaveChangesAsync();
        DbSet<Entity> Table { get; }
    }
}
