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
    public class ProductImageRepository : Repository2nd<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ProniaAppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
