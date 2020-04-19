using Diplom.Domain.Contracts;
using Diplom.Models.Entities;

namespace Diplom.Data.Repository
{
    public class BaseRepository <T> : IRepository<T> where T : BaseEntity
    {
        
    }
}