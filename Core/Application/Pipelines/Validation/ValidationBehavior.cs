using Core.CrossCuttingConcers.Exceptions.Types;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = Core.CrossCuttingConcers.Exceptions.Types.ValidationException;

namespace Core.Application.Pipelines.Validation
{
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest: IRequest<TResponse>
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			_validators = validators;
		}

		public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var validationResult = _validators.Select(x=> x.Validate(request));
			if (validationResult.Any())
			{
				IEnumerable<ValidationExceptionModel> errors = validationResult
					.SelectMany(x => x.Errors)
					.GroupBy(x => x.PropertyName)
					.Select(group => new ValidationExceptionModel
				{
					Errors = group.Select(x=>x.ErrorMessage).ToList(),
					Property = group.Key
				});

				throw new ValidationException(errors);
			}

			return await next();
		}
	}
}
