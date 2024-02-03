namespace EquitiesMutualFunds.Orders.Application.Interfaces.Shared
{
    public interface IIntegerService
    {
        bool IsNumber(string text);
        decimal CreateRandomDecimal();
    }
}
