using FactorialExerciseWebApi.Entities.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FactorialExerciseWebApi.Interfaces
{
    public interface IRepository
    {
        public IQueryable<FactorialValue> GetAll();

        public FactorialValue GetByValue(long value);

        public void Create(FactorialValue entity);

        public void Save();
    }
}
