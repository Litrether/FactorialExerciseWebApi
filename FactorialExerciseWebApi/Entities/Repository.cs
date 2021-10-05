using FactorialExerciseWebApi.Entities.Models;
using FactorialExerciseWebApi.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FactorialExerciseWebApi.Entities
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(FactorialValue entity) =>
            _dbContext.Add(entity);

        public IQueryable<FactorialValue> GetAll() =>
            _dbContext.FactorialValue;

        public FactorialValue GetByValue(long value) =>
            _dbContext.FactorialValue.FirstOrDefault(x => x.Value == value);

        public void Save() => _dbContext.SaveChanges();
    }
}
