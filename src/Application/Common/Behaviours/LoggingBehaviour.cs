using Microsoft.Extensions.Logging;

namespace ProductMaster.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest>
{
    private readonly ILogger _logger;
    //private readonly IUser _user;
    //private readonly IIdentityService _identityService;

    public LoggingBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public void Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        string? userName = string.Empty;

        _logger.LogInformation("ProductMaster Request: {Name}  {@UserName} {@Request}",
            requestName, userName, request);
    }
}
