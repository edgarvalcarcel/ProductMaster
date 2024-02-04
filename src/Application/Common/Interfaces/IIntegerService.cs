namespace ProductMaster.Application.Common.Interfaces;
public interface IIntegerService
{
    bool IsNumber(string text);
    decimal CreateRandomDecimal();
}
