﻿using Microsoft.EntityFrameworkCore;
using ProniaApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.DAL.Repository.Interfaces
{
    public interface IRepository<Entity> where Entity : BaseAuditable, new()
    {
        Task<IQueryable<Entity>> GetAllAsync(Expression<Func<Entity, bool>>? expression = null,
            Expression<Func<Entity, object>>? orderbyExpression = null,
            bool isDescinding = false,
            params string[]? includes);
        Task<Entity> GetByIdAsync(int id);
        Task Create(Entity entity);
        Task Update(Entity entity);
        void Delete(Entity entity);
        Task SaveChangesAsync();
        DbSet<Entity> Table { get; }
    }
}