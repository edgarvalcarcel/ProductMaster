namespace ProductMaster.Application.Common.Interfaces;
public interface IAPIExternalServices
{
    string? GetDiscountExternal(string text);
    decimal ConvertStringDecimal(string? stringVal);
}
