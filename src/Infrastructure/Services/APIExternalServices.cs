using ProductMaster.Application.Interfaces.Shared;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using ProductMaster.Infrastructure.Data;

namespace ProductMaster.Infrastructure.Shared.Services
{
    public class APIExternalServices : IAPIExternalServices
    {
        private readonly ExternalServices _urlexternalUrl;
        private readonly ILogger<ProductMasterDbContextInitialiser> _logger;

        public APIExternalServices(IOptions<ExternalServices> config, ILogger<ProductMasterDbContextInitialiser> logger)
        {
            _urlexternalUrl = config.Value;
            _logger = logger;
        }
        
        public string? GetDiscountExternal(string text)
        {
            string url = _urlexternalUrl.DiscountAPI;
            var parameter = ApiResUtility.Request<ResponseAPI>(url, text);
            return parameter?.Discount;
        }

        public decimal ConvertStringDecimal(string? stringVal)
        {
            decimal decimalVal = 0;

            try
            {
                decimalVal = Convert.ToDecimal(stringVal);
            }
            catch (OverflowException ex)
            {
                _logger.LogError(ex, "The conversion from string to decimal overflowed.");
             }
            catch (FormatException ex)
            {
                _logger.LogError(ex, "The string is not formatted as a decimal.");
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError(ex, "The string is null.");
            }
            return decimalVal;
        }
    }
}

