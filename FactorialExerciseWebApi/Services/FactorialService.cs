using FactorialExerciseWebApi.Interfaces;

namespace FactorialExerciseWebApi.Services
{
    public class FactorialService : IFactorialService
    {
        public long Fact(long n) =>
            n == 0 ? 1 : n * Fact(n - 1);

    }
}
