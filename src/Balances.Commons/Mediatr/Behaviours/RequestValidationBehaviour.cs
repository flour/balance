﻿using Balances.Commons.Models;
using FluentValidation;
using Mapster;
using MediatR;

namespace Balances.Commons.Mediatr.Behaviours;

public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(s => s.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .Select(e => e.ErrorMessage)
            .ToList();

        return failures.Count != 0
            ? Task.FromResult(Result.Bad(string.Join(". ", failures)).Adapt<TResponse>())
            : next();
    }
}