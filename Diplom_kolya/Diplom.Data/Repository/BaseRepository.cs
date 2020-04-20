using System.Collections.Generic;
using System.Linq;
using Diplom.Domain.Contracts;
using Diplom.Models.Entities;

namespace Diplom.Data.Repository
{
    public class BaseRepository <T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<T> GetAll() => _context.Set<T>().ToList();
    }
}