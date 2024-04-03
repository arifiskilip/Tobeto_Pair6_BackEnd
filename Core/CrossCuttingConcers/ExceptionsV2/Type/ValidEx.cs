using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcers.ExceptionsV2.Type;

public class ValidEx : IException
{
	public IEnumerable<ValidationExceptionModel> Errors { get; }

	public ValidEx(IEnumerable<ValidationExceptionModel> errors)
		: base(StatusCodes.Status400BadRequest,"Fluent Valid",BuildErrorMessage(errors),"Fluent Valid")
	{
		Errors = errors;
	}

	private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
	{
		IEnumerable<string> arr = errors.Select(
			x => $"{Environment.NewLine} -- {x.Property}: {string.Join(Environment.NewLine, x.Errors)}"
		);
		return $"Validation failed: {string.Join(string.Empty, arr)}";
	}
}

public class ValidationExceptionModel
{
	public string? Property { get; set; }
	public IEnumerable<string>? Errors { get; set; }
}

