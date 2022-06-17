using Balances.Commons.Models;
using MediatR;

namespace Balance.Api.Business.Features.RunSimple;

public class RunSimpleCommandHandler : IRequestHandler<RunSimpleCommand, Result>
{
    private readonly ILogger<RunSimpleCommandHandler> _logger;

    public RunSimpleCommandHandler(
        ILogger<RunSimpleCommandHandler> logger)
    {
        _logger = logger;
    }
    
    public async Task<Result> Handle(RunSimpleCommand request, CancellationToken cancellationToken)
    {
        return Result.Ok();
    }
}