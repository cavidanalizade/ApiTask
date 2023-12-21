using Api_TEST.DAL;
using Api_TEST.Entities;
using Api_TEST.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Api_TEST.Repositories.Implementations
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
