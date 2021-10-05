using FactorialExerciseWebApi.Entities;
using FactorialExerciseWebApi.Entities.Models;
using FactorialExerciseWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FactorialExerciseWebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class FactorialController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IFactorialService _factService;

        public FactorialController(IRepository repository, IFactorialService factService)
        {
            _repository = repository;
            _factService = factService;
        }

        [HttpGet("factorials/{n}")]
        public async Task<IActionResult> GetFactorial(long n)
        {
            if (n < 0)
                return BadRequest();

            var factValue = _repository.GetByValue(n);
            if (factValue != null)
                return Ok(factValue.Factorial);

            factValue = new FactorialValue()
            {
                Value = n,
                Factorial = _factService.Fact(n)
            };

            _repository.Create(factValue);
            _repository.Save();

            return Ok(factValue.Factorial);
        }

        [HttpGet("factorials/{n}/nearest-value")]
        public async Task<IActionResult> GetNearestValue(long n)
        {
            if (n < 0)
                return BadRequest();

            var factValues = _repository.GetAll().ToList().OrderBy(v => v.Value);
            var minFactValue = factValues.Where(v => v.Value < n).LastOrDefault();
            var maxFactValue = factValues.Where(v => v.Value > n).FirstOrDefault();

            var minValue = minFactValue == null ? "null" : minFactValue.Value.ToString();
            var maxValue = maxFactValue == null ? "null" : maxFactValue.Value.ToString();

            return Ok("{" + $"{minValue}, {maxValue}" + "}");
        }

        [HttpGet("values/{x}/nearest-factorial")]
        public async Task<IActionResult> GetNearestFactorial(long x)
        {
            if (x < 0)
                return BadRequest();

            var factValues = _repository.GetAll().ToList().OrderBy(v => v.Factorial);
            var minFactValue = factValues.Where(v => v.Factorial < x).LastOrDefault();
            var maxFactValue = factValues.Where(v => v.Factorial > x).FirstOrDefault();

            var minValue = minFactValue == null ? "null" : minFactValue.Value.ToString();
            var maxValue = maxFactValue == null ? "null" : maxFactValue.Value.ToString();

            return Ok("{" + $"{minValue}, {maxValue}" + "}");
        }
    }
}
