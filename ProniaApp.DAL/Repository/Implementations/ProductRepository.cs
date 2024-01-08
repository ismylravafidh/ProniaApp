using ProniaApp.Core.Entities;
using ProniaApp.DAL.Context;
using ProniaApp.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaApp.DAL.Repository.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ProniaAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
