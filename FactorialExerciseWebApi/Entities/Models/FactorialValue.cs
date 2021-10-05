using System.ComponentModel.DataAnnotations;

namespace FactorialExerciseWebApi.Entities.Models
{
    public class FactorialValue
    {
        [Key]
        public long Value { get; set; }

        public long Factorial { get; set; }
    }
}
