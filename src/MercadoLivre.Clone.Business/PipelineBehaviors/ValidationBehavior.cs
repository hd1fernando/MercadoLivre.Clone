using FluentValidation;
using MediatR;

namespace MercadoLivre.Clone.Business.PipelineBehaviors;
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            _validators.Select(x => x.ValidateAsync(context, cancellationToken))
            );

        var failures = validationResults.SelectMany(x => x.Errors)
             .Where(x => x is not null)
             .ToList();

        if (failures.Any())
            throw new ValidationException(failures);

        return await next();
    }
}
