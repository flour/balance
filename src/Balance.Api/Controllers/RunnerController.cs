using Balance.Api.Business.Features.RunSimple;
using CS.Sdk.Commons.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Balance.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RunnerController : ControllerBase
{
    private readonly IMediator _mediator;

    public RunnerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("simple")]
    public Task<Result> RunSimple(CancellationToken token)
        => _mediator.Send(new RunSimpleCommand(), token);
}