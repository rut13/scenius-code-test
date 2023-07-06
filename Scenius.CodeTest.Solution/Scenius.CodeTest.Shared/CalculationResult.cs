using System.ComponentModel.DataAnnotations;

namespace Scenius.CodeTest.Shared
{
    public class CalculationResult
    {
        [Key]
        public int Id { get; set; }

        public string RawCalculation { get; set; } = string.Empty;

        public double Result { get; set; }
    }
}