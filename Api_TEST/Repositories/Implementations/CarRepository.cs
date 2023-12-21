using Api_TEST.DAL;
using Api_TEST.Entities;
using Api_TEST.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace Api_TEST.Repositories.Implementations
{
    public class CarRepository: GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }


    }
}
