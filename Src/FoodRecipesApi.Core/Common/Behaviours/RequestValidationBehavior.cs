using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = FoodRecipesApi.Application.Common.Exceptions.ValidationException;

namespace FoodRecipesApi.Application.Common.Behaviours
{
    class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationContext = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(validator => validator.Validate(validationContext))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(errors => errors != null)
                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);

            return next();
        }
    }
}
