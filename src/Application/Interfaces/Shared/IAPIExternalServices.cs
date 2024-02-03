namespace ProductMaster.Application.Interfaces.Shared
{
    public interface IAPIExternalServices
    {
        string? GetDiscountExternal(string text);
        decimal ConvertStringDecimal(string? stringVal);
    }
}
