using System.Collections.Generic;
using Diplom.Models.Entities;

namespace Diplom.Domain.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
    }
}