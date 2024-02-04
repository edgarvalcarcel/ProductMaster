using System.Text.RegularExpressions;
using ProductMaster.Application.Common.Interfaces;

namespace EquitiesMutualFunds.Orders.Infrastructure.Shared.Services
{
    public class NumberService : IIntegerService
    {
        public bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(text);
        }

        public decimal CreateRandomDecimal()
        {
            return new decimal(new Random().NextDouble());
        }
    }
}
